using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingStarsGame
{
    public partial class GameOverScreen : Form
    {
        static string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);// da se najde avtomatski lokacijata
        static string Apath = appPath.Substring(0, appPath.Length - 10);
        static string finaly = Apath + "\\Resources\\gameOver.jpg";
        Image myimage = new Bitmap(finaly);
      //  public StarsDoc st = new StarsDoc();
        public GameOverScreen()
        {
            InitializeComponent();
            //finalScore.Text = txt;
        }

        private void GameOverScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(myimage, 0, 0, this.Width, this.Height);
        }

        public void UpdateScore()
        {
            Form1 fm1 = new Form1();
            finalScore.Text = fm1.getTotal();
            //finalScore.Text = string.Format("{0}",score);
        }

        public void btnAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblScoreOver_Click(object sender, EventArgs e)
        {

        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
        }

        private void GameOverScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
