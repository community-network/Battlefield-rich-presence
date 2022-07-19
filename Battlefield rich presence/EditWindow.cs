using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    public partial class EditWindow : Form
    {
        private Config _config;

        public EditWindow()
        {
            InitializeComponent();
            _config = new Config();
            PlayerNameBox.Text = _config.PlayerName;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormClosing += EditFormClosing;
        }

        private void EditFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PlayerNameBox.Text.Equals(_config.PlayerName))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do want to save them?", "Message editor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void Save()
        {
            _config.PlayerName = PlayerNameBox.Text;
            _config.Update();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
            SaveButton.Text = "Saved!";
            await Task.Delay(1000);
            SaveButton.Text = "Save";
        }
    }
}
