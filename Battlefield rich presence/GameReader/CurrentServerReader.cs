using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BattlefieldRichPresence.Structs;

namespace BattlefieldRichPresence.GameReader
{

    internal class CurrentServerReader
    {
        public List<PlayerList> PlayerListsAll { get; private set; }
        public List<PlayerList> PlayerListsTeam1 { get; private set; }
        public List<PlayerList> PlayerListsTeam2 { get; private set; }
        public ObservableCollection<PlayerList> ListBoxPlayerListTeam1 { get; private set; }
        public ObservableCollection<PlayerList> ListBoxPlayerListTeam2 { get; private set; }

        public string ServerName { get; private set; }
        public DateTime RefreshTime { get; private set; }
        public bool HasResults { get; private set; }
        public int ServerScoreTeam1 { get; private set; }
        public int ServerScoreTeam2 { get; private set; }

        public CurrentServerReader()
        {
            PlayerListsAll = new List<PlayerList>();
            PlayerListsTeam1 = new List<PlayerList>();
            PlayerListsTeam2 = new List<PlayerList>();

            ListBoxPlayerListTeam1 = new ObservableCollection<PlayerList>();
            ListBoxPlayerListTeam2 = new ObservableCollection<PlayerList>();

            HasResults = false;
            Refresh();
        }

        public void Refresh()
        {
            if (Memory.Initialize())
            {
                ServerScoreTeam1 = Memory.Read<int>(Memory.GetBaseAddress() + Offsets.ServerScoreOffset, Offsets.ServerScoreTeam1);
                ServerScoreTeam2 = Memory.Read<int>(Memory.GetBaseAddress() + Offsets.ServerScoreOffset, Offsets.ServerScoreTeam2);
                ServerName = Memory.ReadString(Memory.GetBaseAddress() + Offsets.ServerNameOffset, Offsets.ServerName, 64);
                ServerName = string.IsNullOrEmpty(ServerName) ? "" : ServerName;

                // player data

                for (int i = 0; i < 74; i++)
                {
                    var pClientPlayerBa = Player.GetPlayerById(i);
                    if (!Memory.IsValid(pClientPlayerBa))
                        continue;

                    var name = Memory.ReadString(pClientPlayerBa + 0x2156, 64);
                    var teamId = Memory.Read<int>(pClientPlayerBa + 0x1C34);
                    var mark = Memory.Read<byte>(pClientPlayerBa + 0x1D7C);
                    var persionId = Memory.Read<long>(pClientPlayerBa + 0x38);

                    PlayerListsAll.Add(new PlayerList
                    {
                        TeamId = teamId,
                        Mark = mark,
                        Rank = 0,
                        Name = name,
                        PlayerId = persionId,
                        Kills = 0,
                        Deaths = 0,
                        Score = 0
                    });
                }

                // scoreboard data

                var pClientScoreBa = Memory.Read<long>(Memory.GetBaseAddress() + 0x39EB8D8);
                pClientScoreBa = Memory.Read<long>(pClientScoreBa + 0x68);

                for (int i = 0; i < 74; i++)
                {
                    pClientScoreBa = Memory.Read<long>(pClientScoreBa);
                    var pClientScoreOffset = Memory.Read<long>(pClientScoreBa + 0x10);
                    if (!Memory.IsValid(pClientScoreBa))
                        continue;

                    var mark = Memory.Read<byte>(pClientScoreOffset + 0x300);
                    var rank = Memory.Read<int>(pClientScoreOffset + 0x304);
                    if (rank == 0)
                        continue;
                    var kill = Memory.Read<int>(pClientScoreOffset + 0x308);
                    var dead = Memory.Read<int>(pClientScoreOffset + 0x30C);
                    var score = Memory.Read<int>(pClientScoreOffset + 0x314);

                    int index = PlayerListsAll.FindIndex(val => val.Mark == mark);
                    if (index != -1)
                    {
                        PlayerListsAll[index].Rank = rank;
                        PlayerListsAll[index].Kills = kill;
                        PlayerListsAll[index].Deaths = dead;
                        PlayerListsAll[index].Score = score;
                    }
                }

                // Team data collation

                foreach (var item in PlayerListsAll)
                {
                    if (item.TeamId == 1)
                    {
                        PlayerListsTeam1.Add(item);
                    }
                    else if (item.TeamId == 2)
                    {
                        PlayerListsTeam2.Add(item);
                    }
                }

                //PlayerLists_Team1.Sort((a, b) => b.Score.CompareTo(a.Score));
                //PlayerLists_Team2.Sort((a, b) => b.Score.CompareTo(a.Score));

                PlayerListsTeam1 = PlayerListsTeam1.OrderByDescending(o => o.Score).ToList();
                PlayerListsTeam2 = PlayerListsTeam2.OrderByDescending(o => o.Score).ToList();

                int count = 1;
                for (int i = 0; i < PlayerListsTeam1.Count; i++)
                {
                    PlayerListsTeam1[i].Index = count++;
                    ListBoxPlayerListTeam1.Add(PlayerListsTeam1[i]);
                }

                count = 1;
                for (int i = 0; i < PlayerListsTeam2.Count; i++)
                {
                    PlayerListsTeam2[i].Index = count++;
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
