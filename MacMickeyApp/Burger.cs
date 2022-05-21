using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacMickeyApp 
{
    class Burger : Product
    {
        #region Propriétés
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private int beefWeight;

        public int BeefWeight
        {
            get { return beefWeight; }
            set { beefWeight = value; }
        }

        #endregion

    }
}
