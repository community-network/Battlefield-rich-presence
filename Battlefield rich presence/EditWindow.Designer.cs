using System.ComponentModel;
using System.Windows.Forms;

namespace BattlefieldRichPresence
{
    partial class EditWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(EditWindow));
            PlayerNameBox = new TextBox();
            LabelInfoText = new Label();
            SaveButton = new Button();
            GameSelector = new ComboBox();
            ChangeAllButton = new Button();
            LabelGameSelector = new Label();
            LabelPlayerNameBox = new Label();
            GroupBoxPlayerName = new GroupBox();
            LabelInfoIcon = new Label();
            gatherDataCheckboxTooltip = new ToolTip(components);
            GroupBoxPlayerName.SuspendLayout();
            SuspendLayout();
            // 
            // PlayerNameBox
            // 
            PlayerNameBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            PlayerNameBox.Location = new System.Drawing.Point(103, 119);
            PlayerNameBox.Name = "PlayerNameBox";
            PlayerNameBox.Size = new System.Drawing.Size(248, 25);
            PlayerNameBox.TabIndex = 0;
            PlayerNameBox.TextChanged += PlayerNameBox_TextChanged;
            // 
            // LabelInfoText
            // 
            LabelInfoText.AutoSize = true;
            LabelInfoText.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            LabelInfoText.Location = new System.Drawing.Point(71, 42);
            LabelInfoText.Name = "LabelInfoText";
            LabelInfoText.Size = new System.Drawing.Size(286, 15);
            LabelInfoText.TabIndex = 2;
            LabelInfoText.Text = "Games not in the list support automatic name detection";
            // 
            // SaveButton
            // 
            SaveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            SaveButton.Location = new System.Drawing.Point(182, 215);
            SaveButton.Margin = new Padding(4, 3, 4, 3);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(288, 37);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // GameSelector
            // 
            GameSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            GameSelector.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            GameSelector.FormattingEnabled = true;
            GameSelector.Location = new System.Drawing.Point(103, 80);
            GameSelector.Margin = new Padding(4, 3, 4, 3);
            GameSelector.Name = "GameSelector";
            GameSelector.Size = new System.Drawing.Size(248, 25);
            GameSelector.TabIndex = 4;
            GameSelector.SelectedIndexChanged += GameSelector_SelectedIndexChanged;
            // 
            // ChangeAllButton
            // 
            ChangeAllButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            ChangeAllButton.Location = new System.Drawing.Point(24, 215);
            ChangeAllButton.Margin = new Padding(4, 3, 4, 3);
            ChangeAllButton.Name = "ChangeAllButton";
            ChangeAllButton.Size = new System.Drawing.Size(150, 37);
            ChangeAllButton.TabIndex = 5;
            ChangeAllButton.Text = "Save name for all games";
            ChangeAllButton.UseVisualStyleBackColor = true;
            ChangeAllButton.Click += ChangeAllButton_Click;
            // 
            // LabelGameSelector
            // 
            LabelGameSelector.AutoSize = true;
            LabelGameSelector.Font = new System.Drawing.Font("Segoe UI", 9F);
            LabelGameSelector.Location = new System.Drawing.Point(44, 85);
            LabelGameSelector.Margin = new Padding(4, 0, 4, 0);
            LabelGameSelector.Name = "LabelGameSelector";
            LabelGameSelector.Size = new System.Drawing.Size(41, 15);
            LabelGameSelector.TabIndex = 6;
            LabelGameSelector.Text = "Game:";
            // 
            // LabelPlayerNameBox
            // 
            LabelPlayerNameBox.AutoSize = true;
            LabelPlayerNameBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            LabelPlayerNameBox.Location = new System.Drawing.Point(43, 123);
            LabelPlayerNameBox.Margin = new Padding(4, 0, 4, 0);
            LabelPlayerNameBox.Name = "LabelPlayerNameBox";
            LabelPlayerNameBox.Size = new System.Drawing.Size(42, 15);
            LabelPlayerNameBox.TabIndex = 7;
            LabelPlayerNameBox.Text = "Name:";
            // 
            // GroupBoxPlayerName
            // 
            GroupBoxPlayerName.Controls.Add(LabelInfoText);
            GroupBoxPlayerName.Controls.Add(LabelInfoIcon);
            GroupBoxPlayerName.Controls.Add(LabelPlayerNameBox);
            GroupBoxPlayerName.Controls.Add(PlayerNameBox);
            GroupBoxPlayerName.Controls.Add(LabelGameSelector);
            GroupBoxPlayerName.Controls.Add(GameSelector);
            GroupBoxPlayerName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            GroupBoxPlayerName.Location = new System.Drawing.Point(24, 20);
            GroupBoxPlayerName.Margin = new Padding(4, 3, 4, 3);
            GroupBoxPlayerName.Name = "GroupBoxPlayerName";
            GroupBoxPlayerName.Padding = new Padding(4, 3, 4, 3);
            GroupBoxPlayerName.Size = new System.Drawing.Size(446, 177);
            GroupBoxPlayerName.TabIndex = 8;
            GroupBoxPlayerName.TabStop = false;
            GroupBoxPlayerName.Text = "Configure in-game name (without prefix/clan tag)";
            // 
            // LabelInfoIcon
            // 
            LabelInfoIcon.AutoSize = true;
            LabelInfoIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            LabelInfoIcon.Location = new System.Drawing.Point(41, 38);
            LabelInfoIcon.Margin = new Padding(4, 0, 4, 0);
            LabelInfoIcon.Name = "LabelInfoIcon";
            LabelInfoIcon.Size = new System.Drawing.Size(30, 20);
            LabelInfoIcon.TabIndex = 8;
            LabelInfoIcon.Text = "ℹ";
            // 
            // EditWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(493, 271);
            Controls.Add(GroupBoxPlayerName);
            Controls.Add(ChangeAllButton);
            Controls.Add(SaveButton);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "EditWindow";
            Text = "Edit settings";
            GroupBoxPlayerName.ResumeLayout(false);
            GroupBoxPlayerName.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox PlayerNameBox;
        private Label LabelInfoText;
        private Button SaveButton;
        private ComboBox GameSelector;
        private Button ChangeAllButton;
        private Label LabelGameSelector;
        private Label LabelPlayerNameBox;
        private GroupBox GroupBoxPlayerName;
        private Label LabelInfoIcon;
        private ToolTip gatherDataCheckboxTooltip;
    }
}