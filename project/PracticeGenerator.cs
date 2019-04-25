using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class PracticeGenerator : Form
    {
        public PracticeGenerator()
        {
            InitializeComponent();
            loadData();
       
            listBox2.Items.Add("");
            listBox2.Items.Add("");
        }

        private void loadData()
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            var file = new System.IO.StreamReader(@"file.txt");
            String line;
            while ((line = file.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("");
            listBox2.Items.Add("");
            listBox1.ClearSelected();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            DateTime time = new DateTime(1, 1, 1, 20, 0, 0); //initialize with 8 pm
          

            foreach (var item in listBox1.SelectedItems)
            {
                var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                DateTime updatedTime = time.AddMinutes(30);
                var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                listBox2.Items.Add(interval1 + " - "+ interval2+"    " + item.ToString());
                time = updatedTime;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
