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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWindow));
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GameSelector = new System.Windows.Forms.ComboBox();
            this.ChangeAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Location = new System.Drawing.Point(139, 41);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(154, 20);
            this.PlayerNameBox.TabIndex = 0;
            this.PlayerNameBox.TextChanged += new System.EventHandler(this.PlayerNameBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "If you are playing Battlefield titles older than Battlefield 1,\nfill in your in g" +
    "ame name (without prefix/clan tag)";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(299, 40);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 22);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // GameSelector
            // 
            this.GameSelector.FormattingEnabled = true;
            this.GameSelector.Location = new System.Drawing.Point(12, 41);
            this.GameSelector.Name = "GameSelector";
            this.GameSelector.Size = new System.Drawing.Size(121, 21);
            this.GameSelector.TabIndex = 4;
            this.GameSelector.SelectedIndexChanged += new System.EventHandler(this.GameSelector_SelectedIndexChanged);
            // 
            // ChangeAllButton
            // 
            this.ChangeAllButton.Location = new System.Drawing.Point(379, 40);
            this.ChangeAllButton.Name = "ChangeAllButton";
            this.ChangeAllButton.Size = new System.Drawing.Size(75, 22);
            this.ChangeAllButton.TabIndex = 5;
            this.ChangeAllButton.Text = "Change all";
            this.ChangeAllButton.UseVisualStyleBackColor = true;
            this.ChangeAllButton.Click += new System.EventHandler(this.ChangeAllButton_Click);
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 73);
            this.Controls.Add(this.ChangeAllButton);
            this.Controls.Add(this.GameSelector);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayerNameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditWindow";
            this.Text = "Edit settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox PlayerNameBox;
        private Label label2;
        private Button SaveButton;
        private ComboBox GameSelector;
        private Button ChangeAllButton;
    }
}