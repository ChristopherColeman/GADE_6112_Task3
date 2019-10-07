using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Assignment_1
{
    class engine
    {
        public Map myMap = new Map();
        private Form1 form;
        private GroupBox messageGroup;
        private Form1 form1;
        private GroupBox groupBox1;

        public engine(Form1 form, GroupBox messageGroup)
        {
            this.form = form; //makes a form variable which is made equal to the form so that you can edit the components
            this.messageGroup = messageGroup;
            foreach (Unit u in myMap.units)
            {
                Button b = new Button();
                b.Location = new Point(u.X * 35, u.Y * 35); //shows the new point where the unit will spawn
                b.Size = new Size(30, 30); //shows the size for said unit
                b.Text = u.Symbol; //this represents which unit in the array it is

                if (u.Team == 0) //will have red background
                {
                    b.BackColor = Color.Red;
                }
                else
                {
                    b.BackColor = Color.Green; //will have green background
                }

                if (u.GetType() == typeof(MeleeUnit))
                {
                    b.ForeColor = Color.White; //shows that text will be white to show melee unit
                }
                else
                {
                    b.ForeColor = Color.Black; //shows that text will be black to represent a ranged unit
                }

                b.Click += buttonClick;
                this.form.Controls.Add(b);
            }
        }

        public void gameEngine(Form1 form1, GroupBox groupBox1)
        {
            this.form1 = form1;
            this.groupBox1 = groupBox1;
        } //This is the constructor for the game engine

        public void UpdateDisplay()
        {
            form.Controls.Clear(); //clears the entire form so that it can update it without clashing with the previous locations
            form.Controls.Add(messageGroup); //adds message if a unit dies
            foreach (Unit u in myMap.units)
            {
                Button b = new Button();
                b.Location = new Point(u.X * 35, u.Y * 35);
                b.Size = new Size(30, 30);
                b.Text = u.Symbol;

                if (u.Team == 0)
                {
                    b.BackColor = Color.Red;
                }
                else
                {
                    b.BackColor = Color.Green;
                }

                if (u.GetType() == typeof(MeleeUnit))
                {
                    b.ForeColor = Color.White;
                }
                else
                {
                    b.ForeColor = Color.Black;
                }

                b.Click += buttonClick;
                this.form.Controls.Add(b);
            }
        }

        public void UpdateMap()
        {
            foreach (Unit u in myMap.units) //runs loop for each unit in the array
            {
                Unit closestUnit = u.Closest(ref myMap.units); //determines which unit is closest to the current unit
                //      listBox1.Items.Add(u.ToString() + " -- " + closestUnit.ToString());
                try
                {
                    u.Move(ref closestUnit); //testing to see whether the unit can move
                }
                catch (MeleeUnit.DeathException d) //if unit cannot move it is dead, this catch will manage the message displayed
                {
                    form.displayInfo(d.Message); //displays unit is dead, removes unit from array
                    Unit[] temp = new Unit[myMap.units.Count() - 1];
                    int j = 0;
                    for (int i = 0; i < myMap.units.Count(); i++) //remakes array without the dead unit
                    {
                        if (u != myMap.units[i])
                        {
                            temp[j++] = myMap.units[i];
                        }
                    }

                    myMap.units = temp;
                }
            }
        }

        public void buttonClick(object sender, EventArgs args) //when you click on a button that represents a unit it displays the information for said unit
        {
            foreach (Unit u in myMap.units)
            {
                if (((Button)sender).Text == u.Symbol)
                {
                    form.displayInfo(u.ToString()); //      ((Button)sender).Left + " " + ((Button)sender).Right);
                    break;
                }
            }
        }
    }
}
