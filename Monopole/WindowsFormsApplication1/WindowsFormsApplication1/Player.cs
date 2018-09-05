using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Player
    {
        public bool[] owned = new bool[28];
        private int index;
        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }
        public int money;
    }
}
