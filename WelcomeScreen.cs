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
    public partial class WelcomeScreen : Form
    {
        static string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);// da se najde avtomatski lokacijata
        static string Apath = appPath.Substring(0, appPath.Length - 10);
        static string finaly = Apath + "\\Resources\\welcomeScreen1.jpg";
        Image myimage = new Bitmap(finaly);
        

        public WelcomeScreen()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void WelcomeScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(myimage, 0, 0, this.Width, this.Height);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 nextLevel = new Form1();
            nextLevel.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
