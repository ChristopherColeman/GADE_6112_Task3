using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1
{
    class ResourceBuilding : Building
    {
        private string resourceType;
        private int totalResources;
        private int roundResources;
        private int remainingResources;
        private int spawnX;
        private int spawnY;
        private int hp;
        private char team;

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

        public override void death()
        {
            Console.WriteLine("Resource Building" + this.Symbol + "at" this.SpawnX + "," + this.SpawnY = "is dead!");
        }

        public override string ToString()
        {
            return "This is a resource building belonging to Team " + this.Team + ". It looks like this: " + this.Symbol + "\n positioned at " + this.X + "," + this.Y + ". \n HP: " + this.hp
                + "\n Create: " + this.unitType + " units every" + this.Speed + " second(s) at " + this.spawnX + "," + this.spawnY;
        }

        public Unit GenerateResource()
        {
            if (Map() == true) //run everytime the map() is called?
            {
                roundResources = 20;
            }
            

            totalResources = roundResources * label1.text;



            //if (resourceType == "BattleResources") //provides armor or weapons
            //{
            //    if (r.Next(0, 2) == 0)
            //    {
            //        name = "Armor";
            //    }
            //    else
            //    {
            //        name = "Weapons";
            //    }

            //    if (resourceType == "LivingResources") //provides water or food
            //    {
            //        if (r.Next(0, 2) == 0)
            //        {
            //            name = "Water";
            //        }
            //        else
            //        {
            //            name = "Food";
            //        }
            //    }
            //    return int totalResources = int.Parse(totalResources); //trying to convert the string values into ints so it can display as totalResources
            //    Console.WriteLine(totalResources);
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
