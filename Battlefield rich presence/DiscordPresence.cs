using System;
using System.Threading;
using Battlefield_rich_presence.Resources;
using Battlefield_rich_presence.Structs;
using DiscordRPC;

namespace Battlefield_rich_presence
{
    internal class DiscordPresence
    {
        private Config config;
        private DiscordRpcClient client;
        public bool discord_is_running = false;
        DateTime start_time;

        public DiscordPresence()
        {
            config = new Config();
        }

        private void StartStopDiscord(GameInfo game_info)
        {
            if (game_info.is_running && !discord_is_running)
            {
                client = new DiscordRpcClient("993783880777744524");
                client.Initialize();
                discord_is_running = true;
                start_time = DateTime.UtcNow.AddSeconds(1);
            }
            else if (!game_info.is_running && discord_is_running)
            {
                client.Dispose();
                discord_is_running = false;
            }
        }

        private void UpdatePresenceInMenu(GameInfo game_info)
        {
            if (game_info.is_running && discord_is_running)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "In the menus",
                    State = "",
                    Timestamps = new Timestamps()
                    {
                        Start = start_time
                    },
                    Assets = new Assets()
                    {
                        LargeImageKey = game_info.short_name,
                        LargeImageText = game_info.game_name,
                        SmallImageKey = game_info.short_name
                    },

                });
            }
        }

        private void UpdatePresenceStatusUnknown(GameInfo gameInfo, string reason)
        {
            if (gameInfo.is_running && discord_is_running)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "Status unknown",
                    State = reason,
                    Timestamps = new Timestamps()
                    {
                        Start = start_time
                    },
                    Assets = new Assets()
                    {
                        LargeImageKey = gameInfo.short_name,
                        LargeImageText = gameInfo.game_name,
                        SmallImageKey = gameInfo.short_name
                    }
                });
            }
        }

        private void UpdatePresence(GameInfo game_info, ServerInfo server_info)
        {
            if (discord_is_running)
            {
                try
                {
                    if (Statics.frostbite3_games.Contains(game_info.short_name))
                    {
                        ChangePrensence.Frostbite3.Update(client, start_time, game_info, server_info);
                    } else
                    {
                        ChangePrensence.OlderTitles.Update(client, start_time, game_info, server_info);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public void Main()
        {
            while (true)
            {
                GameInfo game_info = Game.IsRunning();
                StartStopDiscord(game_info);
                if (game_info.short_name == "bf1")
                {
                    GameReader.CurrentServerReader current_server_reader = new GameReader.CurrentServerReader();
                    if (current_server_reader.hasResults)
                    {
                        if (current_server_reader.PlayerLists_All.Count > 0 && current_server_reader.ServerName != "")
                        {
                            ServerInfo server_info = new ServerInfo
                            {
                                name = current_server_reader.ServerName,
                                numPlayers = current_server_reader.PlayerLists_All.Count,
                                maxPlayers = 0,
                                ip = "",
                                port = 0
                            };
                            UpdatePresence(game_info, server_info);
                        }
                        else
                        {
                            UpdatePresenceInMenu(game_info);
                        }
                    }
                } else if (game_info.is_running && config.playerName != "")
                {
                    try
                    {
                        ServerInfo server_info = Api.OldTitleServerInfo(config, game_info.short_name);
                        UpdatePresence(game_info, server_info);
                    }
                    catch (Exception)
                    {
                        UpdatePresenceInMenu(game_info);  
                    }
                } else if (game_info.is_running)
                {
                    UpdatePresenceStatusUnknown(game_info, "Playername not configured");
                }

                Thread.Sleep(10000);
                config.Refresh();
            }
        }
    }
}
