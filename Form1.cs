using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShootingStarsGame
{
    public partial class Form1 : Form
    {
        private StarsDoc starsDoc;
        private int generateStar;
        private Random random;
        private Timer timer;
        private string FileName;
       static string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);// da se najde avtomatski lokacijata
       static string Apath = appPath.Substring(0,appPath.Length-10);
        static string finaly = Apath + "\\Resources\\backVP.jpg";
        Image myimage = new Bitmap(finaly);

        public Form1()
        {
            InitializeComponent();
            starsDoc = new StarsDoc();
            generateStar = 0;
            random = new Random();
            timer = new Timer();
            timer.Interval = 70;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            DoubleBuffered = true;
        }
        
        void timer_Tick(object sender, EventArgs e)
        {
            
            if (generateStar % 15 == 0) //vreme za generiranje zvezda
            {
                int x = random.Next(2 * Star.RADIUS, Height - (Star.RADIUS * 2));
                int y = -Star.RADIUS;
                starsDoc.AddStar(new Point(x, y));
            }
            ++generateStar;
            starsDoc.Move(Width, Height);
            Invalidate(true);
            if (starsDoc.Score >= 30) { //lvl 2
                timer.Interval = 60;
            }
            if (starsDoc.Score >= 60) {//lvl 3
                timer.Interval = 35;     
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(myimage,0,0,this.Width,this.Height);
            starsDoc.Draw(e.Graphics);
        }

        public void Operiraj() {
            GameOverScreen gm = new GameOverScreen();
            gm.Show();
            gm.UpdateScore();
            this.Hide();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            starsDoc.Hit(e.Location);
            Invalidate(true);
        }
        
        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Stars doc file (*.str)|*.str";
                saveFileDialog.Title = "Save stars doc";
                saveFileDialog.FileName = FileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, starsDoc);
                }
            }
        }
        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Stars doc file (*.str)|*.str";
            openFileDialog.Title = "Open stars doc file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        starsDoc = (StarsDoc)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                Invalidate(true);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {

            lblTotalScore.Text = string.Format("Резултат: {0}", starsDoc.Score);
            lblZivoti.Text = string.Format("Животи: {0}", starsDoc.missedStars);
        }

        public string getTotal() {
            return lblTotalScore.Text;
        }
    }
}
