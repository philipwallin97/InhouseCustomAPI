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
    public class PlayerController : Controller
    {
        private readonly GameDbContext database;

        public PlayerController()
        {
            database = new GameDbContext();
            database.GameData.ToList();
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
        }

        [HttpGet]
        [Route("GetPlayerBySummonerId")]
        public Player GetPlayerById(int summonerId)
        {
            return database.Players.Where(x => x.summonerId == summonerId).First();
        }

        [HttpGet]
        [Route("GetPlayerMostKills")]
        public StatObject GetPlayerMostKills(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            Participant mostKills = participants.First();
            foreach (var participant in participants)
            {
                if (participant.stats.kills > mostKills.stats.kills)
                {
                    mostKills = participant;
                }
            }

            StatObject playerStat = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = mostKills.stats.kills.ToString(),
                Stat2 = mostKills.championId.ToString()
            };
            return playerStat;
        }

        [HttpGet]
        [Route("GetPlayerMostDeaths")]
        public StatObject GetPlayerMostDeaths(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            Participant mostDeaths = participants.First();
            foreach (var participant in participants)
            {
                if (participant.stats.deaths > mostDeaths.stats.deaths)
                {
                    mostDeaths = participant;
                }
            }

            StatObject playerStat = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = mostDeaths.stats.deaths.ToString(),
                Stat2 = mostDeaths.championId.ToString()
            };
            return playerStat;
        }

        [HttpGet]
        [Route("GetPlayerMostAssists")]
        public StatObject GetPlayerMostAssists(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            Participant mostAssists = participants.First();
            foreach (var participant in participants)
            {
                if (participant.stats.assists > mostAssists.stats.assists)
                {
                    mostAssists = participant;
                }
            }

            StatObject playerStat = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = mostAssists.stats.assists.ToString(),
                Stat2 = mostAssists.championId.ToString()
            };
            return playerStat;
        }

        [HttpGet]
        [Route("GetPlayerMultipleKillStats")]
        public StatObject GetPlayerMultipleKillStats(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                        break;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            int doubleKills = 0;
            int tripleKills = 0;
            int quadraKills = 0;
            int pentaKills = 0;
            foreach (var participant in participants)
            {
                doubleKills += participant.stats.doubleKills;
                tripleKills += participant.stats.tripleKills;
                quadraKills += participant.stats.quadraKills;
                pentaKills += participant.stats.pentaKills;
            }
            StatObject playerStat = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = doubleKills.ToString(),
                Stat2 = tripleKills.ToString(),
                Stat3 = quadraKills.ToString(),
                Stat4 = pentaKills.ToString()
            };
            return playerStat;
        }

        [HttpGet]
        [Route("GetPlayerWinLosePercent")]
        public StatObject GetPlayerWinLosePercent(int summonerId)
        {
            int wins = 0;
            int losses = 0;

            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            foreach (var pa in participants)
            {
                if (pa.stats.win)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }


            StatObject playerStat = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = wins.ToString(),
                Stat2 = losses.ToString(),
                Stat3 = ((int)Math.Round((double)(100 * wins) / (wins + losses))).ToString()
            };

            return playerStat;
        }

        [HttpGet]
        [Route("GetPlayerAverageKDA")]
        public StatObject GetPlayerAverageKDA(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            int kills = 0;
            int deaths = 0;
            int assists = 0;
            foreach (var participant in participants)
            {
                kills += participant.stats.kills;
                deaths += participant.stats.deaths;
                assists += participant.stats.assists;
            }

            double averageKills = (double)kills / participants.Count;
            double averageDeaths = (double)deaths / participants.Count;
            double averageAssists = (double)assists / participants.Count;

            StatObject playerStat = new StatObject()
            {
                Id = Guid.NewGuid(),
                Stat = Math.Round((((double)kills + (double)assists) / (double)deaths), 2).ToString(),
                Stat2 = kills + "/" + deaths + "/" + assists
            };

            return playerStat;
        }

        [HttpGet]
        [Route("GetPlayerTeammateStats")]
        public List<TeammateStat> GetPlayerTeammateStats(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();
            var teammateStats = new List<TeammateStat>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            foreach (var game in games)
            {
                int parID = -1;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                        break;
                    }
                }

                int teamId = -1;
                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        teamId = par.teamId;
                        break;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.teamId == teamId)
                    {
                        foreach (var id in game.participantIdentities)
                        {
                            if (id.participantId == par.participantId && id.player.summonerId != summonerId)
                            {
                                var x = teammateStats.Where(x => x.summonerId == id.player.summonerId);
                                if (x.Count() == 0)
                                {
                                    var p = new TeammateStat();
                                    p.summonerId = id.player.summonerId;
                                    p.summonerName = id.player.summonerName;
                                    p.wins = 0;
                                    p.losses = 0;
                                    p.nrOfGames = 1;
                                    if (par.stats.win)
                                    {
                                        p.wins = 1;
                                    }
                                    else
                                    {
                                        p.losses = 1;
                                    }
                                    p.winPercent = Math.Round(((double)p.wins / (double)p.nrOfGames), 2);
                                    p.lossPercent = Math.Round(((double)p.losses / (double)p.nrOfGames), 2);
                                    teammateStats.Add(p);
                                }
                                else
                                {
                                    var xd = x.First();
                                    if (par.stats.win)
                                    {
                                        xd.wins++;
                                    }
                                    else
                                    {
                                        xd.losses++;
                                    }
                                    xd.nrOfGames++;
                                    xd.winPercent = Math.Round(((100 * (double)xd.wins) / (double)xd.nrOfGames), 2);
                                    xd.lossPercent = Math.Round(((100 * (double)xd.losses) / (double)xd.nrOfGames), 2);
                                }
                                break;
                            }
                        }
                    }
                }

            }

            teammateStats = teammateStats.OrderBy(x => x.winPercent).Reverse().ToList();
            return teammateStats;
        }

        [HttpGet]
        [Route("GetAllParticipantDataFromPlayer")]
        public List<Participant> GetAllParticipantDataFromPlayer(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }
            return participants;
        }

        [HttpGet]
        [Route("GetPlayerLaneStats")]
        public PlayerLaneStat GetPlayerLaneStats(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                        break;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            PlayerLaneStat pls = new PlayerLaneStat
            {
                damageTop = 0,
                gamesTop = 0,
                killsTop = 0,
                deathsTop = 0,
                assistsTop = 0,
                damageJungle = 0,
                gamesJungle = 0,
                killsJungle = 0,
                deathsJungle = 0,
                assistsJungle = 0,
                damageMid = 0,
                gamesMid = 0,
                killsMid = 0,
                deathsMid = 0,
                assistsMid = 0,
                damageBot = 0,
                gamesBot = 0,
                killsBot = 0,
                deathsBot = 0,
                assistsBot = 0,
                damageSupport = 0,
                gamesSupport = 0,
                killsSupport = 0,
                deathsSupport = 0,
                assistsSupport = 0
            };


            foreach (var p in participants)
            {
                if (p.timeline.role == "SOLO" && p.timeline.lane == "TOP")
                {
                    // Top
                    pls.gamesTop++;
                    pls.damageTop += p.stats.totalDamageDealtToChampions;
                    pls.killsTop += p.stats.kills;
                    pls.deathsTop += p.stats.deaths;
                    pls.assistsTop += p.stats.assists;
                }
                else if (p.timeline.role == "SOLO" && p.timeline.lane == "MIDDLE")
                {
                    // Mid
                    pls.gamesMid++;
                    pls.damageMid += p.stats.totalDamageDealtToChampions;
                    pls.killsMid += p.stats.kills;
                    pls.deathsMid += p.stats.deaths;
                    pls.assistsMid += p.stats.assists;
                }
                else if (p.timeline.role == "NONE" && p.timeline.lane == "JUNGLE")
                {
                    // Jungle
                    pls.gamesJungle++;
                    pls.damageJungle += p.stats.totalDamageDealtToChampions;
                    pls.killsJungle += p.stats.kills;
                    pls.deathsJungle += p.stats.deaths;
                    pls.assistsJungle += p.stats.assists;
                }
                else if (p.timeline.role == "DUO_CARRY" && p.timeline.lane == "BOTTOM")
                {
                    // Bot
                    pls.gamesBot++;
                    pls.damageBot += p.stats.totalDamageDealtToChampions;
                    pls.killsBot += p.stats.kills;
                    pls.deathsBot += p.stats.deaths;
                    pls.assistsBot += p.stats.assists;
                }
                else if (p.timeline.role == "DUO_SUPPORT" && p.timeline.lane == "BOTTOM")
                {
                    // Support
                    pls.gamesSupport++;
                    pls.damageSupport += p.stats.totalDamageDealtToChampions;
                    pls.killsSupport += p.stats.kills;
                    pls.deathsSupport += p.stats.deaths;
                    pls.assistsSupport += p.stats.assists;
                }


                else if (p.timeline.lane == "TOP")
                {
                    // Top
                    pls.gamesTop++;
                    pls.damageTop += p.stats.totalDamageDealtToChampions;
                    pls.killsTop += p.stats.kills;
                    pls.deathsTop += p.stats.deaths;
                    pls.assistsTop += p.stats.assists;
                }
                else if (p.timeline.role == "DUO_SUPPORT")
                {
                    // Support
                    pls.gamesSupport++;
                    pls.damageSupport += p.stats.totalDamageDealtToChampions;
                    pls.killsSupport += p.stats.kills;
                    pls.deathsSupport += p.stats.deaths;
                    pls.assistsSupport += p.stats.assists;
                }
                else if (p.timeline.lane == "MIDDLE")
                {
                    // Mid
                    pls.gamesMid++;
                    pls.damageMid += p.stats.totalDamageDealtToChampions;
                    pls.killsMid += p.stats.kills;
                    pls.deathsMid += p.stats.deaths;
                    pls.assistsMid += p.stats.assists;
                }
            }

            return pls;
        }

        [HttpGet]
        [Route("GetChampsStats")]
        public List<ChampStats> GetChampsStats(int summonerId)
        {
            List<ParticipantIdentity> partisipantIdentities = new List<ParticipantIdentity>();
            var players = database.Players.Where(x => x.summonerId == summonerId).ToList();

            foreach (var player in players)
            {
                partisipantIdentities.Add(database.ParticipantIdentity.Where(x => x.player.Id == player.Id).First());
            }

            var games = new List<GameData>();

            foreach (var partisipantIdentitie in partisipantIdentities)
            {
                games.Add(database.GameData.Where(x => x.participantIdentities.Contains(partisipantIdentitie)).First());
            }

            var participants = new List<Participant>();

            foreach (var game in games)
            {
                // Vilket participitan id har jag
                int parID = 0;
                foreach (var id in game.participantIdentities)
                {
                    if (id.player.summonerId == summonerId)
                    {
                        parID = id.participantId;
                        break;
                    }
                }

                foreach (var par in game.participants)
                {
                    if (par.participantId == parID)
                    {
                        participants.Add(par);
                    }
                }
            }

            List<ChampStats> champStats = new List<ChampStats>();

            foreach (var par in participants)
            {
                if (champStats.Where(c => c.champId == par.championId).Count() > 0)
                {
                    ChampStats cs = champStats.Where(c => c.champId == par.championId).First();
                    cs.nrOfTimes++;
                    cs.kills += par.stats.kills;
                    cs.deaths += par.stats.deaths;
                    cs.assists += par.stats.assists;

                    if (par.stats.win)
                    {
                        cs.wins += 1;
                    }
                    else
                    {
                        cs.losses += 1;
                    }

                    cs.winPercent = (int)Math.Round((double)(100 * cs.wins) / cs.nrOfTimes);
                    cs.averageKills = Math.Round( ((double)(cs.kills) / cs.nrOfTimes),2 );
                    cs.averageDeaths = Math.Round( ((double)(cs.deaths) / cs.nrOfTimes),2 );
                    cs.averageAssists = Math.Round( ((double)(cs.assists) / cs.nrOfTimes),2 );
                }
                else
                {
                    ChampStats cs = new ChampStats();
                    cs.champId = par.championId;
                    cs.nrOfTimes = 1;
                    cs.kills = par.stats.kills;
                    cs.deaths = par.stats.deaths;
                    cs.assists = par.stats.assists;

                    if (par.stats.win)
                    {
                        cs.losses = 0;
                        cs.wins = 1;
                    }
                    else
                    {
                        cs.losses = 1;
                        cs.wins = 0;
                    }
                    cs.winPercent = Math.Round((double)(100 * cs.wins) / cs.nrOfTimes);
                    cs.averageKills = Math.Round(((double)(cs.kills) / cs.nrOfTimes), 2);
                    cs.averageDeaths = Math.Round(((double)(cs.deaths) / cs.nrOfTimes), 2);
                    cs.averageAssists = Math.Round(((double)(cs.assists) / cs.nrOfTimes), 2);
                    champStats.Add(cs);
                }
            }

            // Order by win%
            champStats = champStats.OrderBy(x => x.winPercent).Reverse().ToList();

            return champStats;
        }
    }
}
