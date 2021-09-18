using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InhouseCustomAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreepsPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreepsPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CsDiffPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsDiffPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageTakenDiffPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTakenDiffPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageTakenPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTakenPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    gameId = table.Column<long>(type: "INTEGER", nullable: false),
                    platformId = table.Column<string>(type: "TEXT", nullable: true),
                    gameCreation = table.Column<long>(type: "INTEGER", nullable: false),
                    gameDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    queueId = table.Column<int>(type: "INTEGER", nullable: false),
                    mapId = table.Column<int>(type: "INTEGER", nullable: false),
                    seasonId = table.Column<int>(type: "INTEGER", nullable: false),
                    gameVersion = table.Column<string>(type: "TEXT", nullable: true),
                    gameMode = table.Column<string>(type: "TEXT", nullable: true),
                    gameType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTimelines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    gameId = table.Column<Guid>(type: "TEXT", nullable: false),
                    frameInterval = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTimelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoldPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerLeaderboardStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    summonerId = table.Column<long>(type: "INTEGER", nullable: false),
                    iconId = table.Column<int>(type: "INTEGER", nullable: false),
                    ign = table.Column<string>(type: "TEXT", nullable: true),
                    kills = table.Column<int>(type: "INTEGER", nullable: false),
                    deaths = table.Column<int>(type: "INTEGER", nullable: false),
                    assists = table.Column<int>(type: "INTEGER", nullable: false),
                    wins = table.Column<int>(type: "INTEGER", nullable: false),
                    losses = table.Column<int>(type: "INTEGER", nullable: false),
                    winPercent = table.Column<double>(type: "REAL", nullable: false),
                    averageKDA = table.Column<double>(type: "REAL", nullable: false),
                    mostPlayedChamp = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLeaderboardStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    platformId = table.Column<string>(type: "TEXT", nullable: true),
                    accountId = table.Column<long>(type: "INTEGER", nullable: false),
                    summonerName = table.Column<string>(type: "TEXT", nullable: true),
                    summonerId = table.Column<long>(type: "INTEGER", nullable: false),
                    currentPlatformId = table.Column<string>(type: "TEXT", nullable: true),
                    currentAccountId = table.Column<long>(type: "INTEGER", nullable: false),
                    matchHistoryUri = table.Column<string>(type: "TEXT", nullable: true),
                    profileIcon = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    x = table.Column<int>(type: "INTEGER", nullable: false),
                    y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Stat = table.Column<string>(type: "TEXT", nullable: true),
                    Stat2 = table.Column<string>(type: "TEXT", nullable: true),
                    Stat3 = table.Column<string>(type: "TEXT", nullable: true),
                    Stat4 = table.Column<string>(type: "TEXT", nullable: true),
                    Stat5 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    win = table.Column<bool>(type: "INTEGER", nullable: false),
                    item0 = table.Column<int>(type: "INTEGER", nullable: false),
                    item1 = table.Column<int>(type: "INTEGER", nullable: false),
                    item2 = table.Column<int>(type: "INTEGER", nullable: false),
                    item3 = table.Column<int>(type: "INTEGER", nullable: false),
                    item4 = table.Column<int>(type: "INTEGER", nullable: false),
                    item5 = table.Column<int>(type: "INTEGER", nullable: false),
                    item6 = table.Column<int>(type: "INTEGER", nullable: false),
                    kills = table.Column<int>(type: "INTEGER", nullable: false),
                    deaths = table.Column<int>(type: "INTEGER", nullable: false),
                    assists = table.Column<int>(type: "INTEGER", nullable: false),
                    largestKillingSpree = table.Column<int>(type: "INTEGER", nullable: false),
                    largestMultiKill = table.Column<int>(type: "INTEGER", nullable: false),
                    killingSprees = table.Column<int>(type: "INTEGER", nullable: false),
                    longestTimeSpentLiving = table.Column<int>(type: "INTEGER", nullable: false),
                    doubleKills = table.Column<int>(type: "INTEGER", nullable: false),
                    tripleKills = table.Column<int>(type: "INTEGER", nullable: false),
                    quadraKills = table.Column<int>(type: "INTEGER", nullable: false),
                    pentaKills = table.Column<int>(type: "INTEGER", nullable: false),
                    unrealKills = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDamageDealt = table.Column<int>(type: "INTEGER", nullable: false),
                    magicDamageDealt = table.Column<int>(type: "INTEGER", nullable: false),
                    physicalDamageDealt = table.Column<int>(type: "INTEGER", nullable: false),
                    trueDamageDealt = table.Column<int>(type: "INTEGER", nullable: false),
                    largestCriticalStrike = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDamageDealtToChampions = table.Column<int>(type: "INTEGER", nullable: false),
                    magicDamageDealtToChampions = table.Column<int>(type: "INTEGER", nullable: false),
                    physicalDamageDealtToChampions = table.Column<int>(type: "INTEGER", nullable: false),
                    trueDamageDealtToChampions = table.Column<int>(type: "INTEGER", nullable: false),
                    totalHeal = table.Column<int>(type: "INTEGER", nullable: false),
                    totalUnitsHealed = table.Column<int>(type: "INTEGER", nullable: false),
                    damageSelfMitigated = table.Column<int>(type: "INTEGER", nullable: false),
                    damageDealtToObjectives = table.Column<int>(type: "INTEGER", nullable: false),
                    damageDealtToTurrets = table.Column<int>(type: "INTEGER", nullable: false),
                    visionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    timeCCingOthers = table.Column<int>(type: "INTEGER", nullable: false),
                    totalDamageTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    magicalDamageTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    physicalDamageTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    trueDamageTaken = table.Column<int>(type: "INTEGER", nullable: false),
                    goldEarned = table.Column<int>(type: "INTEGER", nullable: false),
                    goldSpent = table.Column<int>(type: "INTEGER", nullable: false),
                    turretKills = table.Column<int>(type: "INTEGER", nullable: false),
                    inhibitorKills = table.Column<int>(type: "INTEGER", nullable: false),
                    totalMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    neutralMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    neutralMinionsKilledTeamJungle = table.Column<int>(type: "INTEGER", nullable: false),
                    neutralMinionsKilledEnemyJungle = table.Column<int>(type: "INTEGER", nullable: false),
                    totalTimeCrowdControlDealt = table.Column<int>(type: "INTEGER", nullable: false),
                    champLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    visionWardsBoughtInGame = table.Column<int>(type: "INTEGER", nullable: false),
                    sightWardsBoughtInGame = table.Column<int>(type: "INTEGER", nullable: false),
                    wardsPlaced = table.Column<int>(type: "INTEGER", nullable: false),
                    wardsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    firstBloodKill = table.Column<bool>(type: "INTEGER", nullable: false),
                    firstBloodAssist = table.Column<bool>(type: "INTEGER", nullable: false),
                    firstTowerKill = table.Column<bool>(type: "INTEGER", nullable: false),
                    firstTowerAssist = table.Column<bool>(type: "INTEGER", nullable: false),
                    firstInhibitorKill = table.Column<bool>(type: "INTEGER", nullable: false),
                    firstInhibitorAssist = table.Column<bool>(type: "INTEGER", nullable: false),
                    combatPlayerScore = table.Column<int>(type: "INTEGER", nullable: false),
                    objectivePlayerScore = table.Column<int>(type: "INTEGER", nullable: false),
                    totalPlayerScore = table.Column<int>(type: "INTEGER", nullable: false),
                    totalScoreRank = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore0 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore1 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore2 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore3 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore4 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore5 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore6 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore7 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore8 = table.Column<int>(type: "INTEGER", nullable: false),
                    playerScore9 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk0 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk0Var1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk0Var2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk0Var3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk1Var1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk1Var2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk1Var3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk2Var1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk2Var2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk2Var3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk3Var1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk3Var2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk3Var3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk4 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk4Var1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk4Var2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk4Var3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk5 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk5Var1 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk5Var2 = table.Column<int>(type: "INTEGER", nullable: false),
                    perk5Var3 = table.Column<int>(type: "INTEGER", nullable: false),
                    perkPrimaryStyle = table.Column<int>(type: "INTEGER", nullable: false),
                    perkSubStyle = table.Column<int>(type: "INTEGER", nullable: false),
                    statPerk0 = table.Column<int>(type: "INTEGER", nullable: false),
                    statPerk1 = table.Column<int>(type: "INTEGER", nullable: false),
                    statPerk2 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XpDiffPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XpDiffPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XpPerMinDeltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    _1020 = table.Column<double>(type: "REAL", nullable: false),
                    _010 = table.Column<double>(type: "REAL", nullable: false),
                    _30End = table.Column<double>(type: "REAL", nullable: false),
                    _2030 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XpPerMinDeltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameDataId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameData_GameDataId",
                        column: x => x.GameDataId,
                        principalTable: "GameData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Win = table.Column<string>(type: "TEXT", nullable: true),
                    FirstBlood = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstTower = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstInhibitor = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstBaron = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstDragon = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstRiftHerald = table.Column<bool>(type: "INTEGER", nullable: false),
                    TowerKills = table.Column<int>(type: "INTEGER", nullable: false),
                    InhibitorKills = table.Column<int>(type: "INTEGER", nullable: false),
                    baronKills = table.Column<int>(type: "INTEGER", nullable: false),
                    dragonKills = table.Column<int>(type: "INTEGER", nullable: false),
                    vilemawKills = table.Column<int>(type: "INTEGER", nullable: false),
                    riftHeraldKills = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionVictoryScore = table.Column<int>(type: "INTEGER", nullable: false),
                    GameDataId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_GameData_GameDataId",
                        column: x => x.GameDataId,
                        principalTable: "GameData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantIdentity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    playerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GameDataId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantIdentity_GameData_GameDataId",
                        column: x => x.GameDataId,
                        principalTable: "GameData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantIdentity_Players_playerId",
                        column: x => x.playerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_1",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__1_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_10",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__10", x => x.Id);
                    table.ForeignKey(
                        name: "FK__10_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_2",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__2", x => x.Id);
                    table.ForeignKey(
                        name: "FK__2_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_3",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__3", x => x.Id);
                    table.ForeignKey(
                        name: "FK__3_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_4",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__4_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_5",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__5_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_6",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__6", x => x.Id);
                    table.ForeignKey(
                        name: "FK__6_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_7",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__7", x => x.Id);
                    table.ForeignKey(
                        name: "FK__7_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_8",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__8_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "_9",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__9_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timeline",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    creepsPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    xpPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    goldPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    csDiffPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    xpDiffPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    damageTakenPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    damageTakenDiffPerMinDeltasId = table.Column<Guid>(type: "TEXT", nullable: true),
                    role = table.Column<string>(type: "TEXT", nullable: true),
                    lane = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timeline_CreepsPerMinDeltas_creepsPerMinDeltasId",
                        column: x => x.creepsPerMinDeltasId,
                        principalTable: "CreepsPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timeline_CsDiffPerMinDeltas_csDiffPerMinDeltasId",
                        column: x => x.csDiffPerMinDeltasId,
                        principalTable: "CsDiffPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timeline_DamageTakenDiffPerMinDeltas_damageTakenDiffPerMinDeltasId",
                        column: x => x.damageTakenDiffPerMinDeltasId,
                        principalTable: "DamageTakenDiffPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timeline_DamageTakenPerMinDeltas_damageTakenPerMinDeltasId",
                        column: x => x.damageTakenPerMinDeltasId,
                        principalTable: "DamageTakenPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timeline_GoldPerMinDeltas_goldPerMinDeltasId",
                        column: x => x.goldPerMinDeltasId,
                        principalTable: "GoldPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timeline_XpDiffPerMinDeltas_xpDiffPerMinDeltasId",
                        column: x => x.xpDiffPerMinDeltasId,
                        principalTable: "XpDiffPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timeline_XpPerMinDeltas_xpPerMinDeltasId",
                        column: x => x.xpPerMinDeltasId,
                        principalTable: "XpPerMinDeltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ban",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChampionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PickTurn = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ban", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ban_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantFrames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    pf1Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf2Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf3Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf4Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf5Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf6Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf7Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf8Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf9Id = table.Column<Guid>(type: "TEXT", nullable: true),
                    pf10Id = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantFrames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__1_pf1Id",
                        column: x => x.pf1Id,
                        principalTable: "_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__10_pf10Id",
                        column: x => x.pf10Id,
                        principalTable: "_10",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__2_pf2Id",
                        column: x => x.pf2Id,
                        principalTable: "_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__3_pf3Id",
                        column: x => x.pf3Id,
                        principalTable: "_3",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__4_pf4Id",
                        column: x => x.pf4Id,
                        principalTable: "_4",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__5_pf5Id",
                        column: x => x.pf5Id,
                        principalTable: "_5",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__6_pf6Id",
                        column: x => x.pf6Id,
                        principalTable: "_6",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__7_pf7Id",
                        column: x => x.pf7Id,
                        principalTable: "_7",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__8_pf8Id",
                        column: x => x.pf8Id,
                        principalTable: "_8",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrames__9_pf9Id",
                        column: x => x.pf9Id,
                        principalTable: "_9",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    playerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    teamId = table.Column<int>(type: "INTEGER", nullable: false),
                    championId = table.Column<int>(type: "INTEGER", nullable: false),
                    spell1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    spell2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    statsId = table.Column<Guid>(type: "TEXT", nullable: true),
                    timelineId = table.Column<Guid>(type: "TEXT", nullable: true),
                    GameDataId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_GameData_GameDataId",
                        column: x => x.GameDataId,
                        principalTable: "GameData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_Stats_statsId",
                        column: x => x.statsId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participant_Timeline_timelineId",
                        column: x => x.timelineId,
                        principalTable: "Timeline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantFramesId = table.Column<Guid>(type: "TEXT", nullable: true),
                    timestamp = table.Column<int>(type: "INTEGER", nullable: false),
                    GameTimelineId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frames_GameTimelines_GameTimelineId",
                        column: x => x.GameTimelineId,
                        principalTable: "GameTimelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Frames_ParticipantFrames_participantFramesId",
                        column: x => x.participantFramesId,
                        principalTable: "ParticipantFrames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    timestamp = table.Column<int>(type: "INTEGER", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    itemId = table.Column<int>(type: "INTEGER", nullable: false),
                    skillSlot = table.Column<int>(type: "INTEGER", nullable: true),
                    levelUpType = table.Column<string>(type: "TEXT", nullable: true),
                    afterId = table.Column<int>(type: "INTEGER", nullable: true),
                    beforeId = table.Column<int>(type: "INTEGER", nullable: true),
                    wardType = table.Column<string>(type: "TEXT", nullable: true),
                    creatorId = table.Column<int>(type: "INTEGER", nullable: true),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    killerId = table.Column<int>(type: "INTEGER", nullable: true),
                    victimId = table.Column<int>(type: "INTEGER", nullable: true),
                    monsterType = table.Column<string>(type: "TEXT", nullable: true),
                    monsterSubType = table.Column<string>(type: "TEXT", nullable: true),
                    teamId = table.Column<int>(type: "INTEGER", nullable: true),
                    buildingType = table.Column<string>(type: "TEXT", nullable: true),
                    laneType = table.Column<string>(type: "TEXT", nullable: true),
                    towerType = table.Column<string>(type: "TEXT", nullable: true),
                    FrameId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantFrame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    positionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    currentGold = table.Column<int>(type: "INTEGER", nullable: false),
                    totalGold = table.Column<int>(type: "INTEGER", nullable: false),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    xp = table.Column<int>(type: "INTEGER", nullable: false),
                    minionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    jungleMinionsKilled = table.Column<int>(type: "INTEGER", nullable: false),
                    dominionScore = table.Column<int>(type: "INTEGER", nullable: false),
                    teamScore = table.Column<int>(type: "INTEGER", nullable: false),
                    FrameId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantFrame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantFrame_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantFrame_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssistingParticipantIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    participantId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistingParticipantIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistingParticipantIds_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX__1_positionId",
                table: "_1",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__10_positionId",
                table: "_10",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__2_positionId",
                table: "_2",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__3_positionId",
                table: "_3",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__4_positionId",
                table: "_4",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__5_positionId",
                table: "_5",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__6_positionId",
                table: "_6",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__7_positionId",
                table: "_7",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__8_positionId",
                table: "_8",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX__9_positionId",
                table: "_9",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssistingParticipantIds_EventId",
                table: "AssistingParticipantIds",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ban_TeamId",
                table: "Ban",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_FrameId",
                table: "Events",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_positionId",
                table: "Events",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_GameTimelineId",
                table: "Frames",
                column: "GameTimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_Frames_participantFramesId",
                table: "Frames",
                column: "participantFramesId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameDataId",
                table: "Games",
                column: "GameDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_GameDataId",
                table: "Participant",
                column: "GameDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_statsId",
                table: "Participant",
                column: "statsId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_timelineId",
                table: "Participant",
                column: "timelineId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrame_FrameId",
                table: "ParticipantFrame",
                column: "FrameId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrame_positionId",
                table: "ParticipantFrame",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf10Id",
                table: "ParticipantFrames",
                column: "pf10Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf1Id",
                table: "ParticipantFrames",
                column: "pf1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf2Id",
                table: "ParticipantFrames",
                column: "pf2Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf3Id",
                table: "ParticipantFrames",
                column: "pf3Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf4Id",
                table: "ParticipantFrames",
                column: "pf4Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf5Id",
                table: "ParticipantFrames",
                column: "pf5Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf6Id",
                table: "ParticipantFrames",
                column: "pf6Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf7Id",
                table: "ParticipantFrames",
                column: "pf7Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf8Id",
                table: "ParticipantFrames",
                column: "pf8Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFrames_pf9Id",
                table: "ParticipantFrames",
                column: "pf9Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantIdentity_GameDataId",
                table: "ParticipantIdentity",
                column: "GameDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantIdentity_playerId",
                table: "ParticipantIdentity",
                column: "playerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_GameDataId",
                table: "Team",
                column: "GameDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_creepsPerMinDeltasId",
                table: "Timeline",
                column: "creepsPerMinDeltasId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_csDiffPerMinDeltasId",
                table: "Timeline",
                column: "csDiffPerMinDeltasId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_damageTakenDiffPerMinDeltasId",
                table: "Timeline",
                column: "damageTakenDiffPerMinDeltasId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_damageTakenPerMinDeltasId",
                table: "Timeline",
                column: "damageTakenPerMinDeltasId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_goldPerMinDeltasId",
                table: "Timeline",
                column: "goldPerMinDeltasId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_xpDiffPerMinDeltasId",
                table: "Timeline",
                column: "xpDiffPerMinDeltasId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_xpPerMinDeltasId",
                table: "Timeline",
                column: "xpPerMinDeltasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistingParticipantIds");

            migrationBuilder.DropTable(
                name: "Ban");

            migrationBuilder.DropTable(
                name: "Champs");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "ParticipantFrame");

            migrationBuilder.DropTable(
                name: "ParticipantIdentity");

            migrationBuilder.DropTable(
                name: "PlayerLeaderboardStats");

            migrationBuilder.DropTable(
                name: "StatObjects");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Timeline");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Frames");

            migrationBuilder.DropTable(
                name: "GameData");

            migrationBuilder.DropTable(
                name: "CreepsPerMinDeltas");

            migrationBuilder.DropTable(
                name: "CsDiffPerMinDeltas");

            migrationBuilder.DropTable(
                name: "DamageTakenDiffPerMinDeltas");

            migrationBuilder.DropTable(
                name: "DamageTakenPerMinDeltas");

            migrationBuilder.DropTable(
                name: "GoldPerMinDeltas");

            migrationBuilder.DropTable(
                name: "XpDiffPerMinDeltas");

            migrationBuilder.DropTable(
                name: "XpPerMinDeltas");

            migrationBuilder.DropTable(
                name: "GameTimelines");

            migrationBuilder.DropTable(
                name: "ParticipantFrames");

            migrationBuilder.DropTable(
                name: "_1");

            migrationBuilder.DropTable(
                name: "_10");

            migrationBuilder.DropTable(
                name: "_2");

            migrationBuilder.DropTable(
                name: "_3");

            migrationBuilder.DropTable(
                name: "_4");

            migrationBuilder.DropTable(
                name: "_5");

            migrationBuilder.DropTable(
                name: "_6");

            migrationBuilder.DropTable(
                name: "_7");

            migrationBuilder.DropTable(
                name: "_8");

            migrationBuilder.DropTable(
                name: "_9");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
