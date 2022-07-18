using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battlefield_rich_presence
{
    public partial class EditWindow : Form
    {
        private Config config;

        public EditWindow()
        {
            InitializeComponent();
            this.config = new Config();
            this.PlayerNameBox.Text = config.playerName;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormClosing += EditFormClosing;
        }

        private void EditFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PlayerNameBox.Text.Equals(config.playerName))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do want to save them?", "Message editor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Save();
                }
            }
        }

        private void Save()
        {
            config.playerName = PlayerNameBox.Text;
            config.Update();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            this.Save();
            SaveButton.Text = "Saved!";
            await Task.Delay(1000);
            SaveButton.Text = "Save";
        }
    }
}
