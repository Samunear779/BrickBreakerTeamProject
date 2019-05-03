using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
					}

					switch (initial)
					{
						case 1:
							initial1.Text = "" + c;
							break;
						case 2:
							initial2.Text = "" + c;
							break;
						case 3:
							initial3.Text = "" + c;
							break;
					}
				}
				else
				{
					name = initial1.Text + initial2.Text + initial3.Text;
				}
			}
		}
	}
}
