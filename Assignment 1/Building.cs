using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public abstract class Building
    {
        protected int x, y, hp;
        protected char team, symbol;

        public abstract int X
        {
            get;
            set;
        }

        public abstract int Y
        {
            get;
            set;
        }

        public abstract int HP
        {
            get;
            set;
        }

        public abstract char Team
        {
            get;
            set;
        }

        public abstract char Symbol
        {
            get;
            set;
        }

        public abstract override string ToString();

        public abstract void save();

        public abstract void death();

    }
}
