namespace ShootingStarsGame
{
    partial class GameOverScreen
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
            this.btnAgain = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.finalScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgain
            // 
            this.btnAgain.Location = new System.Drawing.Point(147, 421);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(209, 72);
            this.btnAgain.TabIndex = 0;
            this.btnAgain.Text = "Обиди се повторно!";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(423, 421);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(209, 72);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Излез!";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(175, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Освоени поени: ";
            // 
            // finalScore
            // 
            this.finalScore.AutoSize = true;
            this.finalScore.ForeColor = System.Drawing.SystemColors.InfoText;
            this.finalScore.Location = new System.Drawing.Point(521, 344);
            this.finalScore.Name = "finalScore";
            this.finalScore.Size = new System.Drawing.Size(7, 13);
            this.finalScore.TabIndex = 3;
            this.finalScore.Text = "\r\n";
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ShootingStarsGame.Properties.Resources.gameOver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.finalScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAgain);
            this.Name = "GameOverScreen";
            this.Text = "GameOverScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameOverScreen_FormClosing);
            this.Load += new System.EventHandler(this.GameOverScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOverScreen_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label finalScore;
    }
}