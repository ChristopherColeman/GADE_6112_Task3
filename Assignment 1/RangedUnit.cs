using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class RangedUnit : Unit // Tells the system to inherit the abstract classes found in the Unit class
    {

        public RangedUnit(int x, int y, int health, int speed, int attack, int range, int team, string symbol, string nameField)
        {
            this.x = x; // for this ranged class
            this.y = y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.range = range;
            this.team = team;
            this.symbol = symbol;
            this.nameField = nameField; //this will store the names of the units
        }

        //public static class Map //trying to make the form label variables accessible in this class, made them public in the properties but still don't work
        //{
        //    public static int mapSizeX;
        //    public static int mapSizeY;
        //};

        // we use the override keyword to override the abstract class method in the Unit class
        public override void Move(ref Unit closestUnit)
        {
            // if this range unit is the only ranged unit remaining
            if (this == closestUnit)
            {
                return; // then use return to terminate the method
            }

            // only react to enemy units, not it's own team
            if (closestUnit.Team != team)
            {
                // combat
                if (health < 25) // unit will not attack, instead it will run away. This works initially but after all units are
                                 // below 25hp another segment of code will be needed to prevent the units from constantly running
                                 // from one another
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
                    // less than 0 or greater than 20. This keeps all units on the board.
                    if (x <= 0)
                    {
                        x = 0;
                    }
                    else if (x >= mapSizeX) //for Task 3 the value 20 has been changed to mapSizeX
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
                    // Math.Abs returns the absolute value of a number; Mathf.clamp when looking back to use in the Unity version
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

        public override void Combat(ref Unit attacker)
        {
            this.health = this.health - attacker.Attack; // melee unit health = (health - attacker attack value)
            if (health <= 0)
            {
                Death();
            }
        }

        public override bool InRange(ref Unit attacker)
        {
            if (DistanceTo(attacker) == range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Unit unit)
        {
            int dx = Math.Abs(unit.X - x); // compare the positions between units
            int dy = Math.Abs(unit.Y - y);
            double part = Convert.ToDouble((dx * dx) + (dy * dy)); // this converts the values to a double, while multiplying the x and y positinos by themselves
            return Convert.ToInt32(Math.Sqrt(part)); // get the square root of the part above
        }

        public override Unit Closest(ref Unit[] map)
        {
            Unit closest = this;
            int smallestRange = 100;
            foreach (Unit u in map)
            {
                if (u.Team != team) //if the units are not part of that units team
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

        public override void Death()
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
    }
}
