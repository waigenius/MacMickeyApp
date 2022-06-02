using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacMickeyApp
{
    class Menu:Product
    {
        #region Champs

        public int burger;
        public int beverage;
        public int side;
        public int dessert;

        #endregion

        #region Constructeur

  

        public Menu( int burgerId, int sideId, int beverageId, int dessertId)
        {
            this.side = sideId;
            this.burger = burgerId;
            this.beverage = beverageId;
            this.dessert = dessertId;
        }

        #endregion
    }
}
