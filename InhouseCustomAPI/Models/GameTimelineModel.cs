using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InhouseCustomAPI.Models
{
    public class GameTimelineModel
    {
        public class Position
        {
            public Guid Id { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        
        public class _1
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _2
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _3
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _4
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _5
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _6
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _7
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _8
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _9
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class _10
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class ParticipantFrame
        {
            public Guid Id { get; set; }
            public int participantId { get; set; }
            public Position position { get; set; }
            public int currentGold { get; set; }
            public int totalGold { get; set; }
            public int level { get; set; }
            public int xp { get; set; }
            public int minionsKilled { get; set; }
            public int jungleMinionsKilled { get; set; }
            public int dominionScore { get; set; }
            public int teamScore { get; set; }
        }

        public class ParticipantFrames
        {
            public Guid Id { get; set; }
            [JsonProperty("1")]
            public _1 pf1 { get; set; }
            [JsonProperty("2")]
            public _2 pf2 { get; set; }
            [JsonProperty("3")]
            public _3 pf3 { get; set; }
            [JsonProperty("4")]
            public _4 pf4 { get; set; }
            [JsonProperty("5")]
            public _5 pf5 { get; set; }
            [JsonProperty("6")]
            public _6 pf6 { get; set; }
            [JsonProperty("7")]
            public _7 pf7 { get; set; }
            [JsonProperty("8")]
            public _8 pf8 { get; set; }
            [JsonProperty("9")]
            public _9 pf9 { get; set; }
            [JsonProperty("10")]
            public _10 pf10 { get; set; }
        }

        public class Event
        {
            public Guid Id { get; set; }
            public string type { get; set; }
            public int timestamp { get; set; }
            public int participantId { get; set; }
            public int itemId { get; set; }
            public int? skillSlot { get; set; }
            public string levelUpType { get; set; }
            public int? afterId { get; set; }
            public int? beforeId { get; set; }
            public string wardType { get; set; }
            public int? creatorId { get; set; }
            public Position position { get; set; }
            public int? killerId { get; set; }
            public int? victimId { get; set; }
            public List<AssistingParticipantIds> assistingParticipant { get; set; }

            [NotMapped]
            public List<int> assistingParticipantIds { get; set; }
            public string monsterType { get; set; }
            public string monsterSubType { get; set; }
            public int? teamId { get; set; }
            public string buildingType { get; set; }
            public string laneType { get; set; }
            public string towerType { get; set; }
        }

        public class AssistingParticipantIds
        {   
            public Guid Id { get; set; }
            public int participantId { get; set; }
        }

        public class Frame
        {
            public Guid Id { get; set; }
            public ParticipantFrames participantFrames { get; set; }

            [JsonIgnore]
            public List<ParticipantFrame> participantFramesList { get; set; }
            public List<Event> events { get; set; }
            public int timestamp { get; set; }
        }

        public class GameTimeline
        {
            public Guid Id { get; set; }
            public Guid gameId { get; set; }
            public List<Frame> frames { get; set; }
            public int frameInterval { get; set; }
        }
    }
}
