using InhouseCustomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InhouseCustomAPI.Helpers;
using static InhouseCustomAPI.Models.GameDataModel;
using System.Data.Entity;
using static InhouseCustomAPI.Models.GameDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace InhouseCustomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameDataController : ControllerBase
    {
        private readonly GameDbContext database;
        private string path;

        public GameDataController(IWebHostEnvironment env)
        {
            database = new GameDbContext();
            path = env.ContentRootPath;
            database.GameData.ToList();
            database.ParticipantIdentity.ToList();
            database.Participant.ToList();
            database.Players.ToList();
            database.Team.ToList();
            database.Ban.ToList();
            database.Stats.ToList();
            database.Timeline.ToList();
            database.CreepsPerMinDeltas.ToList();
            database.XpPerMinDeltas.ToList();
            database.GoldPerMinDeltas.ToList();
            database.CsDiffPerMinDeltas.ToList();
            database.XpDiffPerMinDeltas.ToList();
            database.DamageTakenPerMinDeltas.ToList();
            database.DamageTakenDiffPerMinDeltas.ToList();
        }

        [HttpGet]
        [Route("LoadAllGameDataAndTimelines")]
        public void LoadAllGameDataAndTimelines()
        {
            string[] gameDataFiles = Directory.GetFiles(@"C:\Users\phili\OneDrive\Skrivbord\Projekt\Node\CustomGameStats\src\games", "*.json");
            foreach (var file in gameDataFiles)
            {
                LoadFiles.LoadGameDataFile(file);
            }
            string[] timelineFiles = Directory.GetFiles(@"C:\Users\phili\OneDrive\Skrivbord\Projekt\Node\CustomGameStats\src\timelines", "*.json");
            foreach (var file in timelineFiles)
            {
                var split = file.Split('\\');
                var fileName = split[split.Length - 1];
                long gameDataId = long.Parse(fileName.Split('.')[0]);
                LoadFiles.LoadGameTimelineFile(file, gameDataId);
            }

        }

        [HttpPost("UploadGameDataFile")]
        public async Task<IActionResult> UploadGameDataFile(IFormFile file)
        {
            string uploads = Path.Combine(path, "GamesTemp");
            //Create directory if it doesn't exist 
            Directory.CreateDirectory(uploads);

            if (file.Length > 0)
            {
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                LoadFiles.LoadGameDataFile(filePath);
            }
            else
            {
                return Problem();
            }
            return Ok();
        }

        [HttpPost("UploadTimelineFile")]
        public async Task<IActionResult> UploadTimelineFile(IFormFile file)
        {
            string uploads = Path.Combine(path, "TimelinesTemp");
            //Create directory if it doesn't exist 
            Directory.CreateDirectory(uploads);

            if (file.Length > 0)
            {
                string filePath = Path.Combine(uploads, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                long gameDataId = long.Parse(file.FileName.Split('.')[0]);
                LoadFiles.LoadGameTimelineFile(filePath, gameDataId);
            }
            else
            {
                return Problem();
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetAllGameDatas")]
        public List<Game> GetAllGameDatas()
        {
            var games = database.Games.ToList();

            foreach (var game in games)
            {
                game.GameData.participants = game.GameData.participants.OrderBy(x =>
                {
                    switch (x.timeline.lane)
                    {
                        case "TOP":
                            return 0;
                        case "JUNGLE":
                            return 1;
                        case "MIDDLE":
                            return 2;
                        case "BOTTOM":
                            if (x.timeline.role == "DUO_CARRY")
                            {
                                return 3;
                            }
                            return 4;
                        default:
                            return 5;
                    }
                }).ToList();
            }
            games.Reverse();
            return games;
        }

        [HttpGet]
        [Route("GetAllGameData")]
        public Game GetAllGameData(Guid gameId)
        {
            var game = database.Games.Include(x => x.GameData).Where(x => x.Id == gameId).First();
            game.GameData.participants = game.GameData.participants.OrderBy(x =>
            {
                switch (x.timeline.lane)
                {
                    case "TOP":
                        return 0;
                    case "JUNGLE":
                        return 1;
                    case "MIDDLE":
                        return 2;
                    case "BOTTOM":
                        if (x.timeline.role == "DUO_CARRY")
                        {
                            return 3;
                        }
                        return 4;
                    default:
                        return 5;
                }
            }).ToList();

            game.GameData.teams = game.GameData.teams.OrderBy(x => x.TeamId).ToList();
            foreach (var team in game.GameData.teams)
            {
                team.bans = team.bans.OrderBy(x => x.PickTurn).ToList();
            }
            return game;
        }

        [HttpGet]
        [Route("GetCSPM")]
        public Graph GetCSPM(Guid gameId)
        {
            Graph graph = new Graph();
            graph.data = new List<GraphData>();
            graph.colors = new List<GraphColor>();

            var game = database.Games.Include(x => x.GameData).Where(x => x.Id == gameId).First();
            foreach (var par in game.GameData.participants)
            {
                GraphData data = new GraphData();
                GraphColor colors = new GraphColor();
                foreach (var id in game.GameData.participantIdentities)
                {
                    if (id.participantId == par.participantId)
                    {
                        data.name = id.player.summonerName;
                        data.value = Math.Round((double)(par.stats.totalMinionsKilled + (double)par.stats.neutralMinionsKilled) / (double)(game.GameData.gameDuration / 60), 2);
                        colors.name = id.player.summonerName;
                        if (par.teamId == 100)
                        {
                            // Blue
                            colors.value = "#4788b6";
                        }
                        else
                        {
                            // Red
                            colors.value = "#e62142";
                        }
                        break;
                    }
                }
                graph.data.Add(data);
                graph.colors.Add(colors);
            }


            graph.data = graph.data.OrderBy(x => x.value).Reverse().ToList();
            return graph;
        }

        [HttpGet]
        [Route("GetGPM")]
        public Graph GetGPM(Guid gameId)
        {
            Graph graph = new Graph();
            graph.data = new List<GraphData>();
            graph.colors = new List<GraphColor>();

            var game = database.Games.Include(x => x.GameData).Where(x => x.Id == gameId).First();
            foreach (var par in game.GameData.participants)
            {
                GraphData data = new GraphData();
                GraphColor colors = new GraphColor();
                foreach (var id in game.GameData.participantIdentities)
                {
                    if (id.participantId == par.participantId)
                    {
                        data.name = id.player.summonerName;
                        data.value = Math.Round((double)(par.stats.goldEarned) / (double)(game.GameData.gameDuration / 60), 2);
                        colors.name = id.player.summonerName;
                        if (par.teamId == 100)
                        {
                            // Blue
                            colors.value = "#4788b6";
                        }
                        else
                        {
                            // Red
                            colors.value = "#e62142";
                        }
                        break;
                    }
                }
                graph.data.Add(data);
                graph.colors.Add(colors);
            }


            graph.data = graph.data.OrderBy(x => x.value).Reverse().ToList();
            return graph;
        }

        [HttpGet]
        [Route("GetDamage")]
        public Graph GetDamage(Guid gameId)
        {
            Graph graph = new Graph();
            graph.data = new List<GraphData>();
            graph.colors = new List<GraphColor>();

            var game = database.Games.Include(x => x.GameData).Where(x => x.Id == gameId).First();
            foreach (var par in game.GameData.participants)
            {
                GraphData data = new GraphData();
                GraphColor colors = new GraphColor();
                foreach (var id in game.GameData.participantIdentities)
                {
                    if (id.participantId == par.participantId)
                    {
                        data.name = id.player.summonerName;
                        data.value = par.stats.totalDamageDealtToChampions;
                        colors.name = id.player.summonerName;
                        if (par.teamId == 100)
                        {
                            // Blue
                            colors.value = "#4788b6";
                        }
                        else
                        {
                            // Red
                            colors.value = "#e62142";
                        }
                        break;
                    }
                }
                graph.data.Add(data);
                graph.colors.Add(colors);
            }


            graph.data = graph.data.OrderBy(x => x.value).Reverse().ToList();
            return graph;
        }
    }
}
