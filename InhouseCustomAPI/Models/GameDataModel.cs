using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InhouseCustomAPI.Models
{
    public class GameDataModel
    {
        public DbSet<Game> Games { get; set; }

        public class Ban
        {
            public Guid Id { get; set; }
            public int ChampionId { get; set; }
            public int PickTurn { get; set; }
        }

        public class Team
        {
            public Guid Id { get; set; }
            public int TeamId { get; set; }
            public string Win { get; set; }
            public bool FirstBlood { get; set; }
            public bool FirstTower { get; set; }
            public bool FirstInhibitor { get; set; }
            public bool FirstBaron { get; set; }
            public bool FirstDragon { get; set; }
            public bool FirstRiftHerald { get; set; }
            public int TowerKills { get; set; }
            public int InhibitorKills { get; set; }
            public int baronKills { get; set; }
            public int dragonKills { get; set; }
            public int vilemawKills { get; set; }
            public int riftHeraldKills { get; set; }
            public int dominionVictoryScore { get; set; }
            public virtual List<Ban> bans { get; set; }
        }

        public class Stats
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public bool win { get; set; }
            public int item0 { get; set; }
            public int item1 { get; set; }
            public int item2 { get; set; }
            public int item3 { get; set; }
            public int item4 { get; set; }
            public int item5 { get; set; }
            public int item6 { get; set; }
            public int kills { get; set; }
            public int deaths { get; set; }
            public int assists { get; set; }
            public int largestKillingSpree { get; set; }
            public int largestMultiKill { get; set; }
            public int killingSprees { get; set; }
            public int longestTimeSpentLiving { get; set; }
            public int doubleKills { get; set; }
            public int tripleKills { get; set; }
            public int quadraKills { get; set; }
            public int pentaKills { get; set; }
            public int unrealKills { get; set; }
            public int totalDamageDealt { get; set; }
            public int magicDamageDealt { get; set; }
            public int physicalDamageDealt { get; set; }
            public int trueDamageDealt { get; set; }
            public int largestCriticalStrike { get; set; }
            public int totalDamageDealtToChampions { get; set; }
            public int magicDamageDealtToChampions { get; set; }
            public int physicalDamageDealtToChampions { get; set; }
            public int trueDamageDealtToChampions { get; set; }
            public int totalHeal { get; set; }
            public int totalUnitsHealed { get; set; }
            public int damageSelfMitigated { get; set; }
            public int damageDealtToObjectives { get; set; }
            public int damageDealtToTurrets { get; set; }
            public int visionScore { get; set; }
            public int timeCCingOthers { get; set; }
            public int totalDamageTaken { get; set; }
            public int magicalDamageTaken { get; set; }
            public int physicalDamageTaken { get; set; }
            public int trueDamageTaken { get; set; }
            public int goldEarned { get; set; }
            public int goldSpent { get; set; }
            public int turretKills { get; set; }
            public int inhibitorKills { get; set; }
            public int totalMinionsKilled { get; set; }
            public int neutralMinionsKilled { get; set; }
            public int neutralMinionsKilledTeamJungle { get; set; }
            public int neutralMinionsKilledEnemyJungle { get; set; }
            public int totalTimeCrowdControlDealt { get; set; }
            public int champLevel { get; set; }
            public int visionWardsBoughtInGame { get; set; }
            public int sightWardsBoughtInGame { get; set; }
            public int wardsPlaced { get; set; }
            public int wardsKilled { get; set; }
            public bool firstBloodKill { get; set; }
            public bool firstBloodAssist { get; set; }
            public bool firstTowerKill { get; set; }
            public bool firstTowerAssist { get; set; }
            public bool firstInhibitorKill { get; set; }
            public bool firstInhibitorAssist { get; set; }
            public int combatPlayerScore { get; set; }
            public int objectivePlayerScore { get; set; }
            public int totalPlayerScore { get; set; }
            public int totalScoreRank { get; set; }
            public int playerScore0 { get; set; }
            public int playerScore1 { get; set; }
            public int playerScore2 { get; set; }
            public int playerScore3 { get; set; }
            public int playerScore4 { get; set; }
            public int playerScore5 { get; set; }
            public int playerScore6 { get; set; }
            public int playerScore7 { get; set; }
            public int playerScore8 { get; set; }
            public int playerScore9 { get; set; }
            public int perk0 { get; set; }
            public int perk0Var1 { get; set; }
            public int perk0Var2 { get; set; }
            public int perk0Var3 { get; set; }
            public int perk1 { get; set; }
            public int perk1Var1 { get; set; }
            public int perk1Var2 { get; set; }
            public int perk1Var3 { get; set; }
            public int perk2 { get; set; }
            public int perk2Var1 { get; set; }
            public int perk2Var2 { get; set; }
            public int perk2Var3 { get; set; }
            public int perk3 { get; set; }
            public int perk3Var1 { get; set; }
            public int perk3Var2 { get; set; }
            public int perk3Var3 { get; set; }
            public int perk4 { get; set; }
            public int perk4Var1 { get; set; }
            public int perk4Var2 { get; set; }
            public int perk4Var3 { get; set; }
            public int perk5 { get; set; }
            public int perk5Var1 { get; set; }
            public int perk5Var2 { get; set; }
            public int perk5Var3 { get; set; }
            public int perkPrimaryStyle { get; set; }
            public int perkSubStyle { get; set; }
            public int statPerk0 { get; set; }
            public int statPerk1 { get; set; }
            public int statPerk2 { get; set; }
        }

        public class CreepsPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class XpPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class GoldPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class CsDiffPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class XpDiffPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class DamageTakenPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class DamageTakenDiffPerMinDeltas
        {
            public Guid Id { get; set; }

            [JsonProperty("10-20")]
            public double _1020 { get; set; }

            [JsonProperty("0-10")]
            public double _010 { get; set; }

            [JsonProperty("30-end")]
            public double _30End { get; set; }

            [JsonProperty("20-30")]
            public double _2030 { get; set; }
        }

        public class Timeline
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public virtual CreepsPerMinDeltas creepsPerMinDeltas { get; set; }
            public virtual XpPerMinDeltas xpPerMinDeltas { get; set; }
            public virtual GoldPerMinDeltas goldPerMinDeltas { get; set; }
            public virtual CsDiffPerMinDeltas csDiffPerMinDeltas { get; set; }
            public virtual XpDiffPerMinDeltas xpDiffPerMinDeltas { get; set; }
            public virtual DamageTakenPerMinDeltas damageTakenPerMinDeltas { get; set; }
            public virtual DamageTakenDiffPerMinDeltas damageTakenDiffPerMinDeltas { get; set; }
            public string role { get; set; }
            public string lane { get; set; }
        }

        public class Participant
        {
            public Guid Id { get; set; }
            public Guid playerId { get; set; }
            public int participantId { get; set; }
            public int teamId { get; set; }
            public int championId { get; set; }
            public int spell1Id { get; set; }
            public int spell2Id { get; set; }
            public virtual Stats stats { get; set; }
            public virtual Timeline timeline { get; set; }
        }

        public class Player
        {
            public Guid Id { get; set; }
            public string platformId { get; set; }
            public long accountId { get; set; }
            public string summonerName { get; set; }
            public long summonerId { get; set; }
            public string currentPlatformId { get; set; }
            public long currentAccountId { get; set; }
            public string matchHistoryUri { get; set; }
            public int profileIcon { get; set; }
        }

        public class ParticipantIdentity
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Player player { get; set; }
        }

        public class GameData
        {
            public Guid Id { get; set; }
            public long gameId { get; set; }
            public string platformId { get; set; }
            public long gameCreation { get; set; }
            public int gameDuration { get; set; }
            public int queueId { get; set; }
            public int mapId { get; set; }
            public int seasonId { get; set; }
            public string gameVersion { get; set; }
            public string gameMode { get; set; }
            public string gameType { get; set; }
            public virtual List<Team> teams { get; set; }
            public virtual List<Participant> participants { get; set; }
            public virtual List<ParticipantIdentity> participantIdentities { get; set; }
        }

        public class Game
        {
            public Guid Id { get; set; }
            public virtual GameData GameData { get; set; }
        }

        public class LeaderboardChamp
        {
            public int champId { get; set; }
            public int nrOfTimes { get; set; }
        }

        public class PlayerLeaderboardStat
        {
            public Guid Id { get; set; }
            public long summonerId { get; set; }
            public int iconId { get; set; }
            public string ign { get; set; }
            public int kills { get; set; }
            public int deaths { get; set; }
            public int assists { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
            public double winPercent { get; set; }
            public double averageKDA { get; set; }
            public int mostPlayedChamp { get; set; }
        }

        public class PlayerLaneStat
        {
            public int damageTop { get; set; }
            public int gamesTop { get; set; }
            public int killsTop { get; set; }
            public int deathsTop { get; set; }
            public int assistsTop { get; set; }

            public int damageJungle { get; set; }
            public int gamesJungle { get; set; }
            public int killsJungle { get; set; }
            public int deathsJungle { get; set; }
            public int assistsJungle { get; set; }

            public int damageMid { get; set; }
            public int gamesMid { get; set; }
            public int killsMid { get; set; }
            public int deathsMid { get; set; }
            public int assistsMid { get; set; }

            public int damageBot { get; set; }
            public int gamesBot { get; set; }
            public int killsBot { get; set; }
            public int deathsBot { get; set; }
            public int assistsBot { get; set; }

            public int damageSupport { get; set; }
            public int gamesSupport { get; set; }
            public int killsSupport { get; set; }
            public int deathsSupport { get; set; }
            public int assistsSupport { get; set; }
        }

        public class ChampStats
        {
            public int champId { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
            public int nrOfTimes { get; set; }
            public int kills { get; set; }
            public double averageKills { get; set; }
            public int deaths { get; set; }
            public double averageDeaths { get; set; }
            public int assists { get; set; }
            public double averageAssists { get; set; }
            public double winPercent { get; set; }
        }
    }
}
