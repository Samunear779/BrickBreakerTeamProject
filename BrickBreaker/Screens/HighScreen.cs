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
    public partial class HighScreen : UserControl
    {
		string name1, name2, name3, name4, name5, name6, name7, name8, name9, name10;
		int score1, score2, score3, score4, score5, score6, score7, score8, score9, score10;

		public HighScreen()
        {
            InitializeComponent();

        }



        private void menuButton_Click(object sender, EventArgs e)
        {

            Form form = this.FindForm();
            MenuScreen ms = new MenuScreen();

            ms.Location = new Point((form.Width - ms.Width) / 2, (form.Height - ms.Height) / 2);

            form.Controls.Add(ms);
            form.Controls.Remove(this);
        }

        private void HighScreen_Load(object sender, EventArgs e)

		
		{
           
            XmlReader reader = XmlReader.Create("Resources/HighScores.xml");

			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Text)
				{
					name1 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score1 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name2 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score2 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name3 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score3 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name4 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score4 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name5 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score5 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name6 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score6 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name7 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score7 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name8 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score8 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name9 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score9 = Convert.ToInt16(reader.ReadString());

					reader.ReadToNextSibling("name");
					name10 = reader.ReadString();
					reader.ReadToNextSibling("score");
					score10 = Convert.ToInt16(reader.ReadString());
				}
			}
			reader.Close();
			highScores.Text = "1. " + name1 + " - " + score1 + "\n" + "\n" +
				  "2. " + name2 + " - " + score2 + "\n" + "\n" +
				   "3. " + name3 + " - " + score3 + "\n" + "\n" +
					"4. " + name4 + " - " + score4 + "\n" + "\n" +
					 "5. " + name5 + " - " + score5 + "\n" + "\n" +
					  "6. " + name6 + " - " + score6 + "\n" + "\n" +
					   "7. " + name7 + " - " + score7 + "\n" + "\n" +
						"8. " + name8 + " - " + score8 + "\n" + "\n" +
						 "9. " + name9 + " - " + score9 + "\n" + "\n" +
						  "10. " + name10 + " - " + score10;
		}

		

        private void allign()
        {

            menuButton.Location = new Point((this.Width - menuButton.Width) / 2, (this.Height - menuButton.Height) / 2);

        }
    }
}
