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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWindow));
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.LabelInfoText = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GameSelector = new System.Windows.Forms.ComboBox();
            this.ChangeAllButton = new System.Windows.Forms.Button();
            this.LabelGameSelector = new System.Windows.Forms.Label();
            this.LabelPlayerNameBox = new System.Windows.Forms.Label();
            this.GroupBoxPlayerName = new System.Windows.Forms.GroupBox();
            this.LabelInfoIcon = new System.Windows.Forms.Label();
            this.GatherServerInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.gatherDataCheckboxTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.GroupBoxPlayerName.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayerNameBox.Location = new System.Drawing.Point(103, 119);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(248, 25);
            this.PlayerNameBox.TabIndex = 0;
            this.PlayerNameBox.TextChanged += new System.EventHandler(this.PlayerNameBox_TextChanged);
            // 
            // LabelInfoText
            // 
            this.LabelInfoText.AutoSize = true;
            this.LabelInfoText.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelInfoText.Location = new System.Drawing.Point(71, 42);
            this.LabelInfoText.Name = "LabelInfoText";
            this.LabelInfoText.Size = new System.Drawing.Size(286, 15);
            this.LabelInfoText.TabIndex = 2;
            this.LabelInfoText.Text = "Games not in the list support automatic name detection";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(182, 232);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(288, 37);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GameSelector
            // 
            this.GameSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameSelector.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameSelector.FormattingEnabled = true;
            this.GameSelector.Location = new System.Drawing.Point(103, 80);
            this.GameSelector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GameSelector.Name = "GameSelector";
            this.GameSelector.Size = new System.Drawing.Size(248, 25);
            this.GameSelector.TabIndex = 4;
            this.GameSelector.SelectedIndexChanged += new System.EventHandler(this.GameSelector_SelectedIndexChanged);
            // 
            // ChangeAllButton
            // 
            this.ChangeAllButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeAllButton.Location = new System.Drawing.Point(24, 232);
            this.ChangeAllButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChangeAllButton.Name = "ChangeAllButton";
            this.ChangeAllButton.Size = new System.Drawing.Size(150, 37);
            this.ChangeAllButton.TabIndex = 5;
            this.ChangeAllButton.Text = "Save for all games";
            this.ChangeAllButton.UseVisualStyleBackColor = true;
            this.ChangeAllButton.Click += new System.EventHandler(this.ChangeAllButton_Click);
            // 
            // LabelGameSelector
            // 
            this.LabelGameSelector.AutoSize = true;
            this.LabelGameSelector.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelGameSelector.Location = new System.Drawing.Point(44, 85);
            this.LabelGameSelector.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelGameSelector.Name = "LabelGameSelector";
            this.LabelGameSelector.Size = new System.Drawing.Size(41, 15);
            this.LabelGameSelector.TabIndex = 6;
            this.LabelGameSelector.Text = "Game:";
            // 
            // LabelPlayerNameBox
            // 
            this.LabelPlayerNameBox.AutoSize = true;
            this.LabelPlayerNameBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelPlayerNameBox.Location = new System.Drawing.Point(43, 123);
            this.LabelPlayerNameBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelPlayerNameBox.Name = "LabelPlayerNameBox";
            this.LabelPlayerNameBox.Size = new System.Drawing.Size(42, 15);
            this.LabelPlayerNameBox.TabIndex = 7;
            this.LabelPlayerNameBox.Text = "Name:";
            // 
            // GroupBoxPlayerName
            // 
            this.GroupBoxPlayerName.Controls.Add(this.LabelInfoText);
            this.GroupBoxPlayerName.Controls.Add(this.LabelInfoIcon);
            this.GroupBoxPlayerName.Controls.Add(this.LabelPlayerNameBox);
            this.GroupBoxPlayerName.Controls.Add(this.PlayerNameBox);
            this.GroupBoxPlayerName.Controls.Add(this.LabelGameSelector);
            this.GroupBoxPlayerName.Controls.Add(this.GameSelector);
            this.GroupBoxPlayerName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GroupBoxPlayerName.Location = new System.Drawing.Point(24, 20);
            this.GroupBoxPlayerName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBoxPlayerName.Name = "GroupBoxPlayerName";
            this.GroupBoxPlayerName.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupBoxPlayerName.Size = new System.Drawing.Size(446, 177);
            this.GroupBoxPlayerName.TabIndex = 8;
            this.GroupBoxPlayerName.TabStop = false;
            this.GroupBoxPlayerName.Text = "Configure in-game name (without prefix/clan tag)";
            // 
            // LabelInfoIcon
            // 
            this.LabelInfoIcon.AutoSize = true;
            this.LabelInfoIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelInfoIcon.Location = new System.Drawing.Point(41, 38);
            this.LabelInfoIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelInfoIcon.Name = "LabelInfoIcon";
            this.LabelInfoIcon.Size = new System.Drawing.Size(30, 20);
            this.LabelInfoIcon.TabIndex = 8;
            this.LabelInfoIcon.Text = "ℹ";
            // 
            // GatherServerInfoCheckBox
            // 
            this.GatherServerInfoCheckBox.AutoSize = true;
            this.GatherServerInfoCheckBox.Location = new System.Drawing.Point(26, 204);
            this.GatherServerInfoCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GatherServerInfoCheckBox.Name = "GatherServerInfoCheckBox";
            this.GatherServerInfoCheckBox.Size = new System.Drawing.Size(399, 19);
            this.GatherServerInfoCheckBox.TabIndex = 9;
            this.GatherServerInfoCheckBox.Text = "Anonymously gather Battlefield 1 data for use with the api and widgets";
            this.gatherDataCheckboxTooltip.SetToolTip(this.GatherServerInfoCheckBox, resources.GetString("GatherServerInfoCheckBox.ToolTip"));
            this.GatherServerInfoCheckBox.UseVisualStyleBackColor = true;
            this.GatherServerInfoCheckBox.CheckedChanged += new System.EventHandler(this.GatherServerInfoCheckBox_CheckedChanged);
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 290);
            this.Controls.Add(this.GatherServerInfoCheckBox);
            this.Controls.Add(this.GroupBoxPlayerName);
            this.Controls.Add(this.ChangeAllButton);
            this.Controls.Add(this.SaveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "EditWindow";
            this.Text = "Edit settings";
            this.GroupBoxPlayerName.ResumeLayout(false);
            this.GroupBoxPlayerName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private CheckBox GatherServerInfoCheckBox;
        private ToolTip gatherDataCheckboxTooltip;
    }
}