using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class WizardUnit : Unit
    {
        public WizardUnit(int x, int y, int health, int speed, int attack, int range, int team, string symbol, string nameField)
        {
            this.x = x; // for this Wizard class
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.range = range;
            this.team = team;
            this.symbol = symbol;
            this.nameField = nameField;
        }

        public override void Move(ref Unit closestUnit)
        {
            // if this wizard unit is the only wizard unit remaining
            if (this == closestUnit)
            {
                return; // return will stop the method
            }

            // only react to enemy units, not it's own team
            if (closestUnit != WizardUnit) //can't put this here as it will cancel other attacks, needs to be a later check
            {
                if (closestUnit != FactoryBuilding || ResourceBuilding) //if the closest units are either ranged or melee units the wizard will attack

                    // combat

                    if (health < 50) // unit will not attack, instead it will run away.
                    {
                        Random r = new Random(); // inheritance from class Random will produce a random sequence of numbers
                                                 // Random.Next - This method generates random values inbetween ints 0 and 2
                        switch (r.Next(0, 2))
                        {
                            case 0: x += (1 * speed); break; // means the x(pos) + 1 x speed, so move and use speed x + 1 x speed
                            case 1: x -= (1 * speed); break; // x - 1
                        }

                        switch (r.Next(0, 2)) // same inheritance for y
                        {
                            case 0: y += (1 * speed); break; // speed is the move distance
                            case 1: y -= (1 * speed); break;
                        }

                        // check the bounds and reset the character, also sets the bounds so that units may not have x or y values
                        // less than 0 or greater than mapSizeX or mapSizeY.
                        if (x <= 0)
                        {
                            x = 0;
                        }
                        else if (x >= mapSizeX)
                        {
                            x = mapSizeX;
                        }

                        if (y <= 0)
                        {
                            y = 0;
                        }
                        else if (y >= mapSizeY)
                        {
                            y = mapSizeY;
                        }
                        // check if in combat
                        // Math.Abs returns the absolute value of a number;
                        else if (Math.Abs(x - closestUnit.X) <= speed && Math.Abs(y - closestUnit.Y) <= speed) // this gives the distance between 2 positions
                        {
                            Combat(ref closestUnit);
                        }
                        else // move towards the closest unit
                        {
                            if (x > closestUnit.X) //if ahead, then go backwards
                            {
                                x -= speed;
                            }
                            else if (x < closestUnit.X)
                            {
                                x += speed;
                            }

                            if (y > closestUnit.Y)
                            {
                                y -= speed;
                            }
                            else if (y < closestUnit.Y)
                            {
                                y += speed;
                            }
                        }
                    }
            }
        }

        public override void Combat(ref Unit attacker)
        {
            this.health = this.health - attacker.Attack; // wizard unit health = (health - attacker attack value)
            if (health <= 0)
            {
                Death();
            }
        }

        public override bool InRange(ref Unit Attacker)
        {
            if (DistanceTo(ref Attacker) == range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //(x, y), (x-1, y-1), (x-1, y), (x-2, y), (x, y-1), (x, y+1), (x+1, y-2), (x+1, y-1), (x+1, y+1) - Theoretical positions around Wizard it can attack

        private int DistanceTo(ref Unit unit)
        {
            int dx = Math.Abs(unit.X - x); // compare the positions between units
            int dy = Math.Abs(unit.Y - y);
            double part = Convert.ToDouble((dx * dx) + (dy * dy)); // this converts the values to a double, while multiplying the x and y positions by themselves
            return Convert.ToInt32(Math.Sqrt(part)); // get the square root of the part above
        }

        public override void Death() //runs on unit death, hp <= 0
        {
            throw new DeathException(this.ToString() + "IS DEAD"); //throw a message as a string using ToString()
        }

        public override string ToString()
        {
            return symbol + ": [" + x + "," + Y + "]" + health + "hp " + attack;
        }

        public class DeathException : System.Exception
        {
            public DeathException() : base() { } // provides a new instance of the exception class
            public DeathException(string message) : base(message) { } // using a string message for the base
            public DeathException(string message, System.Exception inner) : base(message, inner) { }
            // inner property calls the original exception that caused the problem
            //A constructor is needed for serialization when an exception propagates from a remoting server to the client.
            // Serialization is the process of storing objects as bytes in memory

            protected DeathException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) //StreamingContext  = source and destination
            { }
        }

        public override void save()
        {
            FileStream savefile = new FileStream("saves/buildin.game", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);

            writer.WriteLine(Symbol + ", " + Team + ", " + X + ", " + Y + ", " + health + ", " + nameField + ", " + speed);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }

        public override int Attack //This allows the programme to adjust the private variables from the Unit class
        {
            get { return attack; }
            set { attack = value; }
        }

        public override int X //Without these the programme would not be able to access these variables
        {
            get { return x; }
            set { x = value; }
        }

        public override int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public override int Team
        {
            get { return team; }
            set { team = value; }
        }

        public override string NameField
        {
            get { return nameField; }
            set { nameField = value; }

        }

        public override int Health
        {
            get { return health; }
            set { health = value; }
        }

        public override int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public override int Range
        {
            get { return range; }
            set { range = value; }
        }

        public override Unit Closest(ref Unit[] map)
        {
            Unit closest = this;
            int smallestRange = 100;
            foreach (Unit u in map)
            {
                if (u.Team != WizardUnit || FactoryBuilding && ResourceBuilding) //if the units are not part of the wizards
                {
                    if (smallestRange > DistanceTo(u) && u != this) // if less than smallest range and not the melee unit
                    {
                        smallestRange = DistanceTo(u); //then it is the smallest range
                        closest = u; //and the closest unit is u
                    }
                }
            }
            return closest;
        }
    }
}
