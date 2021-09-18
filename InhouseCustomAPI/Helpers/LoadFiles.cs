using InhouseCustomAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static InhouseCustomAPI.Models.GameDataModel;
using static InhouseCustomAPI.Models.GameTimelineModel;

namespace InhouseCustomAPI.Helpers
{
    public class LoadFiles
    {
        public static void LoadGameDataFile(string fileName)
        {
            var database = new GameDbContext();
            database.GameData.ToList();

            var s = System.IO.File.ReadAllText(fileName);
            GameData gamedata = JsonConvert.DeserializeObject<GameData>(s);

            // Does game.gamedata.gameid exist
            if(database.GameData.Where(x =>x.gameId == gamedata.gameId).ToList().Count() > 0)
            {
                return;
            }

            Game game = new()
            {
                GameData = gamedata,
                Id = Guid.NewGuid()
            };

            gamedata.Id = Guid.NewGuid();

            foreach (var team in gamedata.teams)
            {
                team.Id = Guid.NewGuid();
                foreach (var ban in team.bans)
                {
                    ban.Id = Guid.NewGuid();
                }
            }

            foreach (var participant in gamedata.participants)
            {
                participant.Id = Guid.NewGuid();
                participant.stats.Id = Guid.NewGuid();
                participant.timeline.Id = Guid.NewGuid();
                participant.timeline.creepsPerMinDeltas.Id = Guid.NewGuid();
                participant.timeline.xpPerMinDeltas.Id = Guid.NewGuid();
                participant.timeline.goldPerMinDeltas.Id = Guid.NewGuid();
                if (participant.timeline.csDiffPerMinDeltas != null)
                {
                    participant.timeline.csDiffPerMinDeltas.Id = Guid.NewGuid();
                }
                if (participant.timeline.xpDiffPerMinDeltas != null)
                {
                    participant.timeline.xpDiffPerMinDeltas.Id = Guid.NewGuid();
                }
                if (participant.timeline.damageTakenPerMinDeltas != null)
                {
                    participant.timeline.damageTakenPerMinDeltas.Id = Guid.NewGuid();
                }
                if (participant.timeline.damageTakenDiffPerMinDeltas != null)
                {
                    participant.timeline.damageTakenDiffPerMinDeltas.Id = Guid.NewGuid();
                }
            }

            foreach (var participant in gamedata.participantIdentities)
            {
                participant.Id = Guid.NewGuid();
            }

            database.Games.Add(game);
            database.SaveChanges();
        }

        public static void LoadGameTimelineFile(string fileName, long gameId)
        {
            var database = new GameDbContext();
            database.GameData.ToList();
            database.GameTimelines.ToList();
            var games = database.Games.ToList();

            Guid gameIdGuid = Guid.Empty;
            // Get gameId from gameDataId
            foreach (var game in games)
            {
                if (game.GameData.gameId == gameId)
                {
                    gameIdGuid = game.Id;
                }
            }

            if (gameIdGuid == Guid.Empty)
            {
                return;
            }

            // Does game.gamedata.gameid exist
            if (database.GameTimelines.Where(x => x.gameId == gameIdGuid).ToList().Count() > 0)
            {
                return;
            }

            var s = System.IO.File.ReadAllText(fileName);
            GameTimeline timeline = JsonConvert.DeserializeObject<GameTimeline>(s);
            timeline.gameId = gameIdGuid;
            timeline.Id = Guid.NewGuid();
            foreach (var frame in timeline.frames)
            {
                frame.Id = Guid.NewGuid();
                foreach (var e in frame.events)
                {
                    e.Id = Guid.NewGuid();
                    if (e.assistingParticipantIds != null)
                    {
                        e.assistingParticipant = new List<AssistingParticipantIds>();
                        foreach (var assisting in e.assistingParticipantIds)
                        {
                            e.assistingParticipant.Add(new AssistingParticipantIds { Id = Guid.NewGuid(), participantId = assisting });
                        }
                    }
                }

                // Look away
                frame.participantFramesList = new List<ParticipantFrame>();
                #region 
                ParticipantFrame pf1 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf1.participantId,
                    position = frame.participantFrames.pf1.position,
                    currentGold = frame.participantFrames.pf1.currentGold,
                    totalGold = frame.participantFrames.pf1.totalGold,
                    level = frame.participantFrames.pf1.level,
                    xp = frame.participantFrames.pf1.xp,
                    minionsKilled = frame.participantFrames.pf1.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf1.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf1.dominionScore,
                    teamScore = frame.participantFrames.pf1.teamScore
                };
                frame.participantFramesList.Add(pf1);

                ParticipantFrame pf2 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf2.participantId,
                    position = frame.participantFrames.pf2.position,
                    currentGold = frame.participantFrames.pf2.currentGold,
                    totalGold = frame.participantFrames.pf2.totalGold,
                    level = frame.participantFrames.pf2.level,
                    xp = frame.participantFrames.pf2.xp,
                    minionsKilled = frame.participantFrames.pf2.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf2.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf2.dominionScore,
                    teamScore = frame.participantFrames.pf2.teamScore
                };
                frame.participantFramesList.Add(pf2);

                ParticipantFrame pf3 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf3.participantId,
                    position = frame.participantFrames.pf3.position,
                    currentGold = frame.participantFrames.pf3.currentGold,
                    totalGold = frame.participantFrames.pf3.totalGold,
                    level = frame.participantFrames.pf3.level,
                    xp = frame.participantFrames.pf3.xp,
                    minionsKilled = frame.participantFrames.pf3.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf3.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf3.dominionScore,
                    teamScore = frame.participantFrames.pf3.teamScore
                };
                frame.participantFramesList.Add(pf3);

                ParticipantFrame pf4 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf4.participantId,
                    position = frame.participantFrames.pf4.position,
                    currentGold = frame.participantFrames.pf4.currentGold,
                    totalGold = frame.participantFrames.pf4.totalGold,
                    level = frame.participantFrames.pf4.level,
                    xp = frame.participantFrames.pf4.xp,
                    minionsKilled = frame.participantFrames.pf4.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf4.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf4.dominionScore,
                    teamScore = frame.participantFrames.pf4.teamScore
                };
                frame.participantFramesList.Add(pf4);

                ParticipantFrame pf5 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf5.participantId,
                    position = frame.participantFrames.pf5.position,
                    currentGold = frame.participantFrames.pf5.currentGold,
                    totalGold = frame.participantFrames.pf5.totalGold,
                    level = frame.participantFrames.pf5.level,
                    xp = frame.participantFrames.pf5.xp,
                    minionsKilled = frame.participantFrames.pf5.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf5.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf5.dominionScore,
                    teamScore = frame.participantFrames.pf5.teamScore
                };
                frame.participantFramesList.Add(pf5);

                ParticipantFrame pf6 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf6.participantId,
                    position = frame.participantFrames.pf6.position,
                    currentGold = frame.participantFrames.pf6.currentGold,
                    totalGold = frame.participantFrames.pf6.totalGold,
                    level = frame.participantFrames.pf6.level,
                    xp = frame.participantFrames.pf6.xp,
                    minionsKilled = frame.participantFrames.pf6.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf6.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf6.dominionScore,
                    teamScore = frame.participantFrames.pf6.teamScore
                };
                frame.participantFramesList.Add(pf6);

                ParticipantFrame pf7 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf7.participantId,
                    position = frame.participantFrames.pf7.position,
                    currentGold = frame.participantFrames.pf7.currentGold,
                    totalGold = frame.participantFrames.pf7.totalGold,
                    level = frame.participantFrames.pf7.level,
                    xp = frame.participantFrames.pf7.xp,
                    minionsKilled = frame.participantFrames.pf7.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf7.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf7.dominionScore,
                    teamScore = frame.participantFrames.pf7.teamScore
                };
                frame.participantFramesList.Add(pf7);

                ParticipantFrame pf8 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf8.participantId,
                    position = frame.participantFrames.pf8.position,
                    currentGold = frame.participantFrames.pf8.currentGold,
                    totalGold = frame.participantFrames.pf8.totalGold,
                    level = frame.participantFrames.pf8.level,
                    xp = frame.participantFrames.pf8.xp,
                    minionsKilled = frame.participantFrames.pf8.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf8.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf8.dominionScore,
                    teamScore = frame.participantFrames.pf8.teamScore
                };
                frame.participantFramesList.Add(pf8);

                ParticipantFrame pf9 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf9.participantId,
                    position = frame.participantFrames.pf9.position,
                    currentGold = frame.participantFrames.pf9.currentGold,
                    totalGold = frame.participantFrames.pf9.totalGold,
                    level = frame.participantFrames.pf9.level,
                    xp = frame.participantFrames.pf9.xp,
                    minionsKilled = frame.participantFrames.pf9.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf9.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf9.dominionScore,
                    teamScore = frame.participantFrames.pf9.teamScore
                };
                frame.participantFramesList.Add(pf9);

                ParticipantFrame pf10 = new ParticipantFrame
                {
                    Id = Guid.NewGuid(),
                    participantId = frame.participantFrames.pf10.participantId,
                    position = frame.participantFrames.pf10.position,
                    currentGold = frame.participantFrames.pf10.currentGold,
                    totalGold = frame.participantFrames.pf10.totalGold,
                    level = frame.participantFrames.pf10.level,
                    xp = frame.participantFrames.pf10.xp,
                    minionsKilled = frame.participantFrames.pf10.minionsKilled,
                    jungleMinionsKilled = frame.participantFrames.pf10.jungleMinionsKilled,
                    dominionScore = frame.participantFrames.pf10.dominionScore,
                    teamScore = frame.participantFrames.pf10.teamScore
                };
                frame.participantFramesList.Add(pf10);
                #endregion
            }

            database.GameTimelines.Add(timeline);
            database.SaveChanges();
        }


        public static void LoadGameDataString(string data)
        {
            var database = new GameDbContext();

            GameData gamedata = JsonConvert.DeserializeObject<GameData>(data);

            Game game = new()
            {
                GameData = gamedata,
                Id = Guid.NewGuid()
            };

            gamedata.Id = Guid.NewGuid();

            foreach (var team in gamedata.teams)
            {
                team.Id = Guid.NewGuid();
                foreach (var ban in team.bans)
                {
                    ban.Id = Guid.NewGuid();
                }
            }

            foreach (var participant in gamedata.participants)
            {
                participant.Id = Guid.NewGuid();
                participant.stats.Id = Guid.NewGuid();
                participant.timeline.Id = Guid.NewGuid();
                participant.timeline.creepsPerMinDeltas.Id = Guid.NewGuid();
                participant.timeline.xpPerMinDeltas.Id = Guid.NewGuid();
                participant.timeline.goldPerMinDeltas.Id = Guid.NewGuid();
                if (participant.timeline.csDiffPerMinDeltas != null)
                {
                    participant.timeline.csDiffPerMinDeltas.Id = Guid.NewGuid();
                }
                if (participant.timeline.xpDiffPerMinDeltas != null)
                {
                    participant.timeline.xpDiffPerMinDeltas.Id = Guid.NewGuid();
                }
                if (participant.timeline.damageTakenPerMinDeltas != null)
                {
                    participant.timeline.damageTakenPerMinDeltas.Id = Guid.NewGuid();
                }
                if (participant.timeline.damageTakenDiffPerMinDeltas != null)
                {
                    participant.timeline.damageTakenDiffPerMinDeltas.Id = Guid.NewGuid();
                }
            }

            foreach (var participant in gamedata.participantIdentities)
            {
                participant.Id = Guid.NewGuid();
            }

            database.Games.Add(game);
            database.SaveChanges();
        }

        public static void LoadGameTimelineString(string data, Guid gameId)
        {
            var database = new GameDbContext();
            GameTimeline timeline = JsonConvert.DeserializeObject<GameTimeline>(data);
            timeline.gameId = gameId;
            timeline.Id = Guid.NewGuid();
            foreach (var frame in timeline.frames)
            {
                frame.Id = Guid.NewGuid();
                foreach (var e in frame.events)
                {
                    e.Id = Guid.NewGuid();
                    if (e.assistingParticipantIds != null)
                    {
                        e.assistingParticipant = new List<AssistingParticipantIds>();
                        foreach (var assisting in e.assistingParticipantIds)
                        {
                            e.assistingParticipant.Add(new AssistingParticipantIds { Id = Guid.NewGuid(), participantId = assisting });
                        }
                    }

                }
            }

            database.GameTimelines.Add(timeline);
            database.SaveChanges();
        }
    }
}


/*
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('1', 'Annie');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('2', 'Olaf');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('3', 'Galio');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('4', 'TwistedFate');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('5', 'XinZhao');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('6', 'Urgot');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('7', 'Leblanc');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('8', 'Vladimir');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('9', 'Fiddlesticks');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('10', 'Kayle');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('11', 'MasterYi');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('12', 'Alistar');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('13', 'Ryze');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('14', 'Sion');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('15', 'Sivir');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('16', 'Soraka');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('17', 'Teemo');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('18', 'Tristana');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('19', 'Warwick');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('20', 'Nunu');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('21', 'MissFortune');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('22', 'Ashe');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('23', 'Tryndamere');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('24', 'Jax');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('25', 'Morgana');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('26', 'Zilean');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('27', 'Singed');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('28', 'Evelynn');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('29', 'Twitch');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('30', 'Karthus');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('31', 'Chogath');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('32', 'Amumu');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('33', 'Rammus');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('34', 'Anivia');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('35', 'Shaco');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('36', 'DrMundo');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('37', 'Sona');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('38', 'Kassadin');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('39', 'Irelia');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('40', 'Janna');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('41', 'Gangplank');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('42', 'Corki');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('43', 'Karma');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('44', 'Taric');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('45', 'Veigar');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('48', 'Trundle');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('50', 'Swain');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('51', 'Caitlyn');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('53', 'Blitzcrank');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('54', 'Malphite');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('55', 'Katarina');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('56', 'Nocturne');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('57', 'Maokai');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('58', 'Renekton');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('59', 'JarvanIV');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('60', 'Elise');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('61', 'Orianna');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('62', 'MonkeyKing');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('63', 'Brand');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('64', 'LeeSin');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('67', 'Vayne');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('68', 'Rumble');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('69', 'Cassiopeia');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('72', 'Skarner');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('74', 'Heimerdinger');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('75', 'Nasus');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('76', 'Nidalee');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('77', 'Udyr');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('78', 'Poppy');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('79', 'Gragas');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('80', 'Pantheon');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('81', 'Ezreal');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('82', 'Mordekaiser');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('83', 'Yorick');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('84', 'Akali');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('85', 'Kennen');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('86', 'Garen');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('89', 'Leona');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('90', 'Malzahar');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('91', 'Talon');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('92', 'Riven');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('96', 'KogMaw');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('98', 'Shen');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('99', 'Lux');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('101', 'Xerath');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('102', 'Shyvana');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('103', 'Ahri');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('104', 'Graves');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('105', 'Fizz');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('106', 'Volibear');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('107', 'Rengar');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('110', 'Varus');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('111', 'Nautilus');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('112', 'Viktor');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('113', 'Sejuani');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('114', 'Fiora');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('115', 'Ziggs');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('117', 'Lulu');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('119', 'Draven');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('120', 'Hecarim');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('121', 'Khazix');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('122', 'Darius');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('126', 'Jayce');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('127', 'Lissandra');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('131', 'Diana');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('133', 'Quinn');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('134', 'Syndra');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('136', 'AurelionSol');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('141', 'Kayn');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('142', 'Zoe');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('143', 'Zyra');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('145', 'Kaisa');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('147', 'Seraphine');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('150', 'Gnar');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('154', 'Zac');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('157', 'Yasuo');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('161', 'Velkoz');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('163', 'Taliyah');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('164', 'Camille');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('166', 'Akshan');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('201', 'Braum');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('202', 'Jhin');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('203', 'Kindred');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('222', 'Jinx');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('223', 'TahmKench');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('234', 'Viego');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('235', 'Senna');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('236', 'Lucian');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('238', 'Zed');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('240', 'Kled');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('245', 'Ekko');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('246', 'Qiyana');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('254', 'Vi');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('266', 'Aatrox');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('267', 'Nami');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('268', 'Azir');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('350', 'Yuumi');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('360', 'Samira');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('412', 'Thresh');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('420', 'Illaoi');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('421', 'RekSai');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('427', 'Ivern');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('429', 'Kalista');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('432', 'Bard');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('497', 'Rakan');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('498', 'Xayah');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('516', 'Ornn');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('517', 'Sylas');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('518', 'Neeko');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('523', 'Aphelios');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('526', 'Rell');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('555', 'Pyke');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('777', 'Yone');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('875', 'Sett');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('876', 'Lillia');
INSERT INTO "main"."Champs" ("Id", "Name") VALUES ('887', 'Gwen');
*/