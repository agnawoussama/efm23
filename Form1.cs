using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace efm23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Exercice2 bt2 = new Exercice2();
            panel2.Controls.Add(bt2);
            bt2.Dock = DockStyle.Fill;
            bt2.BringToFront();
            bt2.Show();
        }
    }
}
