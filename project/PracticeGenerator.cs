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
       
            listBox2.Items.Add("Practice Schedule");
            listBox2.Items.Add("");
        }

        private void loadData()
        {

            LoadDataListBox1();
            LoadDataListBox2();
            LoadDataListBox3();
           
        }

        private void LoadDataListBox1()
        {
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            var file = new System.IO.StreamReader(@"file1.txt");
            String line;
            while ((line = file.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }
        }

        private void LoadDataListBox2()
        {
            listBox3.SelectionMode = SelectionMode.MultiSimple;
            var file = new System.IO.StreamReader(@"file2.txt");
            String line;
            while ((line = file.ReadLine()) != null)
            {
                listBox3.Items.Add(line);
            }
        }


        private void LoadDataListBox3()
        {
            listBox4.SelectionMode = SelectionMode.MultiSimple;
            var file = new System.IO.StreamReader(@"file3.txt");
            String line;
            while ((line = file.ReadLine()) != null)
            {
                listBox4.Items.Add(line);
            }
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("Practice Schedule");
            listBox2.Items.Add("");
            listBox1.ClearSelected();
            listBox3.ClearSelected();
            listBox4.ClearSelected();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            int added1 = addItemsFromList1();
            int added2 = addItemsFromList2();
            int added3 = addItemsFromList3();
            if(added1+ added2+added3 == 0)
            {
                addRandom();
            }
            saveToFile();

        }

        private void addRandom()
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("Practice Schedule");
            listBox2.Items.Add("");
            DateTime time = new DateTime(1, 1, 1, 8,0, 0); //initialize with 9 am
            Random rnd = new Random();

            int count = 0;
            foreach (var item in listBox1.Items)
            {
                int val = rnd.Next(1, 10);  // creates a number between 1 and 10 33% chance
                
                if (val % 3 == 0)
                {
                   
                    var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                    DateTime updatedTime = time.AddMinutes(30);
                    var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                    listBox2.Items.Add(interval1 + " - " + interval2 + "    " + item.ToString());
                    
                }
                count++;

            }

            count = 0;
            time = new DateTime(1, 1, 1, 8, 30, 0); //initialize with 9 am
            foreach (var item in listBox3.Items)
            {
                int val = rnd.Next(1, 10);  // creates a number between 1 and 10 33% chance
                if (val % 3 == 0)
                {
                    //listBox3.SetSelected(count, true);
                    var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                    DateTime updatedTime = time.AddMinutes(30);
                    var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                    listBox2.Items.Add(interval1 + " - " + interval2 + "    " + item.ToString());
                   
                }
                count++;

            }

            count = 0;
            time = new DateTime(1, 1, 1, 9, 0, 0); //initialize with 9 am
            foreach (var item in listBox4.Items)
            {
                int val = rnd.Next(1, 10);  // creates a number between 1 and 10 33% chance
                if (val % 3 == 0)
                {
                    //listBox4.SetSelected(count, true);
                    var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                    DateTime updatedTime = time.AddMinutes(30);
                    var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                    listBox2.Items.Add(interval1 + " - " + interval2 + "    " + item.ToString());
                
                }
                count++;

            }

        }

        private void saveToFile()
        {
            using (StreamWriter writer = new StreamWriter("result.txt", false))
            {
                foreach (var item in listBox2.Items)
                {
                    writer.Write(item.ToString()+Environment.NewLine);
                }
                    
            }

        }

        private int addItemsFromList3()
        {
           DateTime time = new DateTime(1, 1, 1, 9, 0, 0); //initialize with 9 am
            int count = 0;
            foreach (var item in listBox4.SelectedItems)
            {
                var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                DateTime updatedTime = time.AddMinutes(30);
                var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                listBox2.Items.Add(interval1 + " - " + interval2 + "    " + item.ToString());
                count++;
            }
            return count;
        }

        private int addItemsFromList2()
        {
            DateTime time = new DateTime(1, 1, 1, 8, 30, 0); //initialize with 8:30 am
            int count = 0;
            foreach (var item in listBox3.SelectedItems)
            {
                var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                DateTime updatedTime = time.AddMinutes(30);
                var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                listBox2.Items.Add(interval1 + " - " + interval2 + "    " + item.ToString());
                count++;
            }
            return count;
        }

        private int addItemsFromList1()
        {
            DateTime time = new DateTime(1, 1, 1, 8, 0, 0); //initialize with 8 am
            int count = 0;
            foreach (var item in listBox1.SelectedItems)
            {
                var interval1 = time.ToString("hh:mm tt");   // this show  like am/pm
                DateTime updatedTime = time.AddMinutes(30);
                var interval2 = updatedTime.ToString("hh:mm tt");   // this show  am/pm
                listBox2.Items.Add(interval1 + " - " + interval2 + "    " + item.ToString());
                count++;
            
            }
            return count;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PracticeGenerator_Load(object sender, EventArgs e)
        {

        }
    }
}
