using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacMickeyApp
{
    class Side : Product
    {
        #region Propriétés
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private int saltWeight;

        public int SaltWeight
        {
            get { return saltWeight; }
            set { saltWeight = value; }
        }
        #endregion


    }

}
