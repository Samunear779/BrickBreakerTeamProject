using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Media;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
		public static bool twoPlayer = false;
		public static List<Score> highScores = new List<Score>();
		public Form1()
        {
            InitializeComponent();
			loadScores();
        }
        
        //Soundplayer for backMusic
//        public static SoundPlayer music = new SoundPlayer(Properties.Resources.backMusic);

        // wow ! ;D
        private void Form1_Load(object sender, EventArgs e)
        {
            
             
             //Start the program centred on the Menu Screen
             MenuScreen ms = new MenuScreen();
             this.Controls.Add(ms);

             ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

		public static void loadScores()
		{
			#region Strings and ints
			int score = 0;
			string name = null;
			Score s = new Score(name, score);
			#endregion

			XmlReader reader = XmlReader.Create("Resources/HighScores.xml");

			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Text)
				{
					//reader.ReadToFollowing("highscore");
					//reader.ReadToNextSibling("name");
				    s = new Score(name, score);
					s.name = reader.ReadString();
					reader.ReadToNextSibling("score");
					s.score = Convert.ToInt16(reader.ReadString());

					if (s.name != null)
					{
						highScores.Add(s);
					}
				}
			}
			reader.Close();
		}

        public static void ChangeScreen(UserControl current, string next)
        {
            //f is set to the form that the current control is on
            Form f = current.FindForm();
            f.Controls.Remove(current);
            UserControl ns = null;
            
            //switches screen
            switch (next)
            {
                case "MenuScreen":
                    ns = new MenuScreen();
                    break;
                case "GameScreen":
                    ns = new GameScreen();
                    break;
                case "HighScreen":
                    ns = new HighScreen();
                    break;
                case "NameScreen":
                    ns = new NameScreen1();
                    break;
            }
            //centres on the screen
            ns.Location = new Point((f.Width - ns.Width) / 2, (f.Height - ns.Height) / 2);
           
            f.Controls.Add(ns);
            ns.Focus();
        }
    }
}
