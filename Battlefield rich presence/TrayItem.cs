﻿using System;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    public class TrayItem : ApplicationContext
    {
        private readonly TimerPlus _timer = new();
        private readonly TimerPlus _trayUpdateTimer = new();
        private readonly Config _config = new();
        private readonly NotifyIcon _trayIcon;

        public TrayItem()
        {
            // Initialize Tray Icon
            _trayIcon = new NotifyIcon
            {
                Text = "Battlefield rich presence",
                Icon = Properties.Resources.TrayIcon,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true
            };
            _trayIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[] {
                //new MenuItem($"Player: {_config.PlayerName}", Void),
                new ToolStripMenuItem("Next update in ...", null, Void),
                new ToolStripMenuItem("Edit settings", null, Edit),
                new ToolStripMenuItem("Copy BF1 sender id (anonymous)", null, Copy),
                new ToolStripMenuItem("Exit", null, Exit),
            });
            _trayIcon.ContextMenuStrip.Items[0].Enabled = false;
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
            _trayIcon.ContextMenuStrip.Items[0].Text = $"Next update in: {Convert.ToInt32(_timer.TimeLeft)/1000}";
        }

        void UpdateTrayItems()
        {
            if (_config.GatherServerInfo)
            {
                _trayIcon.ContextMenuStrip.Items.Clear();
                _trayIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[] {
                    new ToolStripMenuItem("Next update in ...", null, Void),
                    new ToolStripMenuItem("Copy bf1 sender id (anonymous)", null, Copy),
                    new ToolStripMenuItem("Edit settings", null, Edit),
                    new ToolStripMenuItem("Exit", null, Exit),
                });
            } else
            {
                _trayIcon.ContextMenuStrip.Items.Clear();
                _trayIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[] {
                    new ToolStripMenuItem("Next update in ...", null, Void),
                    new ToolStripMenuItem("Edit settings", null, Edit),
                    new ToolStripMenuItem("Exit", null, Exit),
                });
            }
        }

        void Void(object sender, EventArgs e) { }

        void Edit(object sender, EventArgs e)
        {
            using (var editWindow = new EditWindow())
            {
                editWindow.ShowDialog();
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
