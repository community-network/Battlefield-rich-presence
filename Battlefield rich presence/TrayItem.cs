using System;
using System.Threading;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    public class TrayItem : ApplicationContext
    {
        private NotifyIcon _trayIcon;
        private Thread _sendThread;
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
                new MenuItem($"Player: {_config.PlayerName}", Void),
                new MenuItem("Edit settings", Edit),
                new MenuItem("Exit", Exit),
            }),
                Visible = true
            };
            _trayIcon.ContextMenu.MenuItems[0].Enabled = false;

            DiscordPresence discordPresence = new DiscordPresence();
            _sendThread = new Thread(discordPresence.Main);
            _sendThread.Start();
        }

        void Void(object sender, EventArgs e) { }

        void Edit(object sender, EventArgs e)
        {
            using (var editWindow = new EditWindow())
            {
                DialogResult result = editWindow.ShowDialog();
                _config.Refresh();
                _trayIcon.ContextMenu.MenuItems[0].Text = $"Player: {_config.PlayerName}";
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;

            _sendThread.Abort();
            Application.Exit();
        }
    }
}
