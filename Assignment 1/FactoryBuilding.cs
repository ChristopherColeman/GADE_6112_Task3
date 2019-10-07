using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class FactoryBuilding : Building
    {
        private string unitType;
        private int hp;
        private int speed;
        private int spawnX;
        private int spawnY;
        private char team;

        public string UnitType
        {
            get { return UnitType; }
            set { UnitType = value; }
        }

        public int HP
        {
            get { return HP; }
            set { HP = value; }
        }

        public int Speed
        {
            get { return Speed; }
            set { Speed = value; }
        }

        public int SpawnX
        {
            get { return SpawnX; }
            set { SpawnX = value; }
        }

        public int SpawnY
        {
            get { return SpawnY; }
            set { SpawnY = value; }
        }

        public FactoryBuilding(int x, int y, char team, char symbol, string units)
        {
            unitType = units;
            Speed = speed;
            SpawnX = x;

            if (y != 0)
            {
                spawnY = spawnY - 1;
            }
            else
            {
                spawnY = spawnY + 1;
            }
        }

        public Unit GenerateUnit()
        {
            unitType unit = null;

            Random r = new Random();
            string name = "";

            if (unitType == "Melee") //spawns melee unit
            {
                if (r.Next(0, 2) == 0)
                {
                    name = "Knight";
                }
                else
                {
                    name = "Recruit";
                }

                if (UnitType == "Ranged") //spawns ranged unit
                {
                    if (r.Next(0, 2) == 0)
                    {
                        name = "Fire Wizard";
                    }
                    else
                    {
                        name = "Archer";
                    }
                }

                if (unitType == "Melee") && (Team == 'Shield');
                {
                    unit = new MeleeUnit(SpawnX, SpawnY, Team, 'K', name);
                }
                else if (unitType == "Melee" && (Team == 'Hammer'))
                {
                    unit = new MeleeUnit(SpawnX, SpawnY, Team, 'Bow', name);
                }

                if (unitType == "Ranged") && (Team == 'Shield');
                {
                    unit = new RangedUnit(SpawnX, SpawnY, Team, 'K', name);
                }
                else if (unitType == "Ranged" && (Team == 'Hammer'))
                {
                    unit = new RangedUnit(SpawnX, SpawnY, Team, 'Bow', name);
                }
                return unit;
            }
        }
            public override void death()
                {
                Console.WriteLine("Factory Building" + this.Symbol + "at" this.SpawnX + "," + this.SpawnY = "is dead!");
                }

            public override string ToString()
        {
            return "This is a factory belonging to Team " + this.Team + ". It looks like this: " + this.Symbol + "\n positioned at " + this.X + "," + this.Y + ". \n HP: " + this.hp
                + "\n Create: " + this.unitType + " units every" + this.Speed + " second(s) at " + this.spawnX + "," + this.spawnY;
        }

        public override void save()
        {
            FileStream savefile = new FileStream("saves/buildin.game", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);

            writer.WriteLine(Symbol + ", " + Team + ", " + X + ", " + Y + ", " + hp + ", " + unitType + ", " + speed);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }
    }
}
