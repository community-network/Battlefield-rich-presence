using System;
using System.Threading;
using System.Windows.Forms;
using Battlefield_rich_presence.Properties;

namespace Battlefield_rich_presence
{
    public class TrayItem : ApplicationContext
    {
        private NotifyIcon tray_icon;
        private Thread send_thread;

        public TrayItem()
        {
            // Initialize Tray Icon
            tray_icon = new NotifyIcon()
            {
                Text = "Battlefield rich presence",
                Icon = Resources.TrayIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            DiscordPresence discordPresence = new DiscordPresence();
            this.send_thread = new Thread(new ThreadStart(discordPresence.Main));
            this.send_thread.Start();
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            tray_icon.Visible = false;

            Application.Exit();
        }
    }
}
