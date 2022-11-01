namespace SnelToetsenSjezer.WinForms.Forms
{
    partial class GameOverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.NumHotKeysLabel = new System.Windows.Forms.Label();
            this.TimeSpentLabel = new System.Windows.Forms.Label();
            this.NumHotKeysValue = new System.Windows.Forms.Label();
            this.TimeSpentValue = new System.Windows.Forms.Label();
            this.HotKeyDetailsContainer = new System.Windows.Forms.Panel();
            this.HotKeyDetailsPanel = new System.Windows.Forms.Panel();
            this.HotKeyDetails_TimeColumnLabel = new System.Windows.Forms.Label();
            this.HotKeyDetails_AttemptsColumnLabel = new System.Windows.Forms.Label();
            this.HotKeyDetails_HotKeyColumnLabel = new System.Windows.Forms.Label();
            this.HotKeyDetailsLabel = new System.Windows.Forms.Label();
            this.HotKeyDetailsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumHotKeysLabel
            // 
            this.NumHotKeysLabel.Location = new System.Drawing.Point(12, 8);
            this.NumHotKeysLabel.Name = "NumHotKeysLabel";
            this.NumHotKeysLabel.Size = new System.Drawing.Size(160, 22);
            this.NumHotKeysLabel.TabIndex = 0;
            this.NumHotKeysLabel.Text = "Number of Hotkeys:";
            this.NumHotKeysLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeSpentLabel
            // 
            this.TimeSpentLabel.Location = new System.Drawing.Point(12, 30);
            this.TimeSpentLabel.Name = "TimeSpentLabel";
            this.TimeSpentLabel.Size = new System.Drawing.Size(160, 22);
            this.TimeSpentLabel.TabIndex = 1;
            this.TimeSpentLabel.Text = "Total time spent:";
            this.TimeSpentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumHotKeysValue
            // 
            this.NumHotKeysValue.Location = new System.Drawing.Point(178, 8);
            this.NumHotKeysValue.Name = "NumHotKeysValue";
            this.NumHotKeysValue.Size = new System.Drawing.Size(160, 22);
            this.NumHotKeysValue.TabIndex = 0;
            this.NumHotKeysValue.Text = "5";
            this.NumHotKeysValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeSpentValue
            // 
            this.TimeSpentValue.Location = new System.Drawing.Point(178, 30);
            this.TimeSpentValue.Name = "TimeSpentValue";
            this.TimeSpentValue.Size = new System.Drawing.Size(160, 22);
            this.TimeSpentValue.TabIndex = 0;
            this.TimeSpentValue.Text = "00:25";
            this.TimeSpentValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HotKeyDetailsContainer
            // 
            this.HotKeyDetailsContainer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HotKeyDetailsContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HotKeyDetailsContainer.Controls.Add(this.HotKeyDetailsPanel);
            this.HotKeyDetailsContainer.Controls.Add(this.HotKeyDetails_TimeColumnLabel);
            this.HotKeyDetailsContainer.Controls.Add(this.HotKeyDetails_AttemptsColumnLabel);
            this.HotKeyDetailsContainer.Controls.Add(this.HotKeyDetails_HotKeyColumnLabel);
            this.HotKeyDetailsContainer.Location = new System.Drawing.Point(12, 77);
            this.HotKeyDetailsContainer.Name = "HotKeyDetailsContainer";
            this.HotKeyDetailsContainer.Size = new System.Drawing.Size(776, 310);
            this.HotKeyDetailsContainer.TabIndex = 2;
            // 
            // HotKeyDetailsPanel
            // 
            this.HotKeyDetailsPanel.AutoScroll = true;
            this.HotKeyDetailsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.HotKeyDetailsPanel.Location = new System.Drawing.Point(2, 26);
            this.HotKeyDetailsPanel.Name = "HotKeyDetailsPanel";
            this.HotKeyDetailsPanel.Size = new System.Drawing.Size(768, 278);
            this.HotKeyDetailsPanel.TabIndex = 1;
            // 
            // HotKeyDetails_TimeColumnLabel
            // 
            this.HotKeyDetails_TimeColumnLabel.Location = new System.Drawing.Point(605, 1);
            this.HotKeyDetails_TimeColumnLabel.Name = "HotKeyDetails_TimeColumnLabel";
            this.HotKeyDetails_TimeColumnLabel.Size = new System.Drawing.Size(160, 22);
            this.HotKeyDetails_TimeColumnLabel.TabIndex = 0;
            this.HotKeyDetails_TimeColumnLabel.Text = "Time";
            this.HotKeyDetails_TimeColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HotKeyDetails_AttemptsColumnLabel
            // 
            this.HotKeyDetails_AttemptsColumnLabel.Location = new System.Drawing.Point(440, 1);
            this.HotKeyDetails_AttemptsColumnLabel.Name = "HotKeyDetails_AttemptsColumnLabel";
            this.HotKeyDetails_AttemptsColumnLabel.Size = new System.Drawing.Size(160, 22);
            this.HotKeyDetails_AttemptsColumnLabel.TabIndex = 0;
            this.HotKeyDetails_AttemptsColumnLabel.Text = "Attempts";
            this.HotKeyDetails_AttemptsColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HotKeyDetails_HotKeyColumnLabel
            // 
            this.HotKeyDetails_HotKeyColumnLabel.Location = new System.Drawing.Point(3, 1);
            this.HotKeyDetails_HotKeyColumnLabel.Name = "HotKeyDetails_HotKeyColumnLabel";
            this.HotKeyDetails_HotKeyColumnLabel.Size = new System.Drawing.Size(425, 22);
            this.HotKeyDetails_HotKeyColumnLabel.TabIndex = 0;
            this.HotKeyDetails_HotKeyColumnLabel.Text = "Hotkey";
            this.HotKeyDetails_HotKeyColumnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HotKeyDetailsLabel
            // 
            this.HotKeyDetailsLabel.Location = new System.Drawing.Point(12, 52);
            this.HotKeyDetailsLabel.Name = "HotKeyDetailsLabel";
            this.HotKeyDetailsLabel.Size = new System.Drawing.Size(160, 22);
            this.HotKeyDetailsLabel.TabIndex = 1;
            this.HotKeyDetailsLabel.Text = "Hotkey details:";
            this.HotKeyDetailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 397);
            this.Controls.Add(this.HotKeyDetailsContainer);
            this.Controls.Add(this.HotKeyDetailsLabel);
            this.Controls.Add(this.TimeSpentLabel);
            this.Controls.Add(this.TimeSpentValue);
            this.Controls.Add(this.NumHotKeysValue);
            this.Controls.Add(this.NumHotKeysLabel);
            this.Name = "GameOverForm";
            this.Text = "GameOver";
            this.HotKeyDetailsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label NumHotKeysLabel;
        private Label TimeSpentLabel;
        private Label NumHotKeysValue;
        private Label TimeSpentValue;
        private Panel HotKeyDetailsContainer;
        private Label HotKeyDetailsLabel;
        private Label HotKeyDetails_AttemptsColumnLabel;
        private Label HotKeyDetails_HotKeyColumnLabel;
        private Label HotKeyDetails_TimeColumnLabel;
        private Panel HotKeyDetailsPanel;
    }
}