namespace Raffle {
    partial class Form1 {
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
            this.raffle_winner_lbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRaffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // select_winner_btn
            // 
            this.select_winner_btn.Location = new System.Drawing.Point(115, 79);
            this.select_winner_btn.Name = "select_winner_btn";
            this.select_winner_btn.Size = new System.Drawing.Size(148, 23);
            this.select_winner_btn.TabIndex = 0;
            this.select_winner_btn.Text = "Select Another Winner";
            this.select_winner_btn.UseVisualStyleBackColor = true;
            this.select_winner_btn.Click += new System.EventHandler(this.select_winner_btn_Click);
            // 
            // raffle_winner_lbl
            // 
            this.raffle_winner_lbl.AutoSize = true;
            this.raffle_winner_lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raffle_winner_lbl.Location = new System.Drawing.Point(115, 48);
            this.raffle_winner_lbl.Name = "raffle_winner_lbl";
            this.raffle_winner_lbl.Size = new System.Drawing.Size(61, 18);
            this.raffle_winner_lbl.TabIndex = 1;
            this.raffle_winner_lbl.Text = "Winner:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
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
            this.openRaffleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openRaffleToolStripMenuItem.Text = "Open Raffle";
            this.openRaffleToolStripMenuItem.Click += new System.EventHandler(this.openRaffleToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 129);
            this.Controls.Add(this.raffle_winner_lbl);
            this.Controls.Add(this.select_winner_btn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Raffle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button select_winner_btn;
        private System.Windows.Forms.Label raffle_winner_lbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRaffleToolStripMenuItem;
    }
}

