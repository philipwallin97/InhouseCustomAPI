using InhouseCustomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InhouseCustomAPI.Models.GameTimelineModel;

namespace InhouseCustomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimelineController : ControllerBase
    {
        private readonly GameDbContext database;
        public TimelineController()
        {
            database = new GameDbContext();
            database.Frames.ToList();
            database.Events.ToList();
            database.Positions.ToList();
            database.ParticipantFrame.ToList();
            database.Games.ToList();
            database.GameData.ToList();
            database.Participant.ToList();
            database.ParticipantIdentity.ToList();
            database.Players.ToList();
        }

        [HttpGet]
        [Route("GetGoldDiff")]
        public ChartRoot[] GetGoldDiff(Guid gameId)
        {
            var timelines = database.GameTimelines.ToList();
            var games = database.Games.ToList();

            var timeline = timelines.Where(x => x.gameId == gameId).First();
            var game = games.Where(x => x.Id == gameId).First();

            ChartRoot blueTeam = new ChartRoot
            {
                name = "Blue Team",
                series = new List<ChartSerie>()
            };
            ChartRoot redTeam = new ChartRoot
            {
                name = "Red Team",
                series = new List<ChartSerie>()
            };

            foreach (var frame in timeline.frames)
            {
                ChartSerie blue = new ChartSerie
                {
                    name = int.Parse((frame.timestamp / 60000).ToString())
                };
                ChartSerie red = new ChartSerie
                {
                    name = int.Parse((frame.timestamp / 60000).ToString())
                };
                foreach (var par in frame.participantFramesList)
                {
                    foreach (var gpar in game.GameData.participants)
                    {
                        if (gpar.participantId == par.participantId)
                        {
                            if (gpar.teamId == 100) // Blue
                            {
                                blue.value += par.totalGold;
                            } 
                            else
                            {
                                red.value += par.totalGold;
                            }
                            break;
                        }
                    }
                }
                int blueGold = blue.value;
                int redGold = red.value;
                blue.value = blueGold - redGold;
                red.value = redGold - blueGold;
                blueTeam.series.Add(blue);
                redTeam.series.Add(red);
            }

            ChartRoot[] chartRoots = new ChartRoot[2];
            redTeam.series = redTeam.series.OrderBy(x => x.name).ToList();
            chartRoots[0] = redTeam;
            blueTeam.series = blueTeam.series.OrderBy(x => x.name).ToList();
            chartRoots[1] = blueTeam;
            return chartRoots;
        }

        [HttpGet]
        [Route("GetTeamGold")]
        public ChartRoot[] GetTeamGold(Guid gameId)
        {
            var timelines = database.GameTimelines.ToList();
            var games = database.Games.ToList();

            var timeline = timelines.Where(x => x.gameId == gameId).First();
            var game = games.Where(x => x.Id == gameId).First();

            ChartRoot blueTeam = new ChartRoot
            {
                name = "Blue Team",
                series = new List<ChartSerie>()
            };
            ChartRoot redTeam = new ChartRoot
            {
                name = "Red Team",
                series = new List<ChartSerie>()
            };

            foreach (var frame in timeline.frames)
            {
                ChartSerie blue = new ChartSerie
                {
                    name = int.Parse((frame.timestamp / 60000).ToString())
                };
                ChartSerie red = new ChartSerie
                {
                    name = int.Parse((frame.timestamp / 60000).ToString())
                };
                foreach (var par in frame.participantFramesList)
                {
                    foreach (var gpar in game.GameData.participants)
                    {
                        if (gpar.participantId == par.participantId)
                        {
                            if (gpar.teamId == 100) // Blue
                            {
                                blue.value += par.totalGold;
                            }
                            else
                            {
                                red.value += par.totalGold;
                            }
                            break;
                        }
                    }
                }
                blueTeam.series.Add(blue);
                redTeam.series.Add(red);
            }

            ChartRoot[] chartRoots = new ChartRoot[2];
            redTeam.series = redTeam.series.OrderBy(x => x.name).ToList();
            chartRoots[0] = redTeam;
            blueTeam.series = blueTeam.series.OrderBy(x => x.name).ToList();
            chartRoots[1] = blueTeam;
            return chartRoots;
        }


        [HttpGet]
        [Route("GetPlayerGold")]
        public ChartRoot[] GetPlayerGold(Guid gameId)
        {
            var timelines = database.GameTimelines.ToList();
            var games = database.Games.ToList();

            var timeline = timelines.Where(x => x.gameId == gameId).First();
            var game = games.Where(x => x.Id == gameId).First();

            ChartRoot[] players = new ChartRoot[10];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new ChartRoot();
            }
            foreach (var player in players)
            {
                player.series = new List<ChartSerie>();
            }

            foreach (var frame in timeline.frames)
            {
                foreach (var par in frame.participantFramesList)
                {
                    foreach (var gpar in game.GameData.participants)
                    {
                        if (gpar.participantId == par.participantId)
                        {
                            ChartSerie chartSerie = new ChartSerie
                            {
                                name = int.Parse((frame.timestamp / 60000).ToString()),
                                value = par.totalGold
                            };
                            foreach (var parid in game.GameData.participantIdentities)
                            {
                                if (parid.participantId == gpar.participantId)
                                {
                                    players[gpar.participantId - 1].name = parid.player.summonerName;
                                    break;
                                }
                            }
                            players[gpar.participantId - 1].series.Add(chartSerie);
                            break;
                        }
                    }
                }

            }

            foreach (var player in players)
            {
                player.series = player.series.OrderBy(x => x.name).ToList();
            }

            return players;
        }


        [HttpGet]
        [Route("GetKillPositions")]
        public BubbleChartRoot[] GetKillPositions(Guid gameId)
        {
            var timelines = database.GameTimelines.ToList();
            var games = database.Games.ToList();

            var timeline = timelines.Where(x => x.gameId == gameId).First();
            var game = games.Where(x => x.Id == gameId).First();

            BubbleChartRoot redTeam = new BubbleChartRoot();
            redTeam.name = "Red team kill";
            redTeam.series = new List<BubbleChartSerie>();

            BubbleChartRoot blueTeam = new BubbleChartRoot();
            blueTeam.name = "Blue team kill";
            blueTeam.series = new List<BubbleChartSerie>();

            foreach (var frame in timeline.frames)
            {
                if (frame.events != null)
                {
                    foreach (var ev in frame.events)
                    {
                        if (ev.type == "CHAMPION_KILL")
                        {
                            string killer = "";
                            string victim = "";
                            int teamId = 0;
                            foreach (var par in game.GameData.participantIdentities)
                            {
                                if (par.participantId == ev.killerId)
                                {
                                    killer = par.player.summonerName;
                                }
                                if (par.participantId == ev.victimId) 
                                {
                                    victim = par.player.summonerName;
                                }
                            }
                            foreach (var par in game.GameData.participants)
                            {
                                if (par.participantId == ev.killerId)
                                {
                                    teamId = par.teamId;
                                }
                            }
                            BubbleChartSerie bubbleChartSerie = new BubbleChartSerie
                            {
                                name = killer + " killed " + victim,
                                x = ev.position.x,
                                y = ev.position.y,
                                r = 1
                            };

                            

                            if (teamId == 100) 
                            {
                                blueTeam.series.Add(bubbleChartSerie);
                            }
                            else
                            {
                                redTeam.series.Add(bubbleChartSerie);
                            }
                        }
                    }
                }
                
            }

            BubbleChartRoot[] chartRoots = new BubbleChartRoot[2];
            chartRoots[0] = redTeam;
            chartRoots[1] = blueTeam;
            return chartRoots;
        }
    }


    public class ChartRoot
    {
        public string name { get; set; }
        public List<ChartSerie> series { get; set; }
    }

    public class ChartSerie
    {
        public int name { get; set; }
        public int value { get; set; }
    }


    public class BubbleChartRoot
    {
        public string name { get; set; }
        public List<BubbleChartSerie> series { get; set; }
    }

    public class BubbleChartSerie
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int r { get; set; }
    }
}
