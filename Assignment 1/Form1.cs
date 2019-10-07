using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1
{
    public partial class Form1 : Form
    {
        engine engine;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new engine(this, this.groupBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            engine.UpdateMap();
            engine.UpdateDisplay();
            label1.Text = (++count).ToString();
        }

        public void displayInfo(string message) //Adds the units into the listbox so that they may be displayed on screen
        {
            listBox1.Items.Add(message);
        }

        private void button1_Click(object sender, EventArgs e) //Each time btn1 is clicked the engine will update the map and display,
                                                               //then add a count to the label so users can see which turn round are on
        {
            engine.UpdateMap();
            engine.UpdateDisplay();
            label1.Text = (++count).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
