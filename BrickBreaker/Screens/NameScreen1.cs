using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BrickBreaker
{
    public partial class NameScreen1 : UserControl
    {
        public NameScreen1()
        {
            InitializeComponent();
            scoreText.Location = new Point((this.Width - scoreText.Width) / 2, 55);
            initial1.Location = new Point((initial2.Location.X - initial1.Width), (this.Height - initial1.Height) / 2);
            initial2.Location = new Point((this.Width - initial2.Width) / 2, (this.Height - initial2.Height) / 2);
            initial3.Location = new Point((initial2.Location.X + initial2.Width), (this.Height - initial3.Height) / 2);
        }
		int initial = 1;
		char c = 'A';
		string name = null;

		private void NameScreen1_Load(object sender, EventArgs e)
		{
			scoreText.Text = "YOUR SCORE WAS " + GameScreen.score;
		}

		private void NameScreen1_KeyDown(object sender, KeyEventArgs e)
		{
			{
				Score s = new Score(name, GameScreen.score);

				if (initial < 4)
				{
					switch (e.KeyCode)
					{
						case Keys.S:
							if (c != 'Z')
							{
								c++;
							}
							break;

						case Keys.W:
							if (c != 'A')
							{
								c--;
							}
							break;

						case Keys.Enter:
							initial++;
							c = 'A';
							break;

						case Keys.Escape:
							SaveScores();
							Form1.ChangeScreen(this, "MenuScreen");
							break;
					}

					switch (initial)
					{
						case 1:
							initial1.BackColor = Color.Cyan;
							initial1.ForeColor = Color.Transparent;
							initial1.Text = "" + c;
							break;
						case 2:
							initial1.BackColor = Color.Transparent;
							initial1.ForeColor = Color.Cyan;

							initial2.BackColor = Color.Cyan;
							initial2.ForeColor = Color.Transparent;
							initial2.Text = "" + c;
							break;
						case 3:
							initial2.BackColor = Color.Transparent;
							initial2.ForeColor = Color.Cyan;

							initial3.BackColor = Color.Cyan;
							initial3.ForeColor = Color.Transparent;
							initial3.Text = "" + c;
							break;
					}
				}
				else
				{
					initial3.BackColor = Color.Transparent;
					initial3.ForeColor = Color.Cyan;
					name = initial1.Text + initial2.Text + initial3.Text;
					s.name = name;
					s.score = GameScreen.score;
					Form1.highScores.Add(s);
					Form1.highScores = Form1.highScores.OrderBy(x => (x.score * -1)).ToList();
					SaveScores();
					Form1.ChangeScreen(this, "HighScreen");
				}
			}
		}

		private void SaveScores()
		{
			XmlWriter writer = XmlWriter.Create("Resources/HighScores.xml");

			writer.WriteStartElement("highscore");

			foreach (Score s in Form1.highScores)
			{

				writer.WriteElementString("name", s.name);
				writer.WriteElementString("score", Convert.ToString(s.score));

			}
			writer.WriteEndElement();

			writer.Close();
		}
	}
}
