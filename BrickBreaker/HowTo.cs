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
    public partial class HowTo : UserControl
    {
        public HowTo()
        {
            InitializeComponent();
            title.Location = new Point((this.Width - title.Width) / 2, 35);
        }
    }
}
