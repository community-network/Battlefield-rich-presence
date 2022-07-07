using System;
using System.Threading;
using DiscordRPC;

namespace Battlefield_rich_presence
{
    internal class DiscordPresence
    {
        private DiscordRpcClient client;
        private bool discord_is_running = false;
        DateTime start_time;

        private void StartStopDiscord()
        {
            if (Game.IsRunning() && !discord_is_running)
            {
                client = new DiscordRpcClient("993783880777744524");
                client.Initialize();
                discord_is_running = true;
                start_time = DateTime.UtcNow.AddSeconds(1);
            }
            else if (!Game.IsRunning() && discord_is_running)
            {
                client.Dispose();
                discord_is_running = false;
            }
        }

        private void UpdatePresenceInMenu()
        {
            if (Game.IsRunning() && discord_is_running)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = "In the menu's",
                    State = "0 players",
                    Timestamps = new Timestamps()
                    {
                        Start = start_time
                    },
                    Assets = new Assets()
                    {
                        LargeImageKey = "bf1",
                        LargeImageText = "Battlefield 1",
                        SmallImageKey = "bf1"
                    },

                });
            }
        }

        private void UpdatePresence(GameReader.CurrentServerReader current_server_reader)
        {
            if (discord_is_running)
            {
                try
                {
                    string game_id = Api.GetGameId(current_server_reader);
                    //Set the rich presence
                    //Call this as many times as you want and anywhere in your code.
                    client.SetPresence(new RichPresence()
                    {
                        Details = $"{current_server_reader.ServerName}",
                        State = $"{current_server_reader.PlayerLists_All.Count} players",
                        Timestamps = new Timestamps()
                        {
                            Start = start_time
                        },
                        Assets = new Assets()
                        {
                            LargeImageKey = "bf1",
                            LargeImageText = "Battlefield 1",
                            SmallImageKey = "bf1"
                        },
                        Buttons = new Button[] //$"{textBox10.Text}"
                        {
                        new Button() { Label = "Join", Url = $"https://joinme.click/g/bf1/{game_id}" },
                        new Button() { Label = "View server", Url = $"https://gametools.network/servers/bf1/gameid/{game_id}/pc" }
                        }
                    });
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
                StartStopDiscord();
                GameReader.CurrentServerReader current_server_reader = new GameReader.CurrentServerReader();
                if (current_server_reader.hasResults)
                {
                    if (current_server_reader.PlayerLists_All.Count > 0 && current_server_reader.ServerName != "")
                    {
                        UpdatePresence(current_server_reader);
                    }
                    else
                    {
                        UpdatePresenceInMenu();
                    }
                }

                Thread.Sleep(10000);
            }
        }
    }
}
