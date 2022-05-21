using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacMickeyApp
{
    class Dessert : Product
    {

        #region Propriétés
        private double millimeter;

        public double Millimeter
        {
            get { return millimeter; }
            set { millimeter = value; }
        }

        private bool isFrozen;

        public bool IsFrozen
        {
            get { return isFrozen; }
            set { isFrozen = value; }
        }

        #endregion
    }
}
