using System;
using System.Threading;
using System.Windows.Forms;

namespace Battlefield_rich_presence
{
    public class TrayItem : ApplicationContext
    {
        private NotifyIcon tray_icon;
        private Thread send_thread;
        private Config config;

        public TrayItem()
        {
            config = new Config();
            // Initialize Tray Icon
            tray_icon = new NotifyIcon()
            {
                Text = "Battlefield rich presence",
                Icon = Properties.Resources.TrayIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem($"Player: {config.playerName}", Void),
                new MenuItem("Edit settings", Edit),
                new MenuItem("Exit", Exit),
            }),
                Visible = true
            };
            tray_icon.ContextMenu.MenuItems[0].Enabled = false;

            DiscordPresence discordPresence = new DiscordPresence();
            this.send_thread = new Thread(new ThreadStart(discordPresence.Main));
            this.send_thread.Start();
        }

        void Void(object sender, EventArgs e) { }

        void Edit(object sender, EventArgs e)
        {
            using (var edit_window = new EditWindow())
            {
                DialogResult result = edit_window.ShowDialog();
                config.Refresh();
                tray_icon.ContextMenu.MenuItems[0].Text = $"Player: {config.playerName}";
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            tray_icon.Visible = false;

            this.send_thread.Abort();
            Application.Exit();
        }
    }
}
