using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public abstract class Unit
    {
        protected int x, y, health, speed, attack, range, team;
        protected string symbol, nameField;

        public abstract void Move(ref Unit closestUnit); //The abstract classes will provide a common definition
                                                         //This allows multiple derived classes to share these definitions
        public abstract void Combat(ref Unit attacker);  //These will be instantiated in the Range and Melee units

        public abstract void Death();

        public abstract Unit Closest(ref Unit[] map);

        public abstract int DistanceTo(ref Unit attacker);

        public abstract string ToString();

        public abstract bool InRange(ref Unit closestUnit);

        public abstract void save();

        public abstract int X //The getter and setter will allow the program to change private variables.
        {
            get;
            set;
        }

        public abstract int Y //If the getter and setter were not provided the programme would not be able to access these variables.
        {
            get;
            set;
        }

        public abstract int Health //These allow specific variables to be changed and add a great deal of flexibility
        {
            get;
            set;
        }

        public abstract int Speed
        {
            get;
            set;
        }

        public abstract int Attack
        {
            get;
            set;
        }

        public abstract int Range
        {
            get;
            set;
        }

        public abstract int Team
        {
            get;
            set;
        }

        public abstract string Symbol
        {
            get;
            set;
        }
    }
}
