namespace SnelToetsenSjezer
{
    partial class MainMenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_startgame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_categories = new System.Windows.Forms.CheckedListBox();
            this.lbl_howmanyquestions = new System.Windows.Forms.Label();
            this.num_howmanyquestions = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_howmanyquestions)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_startgame
            // 
            this.btn_startgame.Font = new System.Drawing.Font("Segoe UI", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_startgame.Location = new System.Drawing.Point(12, 287);
            this.btn_startgame.Name = "btn_startgame";
            this.btn_startgame.Size = new System.Drawing.Size(560, 62);
            this.btn_startgame.TabIndex = 0;
            this.btn_startgame.Text = "Start!";
            this.btn_startgame.UseVisualStyleBackColor = true;
            this.btn_startgame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pick one or multiple categories and choose how many questions you want, then star" +
    "t the game!";
            // 
            // lb_categories
            // 
            this.lb_categories.CheckOnClick = true;
            this.lb_categories.FormattingEnabled = true;
            this.lb_categories.Location = new System.Drawing.Point(12, 32);
            this.lb_categories.Name = "lb_categories";
            this.lb_categories.Size = new System.Drawing.Size(560, 202);
            this.lb_categories.TabIndex = 2;
            this.lb_categories.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CategoriesItemCheckedChanged);
            this.lb_categories.SelectedIndexChanged += new System.EventHandler(this.CategoriesSelectedIndexChanged);
            // 
            // lbl_howmanyquestions
            // 
            this.lbl_howmanyquestions.Location = new System.Drawing.Point(12, 253);
            this.lbl_howmanyquestions.Name = "lbl_howmanyquestions";
            this.lbl_howmanyquestions.Size = new System.Drawing.Size(210, 23);
            this.lbl_howmanyquestions.TabIndex = 3;
            this.lbl_howmanyquestions.Text = "How many questions? (1-1)";
            this.lbl_howmanyquestions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_howmanyquestions
            // 
            this.num_howmanyquestions.Location = new System.Drawing.Point(228, 256);
            this.num_howmanyquestions.Name = "num_howmanyquestions";
            this.num_howmanyquestions.Size = new System.Drawing.Size(344, 23);
            this.num_howmanyquestions.TabIndex = 5;
            this.num_howmanyquestions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_howmanyquestions.ValueChanged += new System.EventHandler(this.HowManyQuestions_ValueChanged);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.num_howmanyquestions);
            this.Controls.Add(this.lbl_howmanyquestions);
            this.Controls.Add(this.lb_categories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startgame);
            this.Name = "MainMenuForm";
            this.Text = "SnelToetsenSjezer - Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.num_howmanyquestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_startgame;
        private Label label1;
        private CheckedListBox lb_categories;
        private Label lbl_howmanyquestions;
        private NumericUpDown num_howmanyquestions;
    }
}