using BattlefieldRichPresence.Resources;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    public partial class EditWindow : Form
    {
        private Config _config;
        private Structs.GamesPlayerName _current;

        public EditWindow()
        {
            InitializeComponent();
            _config = new Config();
            _current = Clone(_config.PlayerNames);
            GameSelector.DataSource = Statics.NameChangeUiGames;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormClosing += EditFormClosing;
        }

        private Structs.GamesPlayerName Clone(Structs.GamesPlayerName playerNames)
        {
            return new Structs.GamesPlayerName()
            {
                Bfbc2 = playerNames.Bfbc2,
                Bf3 = playerNames.Bf3,
                Bf4 = playerNames.Bf4,
                Bfh = playerNames.Bfh,
                Bf1 = playerNames.Bf1,
                Bf5 = playerNames.Bf5,
                Bf2042 = playerNames.Bf2042
            };
        }

        private void EditFormClosing(object sender, FormClosingEventArgs e)
        {
            bool hasChanges = false;
            foreach (Statics.Game game in Statics.NameChangeUiGames)
            {
                if (!Equals(_current[game.ToString()], _config.PlayerNames[game.ToString()]))
                {
                    hasChanges = true;
                }
            }
            if (hasChanges)
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do want to save them?", "Unsaved changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void Save()
        {
            _config.PlayerNames = Clone(_current);
            _config.Update();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
            SaveButton.Text = "Saved!";
            await Task.Delay(1000);
            SaveButton.Text = $"Save for {GameSelector.SelectedItem}";
        }

        private void GameSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var gameName = GameSelector.SelectedItem.ToString();
            SaveButton.Text = $"Save name for {GameSelector.SelectedItem}";
            string playerName = (string)_current[gameName];
            PlayerNameBox.Text = playerName ?? "";
        }

        private void PlayerNameBox_TextChanged(object sender, EventArgs e)
        {
            _current[GameSelector.SelectedItem.ToString()] = PlayerNameBox.Text;
        }

        private void ChangeAllButton_Click(object sender, EventArgs e)
        {
            foreach (Statics.Game game in Statics.NameChangeUiGames)
            {
                _current[game.ToString()] = PlayerNameBox.Text;
                Save();
            }
        }

    }
}
