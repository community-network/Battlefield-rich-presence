using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BattlefieldRichPresence.Structs;

namespace BattlefieldRichPresence.GameReader
{
    internal class CurrentServerReader
    {
        public List<Structs.PlayerList> PlayerListsAll { get; private set; }
        public List<Structs.PlayerList> PlayerListsTeam1 { get; private set; }
        public List<Structs.PlayerList> PlayerListsTeam2 { get; private set; }
        public ObservableCollection<Structs.PlayerList> ListBoxPlayerListTeam1 { get; private set; }
        public ObservableCollection<Structs.PlayerList> ListBoxPlayerListTeam2 { get; private set; }

        public long GameId { get; private set; }
        public string ServerName { get; private set; }
        public float ServerTime { get; private set; }
        public string ServerDate { get; private set; }
        public DateTime RefreshTime { get; private set; }
        public bool HasResults { get; private set; }

        public int ServerScoreTeam1 { get; private set; }
        public int Team1ScoreFromKill { get; private set; }
        public int Team1ScoreFromFlags { get; private set; }

        public int ServerScoreTeam2 { get; private set; }
        public int Team2ScoreFromKill { get; private set; }
        public int Team2ScoreFromFlags { get; private set; }

        public string player_vehicle { get; private set; }

        public CurrentServerReader()
        {
            PlayerListsAll = new List<Structs.PlayerList>();
            PlayerListsTeam1 = new List<Structs.PlayerList>();
            PlayerListsTeam2 = new List<Structs.PlayerList>();

            ListBoxPlayerListTeam1 = new ObservableCollection<Structs.PlayerList>();
            ListBoxPlayerListTeam2 = new ObservableCollection<Structs.PlayerList>();

            HasResults = false;
            Refresh();
        }

        public void Refresh()
        {
            if (Memory.Initialize())
            {
                var serverInfoAddr = Memory.Read<long>(Memory.GetBaseAddress() + Offsets.ServerScoreOffset, Offsets.ServerScoreTeam);
                // Team 1
                ServerScoreTeam1 = Memory.Read<int>(serverInfoAddr + 0x2B0);
                Team1ScoreFromKill = Memory.Read<int>(serverInfoAddr + 0x2B0 + 0x60);
                Team1ScoreFromFlags = Memory.Read<int>(serverInfoAddr + 0x2B0 + 0x100);
                // Team 2
                ServerScoreTeam2 = Memory.Read<int>(serverInfoAddr + 0x2B0 + 0x08);
                Team2ScoreFromKill = Memory.Read<int>(serverInfoAddr + 0x2B0 + 0x68);
                Team2ScoreFromFlags = Memory.Read<int>(serverInfoAddr + 0x2B0 + 0x108);


                GameId = Memory.Read<long>(Memory.GetBaseAddress() + Offsets.ServerIdOffset, Offsets.ServerId);
                ServerTime = Memory.Read<float>(Memory.GetBaseAddress() + Offsets.ServerTimeOffset, Offsets.ServerTime);
                ServerName = Memory.ReadString(Memory.GetBaseAddress() + Offsets.ServerNameOffset, Offsets.ServerName, 64);
                ServerName = string.IsNullOrEmpty(ServerName) ? "" : ServerName;
                ServerDate = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
                // player data

                for (int i = 0; i < 74; i++)
                {
                    List<string> WeaponSlot = new List<string>();
                    var pClientPlayerBA = Player.GetPlayerById(i);
                    if (!Memory.IsValid(pClientPlayerBA))
                        continue;

                    var platoonTag = Memory.ReadString(pClientPlayerBA + 0x2151, 16); // Platoon Tag
                    var fullName = Memory.ReadString(pClientPlayerBA + 0x2156, 64); // Name including platoon tag.
                    var platoonUrl = Memory.ReadString(pClientPlayerBA + 0x21DE, 256); // Platoon URL
                    var platoonName = Memory.ReadString(pClientPlayerBA + 0x2270, 64); // Platoon Name
                    var playerName = Memory.ReadString(pClientPlayerBA + 0x40, 64); // Name
                    var m_teamId = Memory.Read<int>(pClientPlayerBA + 0x1C34); // Player currentt team
                    var m_playerIndex = Memory.Read<byte>(pClientPlayerBA + 0x1D7C); // Player server index
                    var PersionID = Memory.Read<long>(pClientPlayerBA + 0x38); // PersonaId
                    var SquadID = Memory.Read<int>(pClientPlayerBA + 0x1E50); // Unknown

                    var pClientVehicleEntity = Memory.Read<long>(pClientPlayerBA + 0x1D38);
                    if (Memory.IsValid(pClientVehicleEntity))
                    {
                        var pVehicleEntityData = Memory.Read<long>(pClientVehicleEntity + 0x30);
                        player_vehicle = Memory.ReadString(Memory.Read<long>(pVehicleEntityData + 0x2F8), 64);
                    }
                    else
                    {

                        player_vehicle = null;

                        var pClientSoldierEntity = Memory.Read<long>(pClientPlayerBA + 0x1D48);
                        var pClientSoldierWeaponComponent = Memory.Read<long>(pClientSoldierEntity + 0x698);
                        var m_handler = Memory.Read<long>(pClientSoldierWeaponComponent + 0x8A8);

                        for (int j = 0; j < 8; j++)
                        {
                            var offset0 = Memory.Read<long>(m_handler + j * 0x8);

                            offset0 = Memory.Read<long>(offset0 + 0x4A30);
                            offset0 = Memory.Read<long>(offset0 + 0x20);
                            offset0 = Memory.Read<long>(offset0 + 0x38);
                            offset0 = Memory.Read<long>(offset0 + 0x20);

                            var weapon_id = Memory.ReadString(offset0, 64);
                            if (weapon_id != "")
                            {
                                WeaponSlot.Add(weapon_id);
                            }
                        }
                    }


                    PlayerListsAll.Add(new Structs.PlayerList()
                    {
                        teamId = m_teamId,
                        mark = m_playerIndex,
                        platoon = new Structs.Platoon()
                        { 
                            icon = platoonUrl,
                            name = platoonName,
                            tag = platoonTag
                        },
                        squad_id = SquadID,
                        rank = 0,
                        name = playerName,
                        player_id = PersionID,
                        kills = 0,
                        deaths = 0,
                        score = 0,
                        vehicle = player_vehicle,
                        weapons = WeaponSlot
                    });
                }

                // scoreboard data

                var pClientScoreBA = Memory.Read<long>(Memory.GetBaseAddress() + 0x39EB8D8);
                pClientScoreBA = Memory.Read<long>(pClientScoreBA + 0x68);

                for (int i = 0; i < 74; i++)
                {
                    pClientScoreBA = Memory.Read<long>(pClientScoreBA);
                    var pClientScoreOffset = Memory.Read<long>(pClientScoreBA + 0x10);
                    if (!Memory.IsValid(pClientScoreBA))
                        continue;

                    var Mark = Memory.Read<byte>(pClientScoreOffset + 0x300);
                    var Rank = Memory.Read<int>(pClientScoreOffset + 0x304);
                    if (Rank == 0)
                        continue;
                    var Kill = Memory.Read<int>(pClientScoreOffset + 0x308);
                    var Dead = Memory.Read<int>(pClientScoreOffset + 0x30C);
                    var Score = Memory.Read<int>(pClientScoreOffset + 0x314);

                    int index = PlayerListsAll.FindIndex(val => val.mark == Mark);
                    if (index != -1)
                    {
                        PlayerListsAll[index].rank = Rank;
                        PlayerListsAll[index].kills = Kill;
                        PlayerListsAll[index].deaths = Dead;
                        PlayerListsAll[index].score = Score;
                    }
                }

                // Team data collation

                foreach (var item in PlayerListsAll)
                {
                    if (item.teamId == 1)
                    {
                        PlayerListsTeam1.Add(item);
                    }
                    else if (item.teamId == 2)
                    {
                        PlayerListsTeam2.Add(item);
                    }
                }

                //PlayerLists_Team1.Sort((a, b) => b.Score.CompareTo(a.Score));
                //PlayerLists_Team2.Sort((a, b) => b.Score.CompareTo(a.Score));

                PlayerListsTeam1 = PlayerListsTeam1.OrderByDescending(o => o.score).ToList();
                PlayerListsTeam2 = PlayerListsTeam2.OrderByDescending(o => o.score).ToList();

                int count = 1;
                for (int i = 0; i < PlayerListsTeam1.Count; i++)
                {
                    PlayerListsTeam1[i].index = count++;
                    ListBoxPlayerListTeam1.Add(PlayerListsTeam1[i]);
                }

                count = 1;
                for (int i = 0; i < PlayerListsTeam2.Count; i++)
                {
                    PlayerListsTeam2[i].index = count++;
                    ListBoxPlayerListTeam2.Add(PlayerListsTeam2[i]);
                }

                RefreshTime = DateTime.Now;
                HasResults = true;

                Memory.CloseHandle();
            }
            else
            {
                HasResults = false;
            }
        }
    }
}
