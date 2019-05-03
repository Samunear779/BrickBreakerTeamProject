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
    public partial class MenuScreen : UserControl
    {
       
        public MenuScreen()
        {
            InitializeComponent();
            lorenAllignment();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen  
            Form1.ChangeScreen(this,"GameScreen");
        }

        private void lorenAllignment()
        {
            playButton.Location = new Point((this.Width - playButton.Width) / 2, 240);            
            exitButton.Location = new Point((this.Width - exitButton.Width) / 2, 400);
            title.Location = new Point((this.Width - title.Width) / 2, 130);
        }

		private void showDebug_CheckedChanged(object sender, EventArgs e)
		{
			if (showDebug.Checked == true)
			{
				highButton.Visible = true;
				nameButton.Visible = true;
			}
			else
			{
				highButton.Visible = false;
				nameButton.Visible = false;
			}
		}

		private void nameButton_Click(object sender, EventArgs e)
		{
			Form1.ChangeScreen(this, "NameScreen");
		}

        private void highButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, "HighScreen");
        }
    }
}
