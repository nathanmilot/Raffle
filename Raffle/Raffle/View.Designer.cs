namespace Raffle {
    partial class View {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.select_winner_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRaffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remove_user_option = new System.Windows.Forms.ToolStripMenuItem();
            this.show_remaining_option = new System.Windows.Forms.ToolStripMenuItem();
            this.show_count_option = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.raffle_winner_lbl = new System.Windows.Forms.TextBox();
            this.contestants_list = new System.Windows.Forms.ListView();
            this.Contestant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // select_winner_btn
            // 
            this.select_winner_btn.Location = new System.Drawing.Point(126, 85);
            this.select_winner_btn.Name = "select_winner_btn";
            this.select_winner_btn.Size = new System.Drawing.Size(148, 23);
            this.select_winner_btn.TabIndex = 0;
            this.select_winner_btn.Text = "Select Another Winner";
            this.select_winner_btn.UseVisualStyleBackColor = true;
            this.select_winner_btn.Click += new System.EventHandler(this.Select_winner_btn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(401, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRaffleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openRaffleToolStripMenuItem
            // 
            this.openRaffleToolStripMenuItem.Name = "openRaffleToolStripMenuItem";
            this.openRaffleToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openRaffleToolStripMenuItem.Text = "Open Raffle";
            this.openRaffleToolStripMenuItem.Click += new System.EventHandler(this.OpenRaffleToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remove_user_option,
            this.show_remaining_option,
            this.show_count_option});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // remove_user_option
            // 
            this.remove_user_option.Name = "remove_user_option";
            this.remove_user_option.Size = new System.Drawing.Size(255, 22);
            this.remove_user_option.Text = "Remove Contestant After Winning";
            this.remove_user_option.Click += new System.EventHandler(this.Remove_user_option_Click);
            // 
            // show_remaining_option
            // 
            this.show_remaining_option.Checked = true;
            this.show_remaining_option.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_remaining_option.Name = "show_remaining_option";
            this.show_remaining_option.Size = new System.Drawing.Size(255, 22);
            this.show_remaining_option.Text = "Show Remaining Contestants";
            this.show_remaining_option.Click += new System.EventHandler(this.ShowRemainingContestantsToolStripMenuItem_Click);
            // 
            // show_count_option
            // 
            this.show_count_option.Name = "show_count_option";
            this.show_count_option.Size = new System.Drawing.Size(255, 22);
            this.show_count_option.Text = "Show Contestants Entry Count";
            this.show_count_option.Click += new System.EventHandler(this.ShowContestantsCountToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Winner";
            // 
            // raffle_winner_lbl
            // 
            this.raffle_winner_lbl.Location = new System.Drawing.Point(90, 60);
            this.raffle_winner_lbl.Name = "raffle_winner_lbl";
            this.raffle_winner_lbl.ReadOnly = true;
            this.raffle_winner_lbl.Size = new System.Drawing.Size(221, 20);
            this.raffle_winner_lbl.TabIndex = 5;
            this.raffle_winner_lbl.TabStop = false;
            this.raffle_winner_lbl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contestants_list
            // 
            this.contestants_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Contestant,
            this.Count});
            this.contestants_list.Location = new System.Drawing.Point(90, 122);
            this.contestants_list.Name = "contestants_list";
            this.contestants_list.Size = new System.Drawing.Size(221, 147);
            this.contestants_list.TabIndex = 6;
            this.contestants_list.TabStop = false;
            this.contestants_list.UseCompatibleStateImageBehavior = false;
            this.contestants_list.View = System.Windows.Forms.View.Details;
            // 
            // Contestant
            // 
            this.Contestant.Text = "Name";
            this.Contestant.Width = 107;
            // 
            // Count
            // 
            this.Count.Text = "Entries";
            this.Count.Width = 107;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 281);
            this.Controls.Add(this.contestants_list);
            this.Controls.Add(this.raffle_winner_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_winner_btn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "View";
            this.Text = "Raffle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select_winner_btn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRaffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remove_user_option;
        private System.Windows.Forms.ToolStripMenuItem show_remaining_option;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox raffle_winner_lbl;
        private System.Windows.Forms.ToolStripMenuItem show_count_option;
        private System.Windows.Forms.ListView contestants_list;
        private System.Windows.Forms.ColumnHeader Contestant;
        private System.Windows.Forms.ColumnHeader Count;
    }
}

