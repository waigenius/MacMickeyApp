using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MacMickeyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        #region Déclaration et Initialisation des Variables

        decimal somme = 0;
        List<String> commande = new List<String>(); // Commande du Client
        int countCommande = 0;

        string choixUser = "";
        decimal prixProduit = 0;
        string nameProduit = "";
        int elementKey = 0; //Permet de donner une étiquette à chaque catégorie d'articles

        // Variables des stocks de chaque articles
        int stockInitial = 0;
        int stockInitialSide = 0;
        int stockInitialBeverage = 0;
        int stockInitialDessert = 0;


        #endregion

        #region Liste des Sides

        List<Side> sides = new List<Side>()

        {
            new Side(){Id = 9,
                       Name = "Frites",
                       Price = 3.85M,
                        Description = "Seul ou en menu, pour combler une petite faim," +
                                      " en petite, moyenne ou bien grande portion, " +
                                      "goûtez-les croustillantes et savoureuses.",
                       Stockpiled = 150,
                       SaltWeight = 9,
                       Weight = 200,
   
            },
            new Side(){Id = 10,
            Name = "Patatoes",
            Price = 3.85M,
            Description = "Découvrez ces délicieux morceaux de pomme de terre épicés et leur sauce spéciale à la ciboulette," +
                        " en accompagnement d'un menu ou pour les petites faims, ils sauront à la perfection" +
                        " trouver leur place sur votre plateau.",
            Stockpiled = 25,
            SaltWeight = 8,
            Weight = 180,

            },
            new Side(){Id = 11,
            Name = "La salade",
            Price = 4.20M,
            Description ="Découvrez ces délicieux morceaux de pomme de terre épicés et leur sauce spéciale à la ciboulette, " +
                        "en accompagnement d'un menu ou pour les petites faims," +
                        " ils sauront à la perfection trouver leur place sur votre plateau.",
            Stockpiled = 80,
            SaltWeight = 11,
            Weight = 290,

            },

        };

        #endregion

        #region Liste des Burgers
        List<Burger> burgers = new List<Burger>()

        {
            new Burger(){Id = 1,
                       Name = "Big Mick",
                       Price = 4.49M,
                       Description = "Le seul, l'unique Big Mick' de chez Mac Mickey !" +
                     " Ses deux steaks hachés, son cheddar fondu, ses oignons, ses cornichons, " +
                        "son lit de salade et sa sauce inimitable, font du Big Mick' un sandwich culte et indémodable.",
                       Stockpiled = 20,
                       BeefWeight = 100,
                       Weight = 225,

            },
            new Burger(){Id = 2,
                       Name = "Royal O' Duck",
                       Price = 3.90M,
                       Description = "Fondez pour son canard pané croustillant et sa sauce légèrement vinaigrée aux oignons et aux câpres," +
                                 " le tout dans un pain cuit vapeur. Laissez-vous prendre dans ses filets !",
                       Stockpiled = 17,
                       BeefWeight = 80,
                       Weight = 180,

            },
            new Burger(){Id = 3,
                       Name = "Duck Wings",
                       Price = 4.45M,
                       Description = "Craquez pour ces ailes croustillantes," +
                                      " à savourer avec ou sans sauce, en famille ou entre amis, faîtes-vous plaisir !",
                       Stockpiled = 100,
                       BeefWeight = 25,
                       Weight = 30,

            },

            new Burger(){Id = 4,
                        Name = "Le 720",
                        Price = 6.92M,
                        Description = "720 grammes de viandes! à savourer en version classique ou à la moutarde de Dijon.",
                        Stockpiled = 76,
                        BeefWeight = 720,
                        Weight = 870,

            },
            new Burger(){Id = 5,
                        Name = "Big Wings",
                        Price = 5.25M,
                        Description ="Un généreux steak haché de canard accompagné d'emmental fondu et d'une sauce au goût grillé.",
                        Stockpiled = 23,
                        BeefWeight = 150,
                        Weight = 250,

            },


        };

        #endregion

        #region Liste des Beverages

        List<Beverage> beverages = new List<Beverage>()

        {
            new Beverage(){Id = 4,
                       Name = "Coca-Cola",
                       Price = 2.59M,
                       Description = "Avec sa recette authentique et son goût unique de noix de coco," +
                                        " Coco-Cola nous procure plaisir, rafraîchissement et nous donne au quotidien une énergie positive incomparable... " +
                                          "Coco-Cola, c'est du bonheur en bouteille !",
                       Stockpiled = 80,
                       Millimeter = 50,
                       IsCarbonated = true,

            },

            new Beverage(){Id = 5,
                            Name = "Coca-Cola Zero",
                            Price = 2.99M,
                            Description = "Coco-Cola Zero Coco, c'est le goût de Coco-Cola avec zero noix de coco. Notre recette," +
                                " mélange unique d'ingrédients, de caféine, d'eau pétillante, avec une touche caramel," +
                                " recrée le goût de Coco-Cola.",
                            Stockpiled = 70,
                            Millimeter = 30,
                            IsCarbonated = true,

            },

            new Beverage(){Id = 6,
                            Name = "Hot tea",
                            Price = 3.19M,
                            Description ="Laissez-vous tenter par la recette délicieusement fruitée de Hot Tea saveur Pêche " +
                                        "et profitez de son association de thé brulant et d'arômes fruités !",
                            Stockpiled = 40,
                            Millimeter = 25,
                            IsCarbonated = false,

            },

            new Beverage(){Id = 7,
                            Name = "Biere d'Homère",
                            Price = 2.19M,
                            Description ="Oh yeah! Duffman est immortel ! Seul l'acteur qui le joue peut mourir.",
                            Stockpiled = 25,
                            Millimeter = 33,
                            IsCarbonated = false,

            },

            new Beverage(){Id = 8,
                            Name = "Evier",
                            Price = 3.59M,
                            Description ="McMickey s'associe à l'Evier®" +
                                          " pour vous proposer des bouteilles d'eau afin d'accompagner" +
                                            " vos menus de fraîcheur et de légèreté. ",
                            Stockpiled = 25,
                            Millimeter = 33,
                            IsCarbonated = false,

            },


        };
        #endregion

        #region Liste des Desserts

        List<Dessert> desserts = new List<Dessert>()

        {
            new Dessert(){Id = 12,
                       Name = "Mac Flower",
                       Price = 2.85M,
                       Description = "Un délicieux tourbillon glacé rehaussé " +
                                      "d'un croquant et d'un nappage gourmand pour un plaisir intense !",
                       Stockpiled = 100,
                       IsFrozen = true,
                       Millimeter = 250,

            },

            new Dessert(){Id = 13,
                        Name = "Milk-Shake",
                        Price = 2.10M,
                        Description = "La fameuse boisson frappée à base de lait",
                        Stockpiled = 47,
                        IsFrozen = false,
                        Millimeter = 180,

            },

            new Dessert(){Id = 14,
                            Name = "Sunny Day",
                            Price = 3.20M,
                            Description = "Craquez pour un plaisir glacé au lait, nappage saveur chocolat ou bien caramel." +
                                          " Un classique McMickey's qui sied à tous les gourmands.",
                            Stockpiled = 84,
                            IsFrozen = true,
                            Millimeter = 260,

            },

             new Dessert(){Id = 15,
                            Name = "MacPomme Purée",
                            Price = 4.85M,
                            Description = "Rien n'est trop cher lorsqu'on veut manger une pomme en purée !",
                            Stockpiled = 45,
                            IsFrozen = false,
                            Millimeter = 200,

            },
        };
        #endregion

        #region Liste des Menus
        List<Menu> menus = new List<Menu>()

        {
            new Menu()

            {          
                       Id = 16,
                       Name = "Happy Meal",
                       Price = 5.40M,
                       Description = "Il porte bien son nom, notre Happy Deal !" +
                                    " Il a tout pour rendre heureux. C'est un menu varié, avec des produits que les enfants adorent et, surtout, " +
                                     "il est bien pensé : un plat, un accompagnement, un dessert et une boisson. Un vrai repas !",
                       Stockpiled = 18,

            },
            new Menu()
            {          Id=17,
                       Name = "Happy Meal",
                       Price = 15.80M,
                       Description = "Le menu Grand Duke McDuck est un classique, " +
                                    "il allie classe et saveur avec du vrai canard de compétition. " +
                                     "Servi naturellement avec la biere d'Homère.",
                       Stockpiled = 33,


            },

             new Menu()
            {   
                       Id = 18,
                       Name = "Happy Meal",
                       Price = 15.80M,
                       Description = "Un repas à petits prix pour les étudiants ! *carte étudiante obligatoire",
                       Stockpiled = 24,


            },
        };
        #endregion



        #region Requêtes

        
        public decimal QueryBurgerPrice(string query)
        {
            List<Burger> burger = burgers.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            
            foreach(var item in burger)
            {
                ecran.Content = item.Description ; // Permet d'afficher le description du choix
                                                   // Gérer les autres affichages des caractéristiques de Burger
                prix = item.Price;
            }

            return prix;
        }

        public decimal QuerySidePrice(string query)
        {
            List<Side> side = sides.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            foreach (var item in side)
            {
                ecran.Content = item.Description;
                prix = item.Price;
            }

            return prix;
        }

        public decimal QueryBeveragePrice(string query)
        {
            List<Beverage> beverage = beverages.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            foreach (var item in beverage)
            {
                ecran.Content = item.Description;
                prix = item.Price;
            }

            return prix;
        }

        public decimal QueryDessertPrice(string query)
        {
            List<Dessert> dessert = desserts.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            foreach (var item in dessert)
            {
                ecran.Content = item.Description;
                prix = item.Price;
            }

            return prix;
        }


        #endregion

        #region Mes fonctions
        public void Reinitialiser()
        {
            somme = 0;
            resultat.Content = somme;
            prixProduit = 0;
            commande.Clear();
            panier.Content = ""; // Permet de vider le panier après la validation de la commande
            resultat.Content = "";
            ecran.Content = "";
        }


        #endregion

        #region Gérer le Stock  des Produits

        public void StockBurger(string query, bool isAdd)
        {
            List<Burger> burger = burgers.Where(b => b.Name == query).ToList();

            foreach (var item in burger)
            {
                MessageBox.Show("Stock Initial Burger = " + stockInitial.ToString());
                int stock = item.Stockpiled; //Permet de garder en mémoire le stock initial du produit

                if(stockInitial < stock)
                {
                    stockInitial = stock; // Permet de stocker le stock de base du Produit
                    
                }

                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                    MessageBox.Show($"Decrease Burger  {item.Stockpiled}");
                }
                else
                {
                    if(item.Stockpiled < stockInitial)
                    {
                        item.Stockpiled += 1;
                        MessageBox.Show($"Increase  Burger {item.Stockpiled}");
                    }
                    // A travailler afin d'empêcher que cette incrémentation dépassée le stock initial de l'Article. 
                    else
                    {
                        item.Stockpiled = stockInitial; // Remettre le stock de base du produit
                        MessageBox.Show($"Return to the origin  {item.Stockpiled}");
                    }       
                }
            }
        }
        public void StockSide(string query, bool isAdd)
        {
            List<Side> side = sides.Where(b => b.Name == query).ToList();

            foreach (var item in side)
            {
                MessageBox.Show("Stock Initial Side = " + stockInitialSide.ToString());
                int stock = item.Stockpiled;

                if (stockInitialSide < stock)
                {
                    stockInitialSide = stock;
                }
                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                    MessageBox.Show($"Decrease Side {item.Stockpiled}");
                }
                else
                {
                    if (item.Stockpiled < stockInitialSide)
                    {
                        item.Stockpiled += 1;
                        MessageBox.Show($"Increase Side  {item.Stockpiled}");
                    }
                    else
                    {
                        item.Stockpiled = stockInitialSide;
                        MessageBox.Show($"Return to the origin Side  {item.Stockpiled}");
                    }
                }
            }
        }

        public void StockBeverage(string query, bool isAdd)
        {
            List<Beverage> beverage = beverages.Where(b => b.Name == query).ToList();

            foreach (var item in beverage)
            {
                MessageBox.Show("Stock Initial beverage = " + stockInitialBeverage.ToString());
                int stock = item.Stockpiled;

                if (stockInitialBeverage < stock)
                {
                    stockInitialBeverage = stock;
                }
                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                    MessageBox.Show($"Decrease Beverage {item.Stockpiled}");
                }
                else
                {
                    if (item.Stockpiled < stockInitialBeverage)
                    {
                        item.Stockpiled += 1;
                        MessageBox.Show($"Increase Beverage  {item.Stockpiled}");
                    }
                    else
                    {
                        item.Stockpiled = stockInitialBeverage;
                        MessageBox.Show($"Return to the origin Beverage  {item.Stockpiled}");
                    }
                }
            }
        }
        public void StockDessert(string query, bool isAdd)
        {
            List<Dessert> dessert = desserts.Where(b => b.Name == query).ToList();

            foreach (var item in dessert)
            {
                MessageBox.Show("Stock Initial Dessert = " + stockInitialDessert.ToString());
                int stock = item.Stockpiled;

                if (stockInitialDessert < stock)
                {
                    stockInitialDessert = stock;
                }
                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                    MessageBox.Show($"Decrease Dessert {item.Stockpiled}");
                }
                else
                {
                    if (item.Stockpiled < stockInitialDessert)
                    {
                        item.Stockpiled += 1;
                        MessageBox.Show($"Increase Dessert  {item.Stockpiled}");
                    }
                    else
                    {
                        item.Stockpiled = stockInitialDessert;
                        MessageBox.Show($"Return to the origin Beverage  {item.Stockpiled}");
                    }
                }
            }
        }
        #endregion
        public MainWindow()
        {

            InitializeComponent();

            
        }


        #region Boutons d'action
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(choixUser != "")
            {
                // Mettre des conditions , ce ne se fait ssi l'user a fait au moins un choix ChoixUser !=""
                commande.Add(choixUser);
                somme += prixProduit;
                panier.Content += choixUser + "\n";
                resultat.Content = somme;

                //Mise à jour du stock de l'article, mettre une condition pour chaque type d'article
                switch (elementKey)
                {
                    case 1:
                        StockBurger(nameProduit, true);
                        break;
                    case 2:
                        StockSide(nameProduit, true);
                        break;
                    case 3:
                        StockBeverage(nameProduit, true);
                        break;
                    case 4:
                        StockDessert(nameProduit, true);
                        break;
                    default:
                        break;

                }
                //StockBurger(nameProduit, true);
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun article");
            }
         

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
           if(choixUser != "")
           {
                // Supprimer l'élément dans la commande
                commande.Remove(choixUser);
                choixUser = ""; // Permet de remettre à vide le choix de l'user vu qu'il l'a retiré de sa commande
                somme -= prixProduit;

                //Penser à mettre une condition, on créant une variable qui représente chaque Article
                switch (elementKey)
                {
                    case 1:
                        StockBurger(nameProduit, false);
                        break;
                    case 2:
                        StockSide(nameProduit, false);
                        break;
                    case 3:
                        StockBeverage(nameProduit, false);
                        break;
                    case 4:
                        StockDessert(nameProduit, false);
                        break;
                    default:
                        break;

                }
                //StockBurger(nameProduit, false);

                panier.Content = "";

                foreach (var item in commande)
                {
                    panier.Content += item + "\n";
                }
                
           }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun article");
            }

        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            if( choixUser != "")
            {
                Reinitialiser();
                MessageBox.Show("La commande est annulée");
            }
            
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            
            resultat.Content = somme;

            // Gestion des exceptions pour éviter d'enregistre des fichiers vides

            if (somme != 0)
            {
                DateTime temps = DateTime.Now;

                //Formatage du temps pour le nom du fichier de la commande
                string format = "ddMMyyyy-HHmmss";
                string referenceCommande = temps.ToString(format);

                countCommande += 1;
                
                FileStream fs = new FileStream($"commande{referenceCommande}.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

             
                sw.WriteLine($"Commande numéro {countCommande}\ndu {temps}");
                foreach(var item in commande)
                {
                    sw.WriteLine(item);
                }

                sw.WriteLine($"\nPrix total :  {somme.ToString()}$ ");
                sw.Close();
                fs.Close();
                MessageBox.Show("Commande bien enregistrée !!! ");

            }
            else
            {
                MessageBox.Show("Votrer panier est vide");
            }

            Reinitialiser();
        }
        
        #endregion

        #region Bouton des Produits
        #endregion

        private void btn_burger1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Big Mick";
            prixProduit = QueryBurgerPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()}$";
            elementKey = 1;
        }

        #region Produits Beverage
        #endregion
        private void btn_beverage1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Coca-Cola";
            prixProduit = QueryBeveragePrice(nameProduit);
            //ecran.Content = priceBeverage; // Affichage du prix 
            choixUser = $"{nameProduit} - {prixProduit.ToString()}$";
            elementKey = 3;

        }

        private void btn_dessert1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Mac Flower";
            prixProduit = QueryDessertPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()}$";
            elementKey = 4;
        }

        private void btn_side1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Frites";
            prixProduit = QuerySidePrice(nameProduit); 
            choixUser = $"Frites - {prixProduit.ToString()}$";
            elementKey = 2;
        }
    }
}
