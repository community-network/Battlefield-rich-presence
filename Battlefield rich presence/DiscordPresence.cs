﻿using System;
using BattlefieldRichPresence.ChangePrensence;
using BattlefieldRichPresence.Resources;
using BattlefieldRichPresence.Structs;
using DiscordRPC;
using GameDataReader;

namespace BattlefieldRichPresence
{
    internal class DiscordPresence
    {

        private readonly Config _config;
        private DiscordRpcClient _client;
        private bool _discordIsRunning;
        private DateTime _startTime;
        private Statics.Game _previousGame;

        public DiscordPresence()
        {
            _config = new Config();
        }

        private void StartStopDiscord(GameInfo gameInfo)
        {
            if (gameInfo.IsRunning && !_discordIsRunning)
            {
                _client = new DiscordRpcClient(Statics.GameClientIds[gameInfo.Game]);
                _client.Initialize();
                _discordIsRunning = true;
                _startTime = DateTime.UtcNow.AddSeconds(1);
            }
            else if (!gameInfo.IsRunning && _discordIsRunning)
            {
                _client.Dispose();
                _discordIsRunning = false;
            // for weird edgecase where someone has 2 games running and quits one
            } else if (gameInfo.IsRunning && _discordIsRunning && _previousGame != gameInfo.Game)
            {
                _client.Dispose();
                _client = new DiscordRpcClient(Statics.GameClientIds[gameInfo.Game]);
                _client.Initialize();
                _startTime = DateTime.UtcNow.AddSeconds(1);
            }
        }

        private void UpdatePresenceInMenu(GameInfo gameInfo)
        {
            if (gameInfo.IsRunning && _discordIsRunning)
            {
                _client.SetPresence(new RichPresence
                {
                    Details = "In the menus",
                    State = "",
                    Timestamps = new Timestamps
                    {
                        Start = _startTime
                    },
                    Assets = new Assets
                    {
                        LargeImageKey = gameInfo.ShortName.ToLower(),
                        LargeImageText = gameInfo.FullName,
                        SmallImageKey = "gt",
                        SmallImageText = "Battlefield rich presence"
                    },

                });
            }
        }

        private void UpdatePresenceStatusUnknown(GameInfo gameInfo, string reason)
        {
            if (gameInfo.IsRunning && _discordIsRunning)
            {
                _client.SetPresence(new RichPresence
                {
                    Details = "Status unknown",
                    State = reason,
                    Timestamps = new Timestamps
                    {
                        Start = _startTime
                    },
                    Assets = new Assets
                    {
                        LargeImageKey = gameInfo.ShortName.ToLower(),
                        LargeImageText = gameInfo.FullName,
                        SmallImageKey = "gt",
                        SmallImageText = "Battlefield rich presence"
                    }
                });
            }
        }

        private void UpdatePresence(GameInfo gameInfo, ServerInfo serverInfo)
        {
            if (_discordIsRunning)
            {
                try
                {
                    if (Statics.Frostbite3Games.Contains(gameInfo.Game))
                    {
                        Frostbite3.Update(_client, _startTime, gameInfo, serverInfo);
                    } else
                    {
                        OlderTitles.Update(_client, _startTime, gameInfo, serverInfo);
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public void Update(object sender, System.Timers.ElapsedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            GameInfo gameInfo = Game.IsRunning();
            StartStopDiscord(gameInfo);
            if (Statics.NewTitles.Contains(gameInfo.Game))
            {
                try
                {
                    var playerName = (string)_config.PlayerNames[gameInfo.ShortName];
                    ServerInfo serverInfo = Api.GetCurrentServer(playerName, gameInfo.Game);
                    UpdatePresence(gameInfo, serverInfo);
                }
                catch (Exception)
                {
                    UpdatePresenceInMenu(gameInfo);
                }
            }
            else if (gameInfo.IsRunning && Statics.GameDataReaderGames.Contains(gameInfo.Game))
            {
                try
                {
                    string playerName;
                    switch (gameInfo.Game)
                    {
                        case Statics.Game.Bf1942:
                            playerName = GameDataReaders.Bf1942.ReadActivePlayer().OnlineName;
                            break;
                        case Statics.Game.Bfvietnam:
                            playerName = GameDataReaders.BfVietnam.ReadActivePlayer().OnlineName;
                            break;
                        case Statics.Game.Bf2:
                            playerName = GameDataReaders.Bf2.ReadActivePlayer().OnlineName;
                            break;
                        case Statics.Game.Bf2142:
                            playerName = GameDataReaders.Bf2142.ReadActivePlayer().OnlineName;
                            break;
                        case Statics.Game.Bfbc2:
                            playerName = GameDataReaders.BfBc2.ReadActivePlayer().OnlineName;
                            break;
                        default:
                            throw new NotImplementedException();
                    }

                    var serverInfo = Api.OldTitleServerInfo(playerName, gameInfo.ShortName.ToLower());
                    UpdatePresence(gameInfo, serverInfo);
                }
                catch (Exception)
                {
                    UpdatePresenceInMenu(gameInfo);
                }
            }
            else if (gameInfo.IsRunning && (string)_config.PlayerNames[gameInfo.ShortName] != null)
            {
                try
                {
                    var playerName = (string)_config.PlayerNames[gameInfo.ShortName];
                    ServerInfo serverInfo = Api.OldTitleServerInfo(playerName, gameInfo.ShortName.ToLower());
                    UpdatePresence(gameInfo, serverInfo);
                }
                catch (Exception)
                {
                    UpdatePresenceInMenu(gameInfo);
                }
            }
            else if (gameInfo.IsRunning)
            {
                UpdatePresenceStatusUnknown(gameInfo, "Playername not configured");
            }

            _previousGame = gameInfo.Game;
            _config.Refresh();
        }
    }
}
