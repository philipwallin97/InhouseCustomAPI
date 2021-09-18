using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InhouseCustomAPI.Models.GameDataModel;
using static InhouseCustomAPI.Models.GameTimelineModel;

namespace InhouseCustomAPI.Models
{
    public class GameDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=inhouse.db");

        public DbSet<Champ> Champs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Ban> Ban { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<CreepsPerMinDeltas> CreepsPerMinDeltas { get; set; }
        public DbSet<XpPerMinDeltas> XpPerMinDeltas { get; set; }
        public DbSet<GoldPerMinDeltas> GoldPerMinDeltas { get; set; }
        public DbSet<CsDiffPerMinDeltas> CsDiffPerMinDeltas { get; set; }
        public DbSet<XpDiffPerMinDeltas> XpDiffPerMinDeltas { get; set; }
        public DbSet<DamageTakenPerMinDeltas> DamageTakenPerMinDeltas { get; set; }
        public DbSet<DamageTakenDiffPerMinDeltas> DamageTakenDiffPerMinDeltas { get; set; }
        public DbSet<Timeline> Timeline { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<ParticipantIdentity> ParticipantIdentity { get; set; }
        public DbSet<GameData> GameData { get; set; }
        public DbSet<GameTimeline> GameTimelines { get; set; }
        public DbSet<StatObject> StatObjects { get; set; }
        public DbSet<PlayerLeaderboardStat> PlayerLeaderboardStats { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ParticipantFrame> ParticipantFrame { get; set; }
        public DbSet<ParticipantFrames> ParticipantFrames { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<AssistingParticipantIds> AssistingParticipantIds { get; set; }
        public DbSet<Frame> Frames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(m => m.Id);

            base.OnModelCreating(modelBuilder);
        }

        public class Champ
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class StatObject
        {
            public Guid Id { get; set; }
            public string Stat { get; set; }
            public string Stat2 { get; set; }
            public string Stat3 { get; set; }
            public string Stat4 { get; set; }
            public string Stat5 { get; set; }
        }

        public class TeammateStat
        {
            public long summonerId { get; set; }
            public string summonerName { get; set; }
            public int wins { get; set; }
            public double winPercent { get; set; }
            public int losses { get; set; }
            public double lossPercent { get; set; }
            public int nrOfGames { get; set; }
        }

        public class GraphData
        {
            public string name { get; set; }
            public double value { get; set; }
        }

        public class GraphColor
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Graph
        {
            public List<GraphData> data { get; set; }
            public List<GraphColor> colors { get; set; }
        }

        public class ChampFrequency
        {
            public int champId { get; set; }
            public int value { get; set; }
        }

        public class SummonerFrequency
        {
            public long summonerId { get; set; }
            public string summonerName { get; set; }
            public int profileIcon { get; set; }
            public int value { get; set; }
        }
    }
}
