using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBinProjekt
{
 
    public partial class Form1 : Form
    {
          COrgLieferanten myobj = new COrgLieferanten();

        public Form1()
        {
            //COrgLieferanten myobj = new COrgLieferanten();
            InitializeComponent();

            //textBox1.Text = myobj.Lifnr.ToString();
            //textBox2.Text = myobj.Matchcode;

            textBox1.DataBindings.Add(new Binding ("Text", myobj, "Lifnr"));

            textBox2.DataBindings.Add(new Binding ("Text", myobj, "Matchcode"));

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (COrgLieferanten.safe(textBox1.Text, textBox2.Text) != "1")
                {
                    MessageBox.Show(COrgLieferanten.safe(textBox1.Text, textBox2.Text).ToString());
                }

            }
           
        }
    }
}
