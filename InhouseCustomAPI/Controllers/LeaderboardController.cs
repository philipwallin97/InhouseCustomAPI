using InhouseCustomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InhouseCustomAPI.Models.GameDataModel;
using static InhouseCustomAPI.Models.GameDbContext;

namespace InhouseCustomAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : Controller
    {
        private readonly GameDbContext database;

        public LeaderboardController()
        {
            database = new GameDbContext();
            database.GameData.ToList();
            database.Team.ToList();
            database.Ban.ToList();
            database.ParticipantIdentity.ToList();
            database.Participant.ToList();
            database.Players.ToList();
            database.Stats.ToList();
            database.Timeline.ToList();
            database.CreepsPerMinDeltas.ToList();
            database.XpPerMinDeltas.ToList();
            database.GoldPerMinDeltas.ToList();
            database.CsDiffPerMinDeltas.ToList();
            database.XpDiffPerMinDeltas.ToList();
            database.DamageTakenPerMinDeltas.ToList();
            database.DamageTakenDiffPerMinDeltas.ToList();

            database.Frames.ToList();
            database.Events.ToList();
            database.Positions.ToList();
            database.ParticipantFrame.ToList();
        }

        [HttpGet]
        [Route("GetLeaderboardStats")]
        public List<PlayerLeaderboardStat> GetLeaderboardStats()
        {
            List<PlayerLeaderboardStat> leaderboardStats = new List<PlayerLeaderboardStat>();
            var qniquePlayers = database.Players.ToList().GroupBy(elem => elem.summonerId).Select(group => group.First()).ToList();


            foreach (var p in qniquePlayers)
            {
                List<ParticipantIdentity> partisipantIdentities = database.ParticipantIdentity.Where(x => x.player.summonerId == p.summonerId).ToList();

                var games = new List<GameData>();
                

                foreach (var partisipantIdentitie in partisipantIdentities)
                {
                    games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
                }

                PlayerLeaderboardStat pls = new PlayerLeaderboardStat();
                List<LeaderboardChamp> lcs = new List<LeaderboardChamp>();

                pls.Id = Guid.NewGuid();
                pls.summonerId = p.summonerId;
                pls.ign = p.summonerName;
                pls.iconId = p.profileIcon;


                foreach (var game in games)
                {
                    int parID = 0;
                    foreach (var id in game.participantIdentities)
                    {
                        if (id.player.summonerId == p.summonerId)
                        {
                            parID = id.participantId;
                        }
                    }

                    foreach (var par in game.participants)
                    {
                        if (par.participantId == parID)
                        {
                            pls.kills += par.stats.kills;
                            pls.deaths += par.stats.deaths;
                            pls.assists += par.stats.assists;
                            if (par.stats.win)
                            {
                                pls.wins++;
                            }
                            else
                            {
                                pls.losses++;
                            }

                            if (lcs.Where(c => c.champId == par.championId).Count() > 0)
                            {
                                LeaderboardChamp dd = lcs.Where(c => c.champId == par.championId).First();
                                dd.nrOfTimes++;
                            }
                            else
                            {
                                LeaderboardChamp xc = new LeaderboardChamp
                                {
                                    champId = par.championId,
                                    nrOfTimes = 1
                                };
                                lcs.Add(xc);
                            }
                        }
                    }
                }
                var sortedLcs = lcs.OrderBy(x => x.nrOfTimes).Reverse();
                pls.winPercent = (int)Math.Round((double)(100 * pls.wins) / (pls.wins + pls.losses));
                pls.averageKDA = Math.Round((((double)pls.kills + (double)pls.assists) / (double)pls.deaths), 2);
                pls.mostPlayedChamp = sortedLcs.First().champId;
                leaderboardStats.Add(pls);
            }

            leaderboardStats = leaderboardStats.OrderBy(x => x.winPercent).Reverse().ToList();
            return leaderboardStats;

        }

        [HttpGet]
        [Route("GetNumberOfGamesAndDates")]
        public StatObject GetNumberOfGamesAndDates()
        {
            var startdate = database.GameData.First().gameCreation;
            var endDate = database.GameData.First().gameCreation;

            foreach (var game in database.GameData.ToList())
            {
                if (game.gameCreation < startdate)
                {
                    startdate = game.gameCreation;
                }
                if (game.gameCreation > endDate)
                {
                    endDate = game.gameCreation;
                }
            }


            StatObject stats = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = database.Games.Count().ToString(),
                Stat2 = startdate.ToString(),
                Stat3 = endDate.ToString()
            };
            return stats;
        }

        [HttpGet]
        [Route("GetPlayerWithMostDeaths")]
        public StatObject GetPlayerWithMostDeaths()
        {
            var games = database.Games.ToList();

            int mostDeaths = 0;
            int champ = 0;
            long summonerId = 0;
            string summonerName = "";
            
            foreach (var game in games)
            {
                foreach (var par in game.GameData.participants)
                {
                    if (par.stats.deaths > mostDeaths)
                    {
                        mostDeaths = par.stats.deaths;
                        champ = par.championId;

                        foreach (var id in game.GameData.participantIdentities)
                        {
                            if (id.participantId == par.participantId)
                            {
                                summonerId = id.player.summonerId;
                                summonerName = id.player.summonerName;
                            }
                        }

                    }
                }
            }

            StatObject stats = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = mostDeaths.ToString(),
                Stat2 = champ.ToString(),
                Stat3 = summonerId.ToString(),
                Stat4 = summonerName            
            };
            return stats;

        }

        [HttpGet]
        [Route("GetPlayerWithMostKills")]
        public StatObject GetPlayerWithMostKills()
        {
            var games = database.Games.ToList();

            int mostKills = 0;
            int champ = 0;
            long summonerId = 0;
            string summonerName = "";

            foreach (var game in games)
            {
                foreach (var par in game.GameData.participants)
                {
                    if (par.stats.kills > mostKills)
                    {
                        mostKills = par.stats.kills;
                        champ = par.championId;

                        foreach (var id in game.GameData.participantIdentities)
                        {
                            if (id.participantId == par.participantId)
                            {
                                summonerId = id.player.summonerId;
                                summonerName = id.player.summonerName;
                            }
                        }

                    }
                }
            }

            StatObject stats = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = mostKills.ToString(),
                Stat2 = champ.ToString(),
                Stat3 = summonerId.ToString(),
                Stat4 = summonerName
            };
            return stats;

        }

        [HttpGet]
        [Route("GetPlayerWithMostAssists")]
        public StatObject GetPlayerWithMostAssists()
        {
            var games = database.Games.ToList();

            int mostAssists = 0;
            int champ = 0;
            long summonerId = 0;
            string summonerName = "";

            foreach (var game in games)
            {
                foreach (var par in game.GameData.participants)
                {
                    if (par.stats.assists > mostAssists)
                    {
                        mostAssists = par.stats.assists;
                        champ = par.championId;

                        foreach (var id in game.GameData.participantIdentities)
                        {
                            if (id.participantId == par.participantId)
                            {
                                summonerId = id.player.summonerId;
                                summonerName = id.player.summonerName;
                            }
                        }

                    }
                }
            }

            StatObject stats = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = mostAssists.ToString(),
                Stat2 = champ.ToString(),
                Stat3 = summonerId.ToString(),
                Stat4 = summonerName
            };
            return stats;

        }

        [HttpGet]
        [Route("GetMostBannedChamps")]
        public List<ChampFrequency> GetMostBannedChamps(int nrOfResults)
        {
            var games = database.Games.ToList();

            List<ChampFrequency> bannedChamps = new List<ChampFrequency>();

            foreach (var game in games)
            {
                foreach (var team in game.GameData.teams)
                {
                    foreach (var ban in team.bans)
                    {
                        var x = bannedChamps.Where(x => x.champId == ban.ChampionId);
                        if (x.Count() == 0)
                        {
                            var bannedChamp = new ChampFrequency
                            {
                                champId = ban.ChampionId,
                                value = 1
                            };
                            bannedChamps.Add(bannedChamp);
                        }
                        else
                        {
                            var xd = x.First();
                            xd.value++;
                        }
                    }
                }
            }

            bannedChamps = bannedChamps.OrderBy(x=>x.value).Reverse().ToList();

            return bannedChamps.Take(nrOfResults).ToList();

        }

        [HttpGet]
        [Route("GetMostPickedChamps")]
        public List<ChampFrequency> GetMostPickedChamps(int nrOfResults)
        {
            var games = database.Games.ToList();

            List<ChampFrequency> pickedChamps = new List<ChampFrequency>();

            foreach (var game in games)
            {
                foreach (var par in game.GameData.participants)
                {
                    var x = pickedChamps.Where(x => x.champId == par.championId);
                    if (x.Count() == 0)
                    {
                        var pickedChamp = new ChampFrequency
                        {
                            champId = par.championId,
                            value = 1
                        };
                        pickedChamps.Add(pickedChamp);
                    }
                    else
                    {
                        var xd = x.First();
                        xd.value++;
                    }
                }
            }

            pickedChamps = pickedChamps.OrderBy(x => x.value).Reverse().ToList();

            return pickedChamps.Take(nrOfResults).ToList();
        }

        [HttpGet]
        [Route("GetMostFirstBlooded")]
        public List<SummonerFrequency> GetMostFirstBlodded(int nrOfResults)
        {
            var timelines = database.GameTimelines.ToList();
            var games = database.Games.ToList();

            List<SummonerFrequency> summonerFrequencys = new List<SummonerFrequency>();

            bool foundStatInGame = false;

            foreach (var timeline in timelines)
            {
                var game = games.Where(x => x.Id == timeline.gameId).First();
                foundStatInGame = false;
                foreach (var frame in timeline.frames)
                {
                    if (frame.events != null && !foundStatInGame)
                    {
                        foreach (var ev in frame.events)
                        {
                            if (ev.type == "CHAMPION_KILL")
                            {
                                foreach (var par in game.GameData.participantIdentities)
                                {
                                    if (par.participantId == ev.victimId)
                                    {
                                        var x = summonerFrequencys.Where(x => x.summonerId == par.player.summonerId);
                                        if (!x.Any())
                                        {
                                            SummonerFrequency summonerFrequency = new SummonerFrequency
                                            {
                                                summonerId = par.player.summonerId,
                                                profileIcon = par.player.profileIcon,
                                                summonerName = par.player.summonerName,
                                                value = 1
                                            };
                                            summonerFrequencys.Add(summonerFrequency);
                                        }
                                        else
                                        {
                                            var xd = x.First();
                                            xd.value++;
                                        }
                                    }
                                }
                                foundStatInGame = true;
                                break;
                            }
                        }
                    }
                }
            }
            return summonerFrequencys.OrderBy(x => x.value).Reverse().ToList().Take(nrOfResults).ToList();

        }

        [HttpGet]
        [Route("GetMostFirstBloods")]
        public List<SummonerFrequency> GetMostFirstBloods(int nrOfResults)
        {
            var timelines = database.GameTimelines.ToList();
            var games = database.Games.ToList();

            List<SummonerFrequency> summonerFrequencys = new List<SummonerFrequency>();

            bool foundStatInGame = false;

            foreach (var timeline in timelines)
            {
                var game = games.Where(x => x.Id == timeline.gameId).First();
                foundStatInGame = false;
                foreach (var frame in timeline.frames)
                {
                    if (frame.events != null && !foundStatInGame)
                    {
                        foreach (var ev in frame.events)
                        {
                            if (ev.type == "CHAMPION_KILL")
                            {
                                foreach (var par in game.GameData.participantIdentities)
                                {
                                    if (par.participantId == ev.killerId)
                                    {
                                        var x = summonerFrequencys.Where(x => x.summonerId == par.player.summonerId);
                                        if (!x.Any())
                                        {
                                            SummonerFrequency summonerFrequency = new SummonerFrequency
                                            {
                                                summonerId = par.player.summonerId,
                                                profileIcon = par.player.profileIcon,
                                                summonerName = par.player.summonerName,
                                                value = 1
                                            };
                                            summonerFrequencys.Add(summonerFrequency);
                                        }
                                        else
                                        {
                                            var xd = x.First();
                                            xd.value++;
                                        }
                                    }
                                }
                                foundStatInGame = true;
                                break;
                            }
                        }
                    }
                }
            }

            return summonerFrequencys.OrderBy(x => x.value).Reverse().ToList().Take(nrOfResults).ToList();
        }
    }
}
