using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yemektarifleri
{
    public partial class Malzemeyegöreara : Form
    {
        public Malzemeyegöreara()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            panel2.AutoScroll = true;
            sorgu.Malzemeleripanelekoy(panel1, panel2);
        }


        private void Malzemeyegöreara_Load(object sender, EventArgs e)
        {

        }

        private void Malzemeyegöreara_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form=new Form1();
            form.Show();

        }
    }
}
