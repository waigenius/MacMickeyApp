using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacMickeyApp
{
    class Beverage : Product

    {
        #region Propriétés
        private double millimeter;
        public double Millimeter
        {
            get { return millimeter; }
            set { millimeter = value; }
        }

        private bool isCarbonated;

        public bool IsCarbonated
        {
            get { return isCarbonated; }
            set { isCarbonated = value; }
        }

        #endregion

    }
}
