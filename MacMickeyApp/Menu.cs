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

        
        public Menu()
        {

        }

        public Menu( Burger burger, Side side, Beverage beverage, Dessert dessert)
        {
            this.side = side.Id;
            this.burger = burger.Id;
            this.beverage = beverage.Id;
            this.dessert = dessert.Id;
        }

        #endregion
    }
}
