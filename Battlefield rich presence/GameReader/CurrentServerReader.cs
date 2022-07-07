using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Battlefield_rich_presence.GameReader
{

    internal class CurrentServerReader
    {
        public List<Structs.PlayerList> PlayerLists_All { get; private set; }
        public List<Structs.PlayerList> PlayerLists_Team1 { get; private set; }
        public List<Structs.PlayerList> PlayerLists_Team2 { get; private set; }
        public ObservableCollection<Structs.PlayerList> ListBox_PlayerList_Team1 { get; private set; }
        public ObservableCollection<Structs.PlayerList> ListBox_PlayerList_Team2 { get; private set; }

        public string ServerName { get; private set; }
        public DateTime RefreshTime { get; private set; }
        public bool hasResults { get; private set; }
        public int ServerScoreTeam1 { get; private set; }
        public int ServerScoreTeam2 { get; private set; }

        public CurrentServerReader()
        {
            PlayerLists_All = new List<Structs.PlayerList>();
            PlayerLists_Team1 = new List<Structs.PlayerList>();
            PlayerLists_Team2 = new List<Structs.PlayerList>();

            ListBox_PlayerList_Team1 = new ObservableCollection<Structs.PlayerList>();
            ListBox_PlayerList_Team2 = new ObservableCollection<Structs.PlayerList>();

            hasResults = false;
            Refresh();
        }

        public void Refresh()
        {
            if (Memory.Initialize())
            {
                ServerScoreTeam1 = Memory.Read<int>(Memory.GetBaseAddress() + Offsets.ServerScore_Offset, Offsets.ServerScoreTeam1);
                ServerScoreTeam2 = Memory.Read<int>(Memory.GetBaseAddress() + Offsets.ServerScore_Offset, Offsets.ServerScoreTeam2);
                ServerName = Memory.ReadString(Memory.GetBaseAddress() + Offsets.ServerName_Offset, Offsets.ServerName, 64);
                ServerName = string.IsNullOrEmpty(ServerName) ? "" : ServerName;

                // player data

                for (int i = 0; i < 74; i++)
                {
                    var pClientPlayerBA = Player.GetPlayerById(i);
                    if (!Memory.IsValid(pClientPlayerBA))
                        continue;

                    var Name = Memory.ReadString(pClientPlayerBA + 0x2156, 64);
                    var TeamID = Memory.Read<int>(pClientPlayerBA + 0x1C34);
                    var Mark = Memory.Read<byte>(pClientPlayerBA + 0x1D7C);
                    var PersionID = Memory.Read<long>(pClientPlayerBA + 0x38);

                    PlayerLists_All.Add(new Structs.PlayerList()
                    {
                        teamId = TeamID,
                        mark = Mark,
                        rank = 0,
                        name = Name,
                        player_id = PersionID,
                        kills = 0,
                        deaths = 0,
                        score = 0
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

                    int index = PlayerLists_All.FindIndex(val => val.mark == Mark);
                    if (index != -1)
                    {
                        PlayerLists_All[index].rank = Rank;
                        PlayerLists_All[index].kills = Kill;
                        PlayerLists_All[index].deaths = Dead;
                        PlayerLists_All[index].score = Score;
                    }
                }

                // Team data collation

                foreach (var item in PlayerLists_All)
                {
                    if (item.teamId == 1)
                    {
                        PlayerLists_Team1.Add(item);
                    }
                    else if (item.teamId == 2)
                    {
                        PlayerLists_Team2.Add(item);
                    }
                }

                //PlayerLists_Team1.Sort((a, b) => b.Score.CompareTo(a.Score));
                //PlayerLists_Team2.Sort((a, b) => b.Score.CompareTo(a.Score));

                PlayerLists_Team1 = PlayerLists_Team1.OrderByDescending(o => o.score).ToList();
                PlayerLists_Team2 = PlayerLists_Team2.OrderByDescending(o => o.score).ToList();

                int count = 1;
                for (int i = 0; i < PlayerLists_Team1.Count; i++)
                {
                    PlayerLists_Team1[i].index = count++;
                    ListBox_PlayerList_Team1.Add(PlayerLists_Team1[i]);
                }

                count = 1;
                for (int i = 0; i < PlayerLists_Team2.Count; i++)
                {
                    PlayerLists_Team2[i].index = count++;
                    ListBox_PlayerList_Team2.Add(PlayerLists_Team2[i]);
                }

                RefreshTime = DateTime.Now;
                hasResults = true;

                Memory.CloseHandle();
            }
            else
            {
                hasResults = false;
            }
        }
    }
}
