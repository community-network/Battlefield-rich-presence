﻿using System;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    public class TrayItem : ApplicationContext
    {
        TimerPlus _timer = new TimerPlus();
        TimerPlus _trayUpdateTimer = new TimerPlus();
        private NotifyIcon _trayIcon;
        private Config _config;

        public TrayItem()
        {
            _config = new Config();
            // Initialize Tray Icon
            _trayIcon = new NotifyIcon
            {
                Text = "Battlefield rich presence",
                Icon = Properties.Resources.TrayIcon,
                ContextMenu = new ContextMenu(new[] {
                new MenuItem("Next update in ...", Void),
                new MenuItem("Copy BF1 sender id (anonymous)", Copy),
                new MenuItem("Edit settings", Edit),
                new MenuItem("Exit", Exit),
            }),
                Visible = true
            };
            _trayIcon.ContextMenu.MenuItems[0].Enabled = false;
            UpdateTrayItems();
            //_trayIcon.ContextMenu.MenuItems[1].Enabled = false;

            DiscordPresence discordPresence = new DiscordPresence();
            // run on startup instead of 15 seconds later
            discordPresence.Update();

            // background update interval
            _timer.Interval = 15000;
            _timer.Elapsed += discordPresence.Update;
            _timer.Start();

            _trayUpdateTimer.Interval = 1000;
            _trayUpdateTimer.Elapsed += UpdateTray;
            _trayUpdateTimer.Start();
        }

        void UpdateTray(object sender, System.Timers.ElapsedEventArgs e)
        {
            _trayIcon.ContextMenu.MenuItems[0].Text = $"Next update in: {Convert.ToInt32(_timer.TimeLeft)/1000}";
        }

        void UpdateTrayItems()
        {
            if (_config.GatherServerInfo)
            {
                _trayIcon.ContextMenu = new ContextMenu(new[] {
                    new MenuItem("Next update in ...", Void),
                    new MenuItem("Copy bf1 sender id (anonymous)", Copy),
                    new MenuItem("Edit settings", Edit),
                    new MenuItem("Exit", Exit),
                });
            } else
            {
                _trayIcon.ContextMenu = new ContextMenu(new[] {
                    new MenuItem("Next update in ...", Void),
                    new MenuItem("Edit settings", Edit),
                    new MenuItem("Exit", Exit),
                });
            }
        }

        void Void(object sender, EventArgs e) { }

        void Edit(object sender, EventArgs e)
        {
            using (var editWindow = new EditWindow())
            {
                DialogResult result = editWindow.ShowDialog();
                _config.Refresh();
                UpdateTrayItems();
            }
        }

        void Copy(object sender, EventArgs e)
        {
            Clipboard.SetText(this._config.Guid.ToString());
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;

            _timer.Dispose();
            _trayUpdateTimer.Dispose();
            Application.Exit();
        }
    }
}
