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
        decimal prixProduit = 0;
        int countCommande = 0;


        // Permet de stocker les articles selectionnés par le client
        List<String> commande = new List<String>();
        

        string choixUser = "";
        string nameProduit = "";

        //Permet de donner une étiquette à chaque catégorie d'article
        int elementKey = 0; 

        // Variables des stocks de chaque article
        int stockInitial = 0;
        int stockInitialSide = 0;
        int stockInitialBeverage = 0;
        int stockInitialDessert = 0;
        int stockInitialMenu = 0;
        bool isDisponible = true;

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
            Description = "Découvrez ces délicieux morceaux de pomme de terre épicés et " +
                         " leur sauce spéciale à la ciboulette," +
                        " en accompagnement d'un menu ou pour les petites faims, ils sauront à la perfection" +
                        " trouver leur place sur votre plateau.",
            Stockpiled = 25,
            SaltWeight = 8,
            Weight = 180,

            },
            new Side(){Id = 11,
            Name = "La salade Canard",
            Price = 4.20M,
            Description ="La salade Canard et ses tomates cerises, ses lamelles de fromage," +
                         " et ses croûtons aromatisés ail et fines herbes," +
                         " servie avec du canard chaud croustillant",
            Stockpiled = 80,
            SaltWeight = 11,
            Weight = 290,

            },

        };

        #endregion

        #region Liste des Burgers
        List<Burger> burgers = new List<Burger>()

        {   
            //burger1,
            new Burger(){Id = 1,
                       Name = "Big Mick",
                       Price = 4.49M,
                       Description = "Le seul, l'unique Big Mick' de chez Mac Mickey !" +
                                      "Ses deux steaks hachés, son cheddar fondu," +
                                      "ses oignons, ses cornichons," +
                                      "son lit de salade et sa sauce inimitable," +
                                      "font du Big Mick' un sandwich culte et indémodable.",
                       Stockpiled = 20,
                       BeefWeight = 100,
                       Weight = 225,

            },
            new Burger(){Id = 2,
                       Name = "Royal O'Duck",
                       Price = 3.90M,
                       Description = "Fondez pour son canard pané croustillant " +
                                    " et sa sauce légèrement vinaigrée aux oignons et aux câpres," +
                                    " le tout dans un pain cuit vapeur." +
                                    "Laissez-vous prendre dans ses filets !",
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
                            Name = "Evian",
                            Price = 3.59M,
                            Description ="McMickey s'associe à l'Evian®" +
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
            new Menu(1,10,8,12)

            {
                       Id = 16,
                       Name = "Happy Meal",
                       Price = 5.40M,
                       Description = "Il porte bien son nom, notre Happy Deal !" +
                                    " Il a tout pour rendre heureux. C'est un menu varié, avec des produits que les enfants adorent et, surtout, " +
                                     "il est bien pensé : un plat, un accompagnement, un dessert et une boisson. Un vrai repas !",
                       Stockpiled = 18,

            },
            new Menu(2,11,7,14)
            {          Id=17,
                       Name = "Grand Duke McDuck",
                       Price = 15.80M,
                       Description = "Le menu Grand Duke McDuck est un classique, " +
                                    "il allie classe et saveur avec du vrai canard de compétition. " +
                                     "Servi naturellement avec la biere d'Homère.",
                       Stockpiled = 33,


            },

             new Menu(1,10,8,13)
            {   
                       Id = 18,
                       Name = "Student McDuck",
                       Price = 12M,
                       Description = "Un repas à petits prix pour les étudiants ! *carte étudiante obligatoire",
                       Stockpiled = 24,


            },
        };
        #endregion

        #region Requêtes

        public decimal QueryMenuPrice(string query, int burgerId, int sideId, int beverageId, int dessertId)
        {
            List<Menu> menu = menus.Where(b => b.Name == query).ToList();
            List<Burger> burger = burgers.Where(b => b.Id == burgerId).ToList();
            List<Side> side = sides.Where(b => b.Id == sideId).ToList();
            List<Beverage> beverage = beverages.Where(b => b.Id == beverageId).ToList();
            List<Dessert> dessert = desserts.Where(b => b.Id == dessertId).ToList();
            decimal prix = 0M;

            detail.Text = " Votre menu est composé de \n";
            foreach (var item in menu)
            {
                if (item.Stockpiled > 0)
                {
                    isDisponible = true;
                    prix = item.Price;
                    ecran.Text = item.Description;
                }
                else
                {
                    isDisponible = false;
                    MessageBox.Show("Produit épuisé");
                    ecran.Text = "Désolé :(, l'article est épuisé selectionnez un autre";
                }
                
                
            }
            if(isDisponible == true)
            {
                foreach (var item in burger)
                {
                    detail.Text += item.Name + " ---- ";
                }
                foreach (var item in side)
                {
                    detail.Text += item.Name + "\n";

                }
                foreach (var item in beverage)
                {
                    detail.Text += item.Name + " ---- ";

                }
                foreach (var item in dessert)
                {
                    detail.Text += item.Name + $"\nPrix : {item.Price}$\n\n Stock disponible : {item.Stockpiled}";

                }
            }
            
            return prix;
        }
        public decimal QueryBurgerPrice(string query)
        {
            List<Burger> burger = burgers.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            
            foreach(var item in burger)
            {
                //Vérification de la disponibilité
                if (item.Stockpiled > 0)
                {
                    isDisponible = true;
                    prix = item.Price;
                    ecran.Text = item.Description;
                    detail.Text = $" Prix : {item.Price}$\n Poids : {item.Weight}\nPoids du boeuf : {item.BeefWeight} \n\n Stock disponible : {item.Stockpiled}";
                }
                else
                {
                    isDisponible = false;
                    MessageBox.Show("Produit épuisé");
                    ecran.Text = "Désolé :(, l'article est épuisé selectionnez un autre";
                    
                }
               
            }

            return prix;
        }

        public decimal QuerySidePrice(string query)
        {
            List<Side> side = sides.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            foreach (var item in side)
            {
                if (item.Stockpiled > 0)
                {
                    isDisponible = true;
                    prix = item.Price;
                    ecran.Text = item.Description;
                    detail.Text = $" Prix : {item.Price}$\n Poids : {item.Weight}\nQuantité du sel : {item.SaltWeight}\n\n Stock disponible : {item.Stockpiled}";
                }
                else
                {
                    isDisponible = false;
                    MessageBox.Show("Produit épuisé");
                    ecran.Text = "Désolé :(, l'article est épuisé selectionnez un autre";
                }
                
            }

            return prix;
        }

        public decimal QueryBeveragePrice(string query)
        {
            List<Beverage> beverage = beverages.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            foreach (var item in beverage)
            {
                if (item.Stockpiled > 0)
                {
                    isDisponible = true;
                    prix = item.Price;
                    ecran.Text = item.Description;
                    detail.Text = $" Prix : {item.Price}$\n Quantité en litre : {item.Millimeter}\nBoisson gazeuse : {item.IsCarbonated} \n\n Stock disponible : {item.Stockpiled}";
                }
                else
                {
                    isDisponible = false;
                    MessageBox.Show("Produit épuisé");
                    ecran.Text = "Désolé :(, l'article est épuisé selectionnez un autre";
                }
               
            }

            return prix;
        }

        public decimal QueryDessertPrice(string query)
        {
            List<Dessert> dessert = desserts.Where(b => b.Name == query).ToList();
            decimal prix = 0M;
            foreach (var item in dessert)
            {
                if (item.Stockpiled > 0)
                {
                    isDisponible = true;
                    prix = item.Price;
                    ecran.Text = item.Description;
                    detail.Text = $" Prix : {item.Price}$\n Volume : {item.Millimeter}\nGlacé: {item.IsFrozen}\n\n Stock disponible : {item.Stockpiled}";
                }
                else
                {
                    isDisponible = false;
                    MessageBox.Show("Produit épuisé");
                    ecran.Text = "Désolé :(, l'article est épuisé selectionnez un autre";
                }
                
            }

            return prix;
        }


        #endregion

        #region Réinitialiser les toutes les données
        public void Reinitialiser()
        {
            somme = 0;
            prixProduit = 0;
            commande.Clear();
            panier.Text = ""; // Permet de vider le panier après la validation de la commande
            resultat.Content = "Total";
            ecran.Text = "Descritption";
            detail.Text = "Caractéristiques";
        }

        #endregion

 
        #region Gérer le Stock  des Produits
   
        public void StockBurger(string query, bool isAdd)
        {
            List<Burger> burger = burgers.Where(b => b.Name == query).ToList();

            foreach (var item in burger)
            {
                
                int stock = item.Stockpiled; //Permet de garder en mémoire le stock initial du produit

                if(stockInitial < stock)
                {
                    stockInitial = stock; // Permet de stocker le stock de base du Produit
                    
                }

                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
 
                }
                else
                {
                    if(item.Stockpiled < stockInitial)
                    {
                        item.Stockpiled += 1;
                        
                    }
                    // Empêcher que cette incrémentation dépassée le stock initial de l'Article. 
                    else
                    {
                        item.Stockpiled = stockInitial; // Remettre le stock de base du produit
                       
                    }       
                }
            }
        }
        public void StockSide(string query, bool isAdd)
        {
            List<Side> side = sides.Where(b => b.Name == query).ToList();

            foreach (var item in side)
            {
                int stock = item.Stockpiled;

                if (stockInitialSide < stock)
                {
                    stockInitialSide = stock;
                }
                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                }
                else
                {
                    if (item.Stockpiled < stockInitialSide)
                    {
                        item.Stockpiled += 1;
                    }
                    else
                    {
                        item.Stockpiled = stockInitialSide;
                    }
                }
            }
        }
        public void StockBeverage(string query, bool isAdd)
        {
            List<Beverage> beverage = beverages.Where(b => b.Name == query).ToList();

            foreach (var item in beverage)
            {
                int stock = item.Stockpiled;

                if (stockInitialBeverage < stock)
                {
                    stockInitialBeverage = stock;
                }
                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                }
                else
                {
                    if (item.Stockpiled < stockInitialBeverage)
                    {
                        item.Stockpiled += 1;
                    }
                    else
                    {
                        item.Stockpiled = stockInitialBeverage;
                    }
                }
            }
        }
        public void StockDessert(string query, bool isAdd)
        {
            List<Dessert> dessert = desserts.Where(b => b.Name == query).ToList();

            foreach (var item in dessert)
            {
                int stock = item.Stockpiled;

                if (stockInitialDessert < stock)
                {
                    stockInitialDessert = stock;
                }
                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                }
                else
                {
                    if (item.Stockpiled < stockInitialDessert)
                    {
                        item.Stockpiled += 1; 
                    }
                    else
                    {
                        item.Stockpiled = stockInitialDessert;
                    }
                }
            }
        }
        public void StockMenu(string query, bool isAdd)
        {
            List<Menu> menu = menus.Where(b => b.Name == query).ToList();

            foreach (var item in menu)
            {

                int stock = item.Stockpiled;

                if (stockInitialMenu < stock)
                {
                    stockInitialMenu = stock;
                }

                if (isAdd == true)
                {
                    item.Stockpiled -= 1;
                }
                else
                {
                    if (item.Stockpiled < stockInitialMenu)
                    {
                        item.Stockpiled += 1;
                    }

                    else
                    {
                        item.Stockpiled = stockInitialMenu;

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
            if(choixUser != "" && isDisponible == true)
            {
                // Mettre des conditions , ce ne se fait ssi l'user a fait au moins un choix ChoixUser !=""
                commande.Add(choixUser);
                somme += prixProduit;
                ecran.Text = "Description";
                detail.Text = "Caractéristiques";
                panier.Text += choixUser + "\n";
                resultat.Content = $"{somme} $";

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
                    case 5:
                        StockMenu(nameProduit, true);
                        break;
                    default:
                        break;

                }
                
            }
            else
            {
                MessageBox.Show("Vous n'avez selectionné aucun article");
            }
         

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
           if(choixUser != "" && isDisponible)
           {
                // Supprimer l'élément dans la commande
                commande.Remove(choixUser);
                choixUser = ""; // Permet de remettre à vide le choix de l'user vu qu'il l'a retiré de sa commande
                ecran.Text = "Descritption";
                detail.Text = "Detail";
                somme -= prixProduit;
                // Pour éviter que la somme soit négative
                if (somme < 0)
                {
                    somme = 0;
                }
        
                resultat.Content = $"{somme} $";

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
                    case 5:
                        StockMenu(nameProduit, false);
                        break;
                    default:
                        break;

                }
                panier.Text = "";

                foreach (var item in commande)
                {
                    panier.Text += item + "\n";
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

            // Gestion des exceptions pour éviter d'enregistre des fichiers vides

            if (somme != 0)
            {
                resultat.Content = $"{somme} $";
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

                Reinitialiser();
            }
            else
            {
                MessageBox.Show("Votre panier est vide");
                
            }
        }

        #endregion

        #region Boutons des Produits Burgers
        private void btn_burger1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Big Mick";
            prixProduit = QueryBurgerPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitial = 0;
            elementKey = 1;
        }
        private void btn_burger2_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Royal O'Duck";
            prixProduit = QueryBurgerPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitial = 0;
            elementKey = 1;
        }

        private void btn_burger3_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Duck Wings";
            prixProduit = QueryBurgerPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitial = 0;
            elementKey = 1;
        }

        private void btn_burger4_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Le 720";
            prixProduit = QueryBurgerPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitial = 0;
            elementKey = 1;
        }

        private void btn_burger5_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Big Wings";
            prixProduit = QueryBurgerPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitial = 0;
            elementKey = 1;
        }
        #endregion

        #region Boutons des Produits Beverages
        private void btn_beverage1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Coca-Cola";
            prixProduit = QueryBeveragePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialBeverage = 0;
            elementKey = 3;

        }
        private void btn_beverage2_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Coca-Cola Zero";
            prixProduit = QueryBeveragePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialBeverage = 0;
            elementKey = 3;
        }

        private void btn_beverage3_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Hot tea";
            prixProduit = QueryBeveragePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialBeverage = 0;
            elementKey = 3;
        }

        private void btn_beverage4_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Biere d'Homère";
            prixProduit = QueryBeveragePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialBeverage = 0;
            elementKey = 3;
        }

        private void btn_beverage5_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Evian";
            prixProduit = QueryBeveragePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialBeverage = 0;
            elementKey = 3;

        }
        #endregion

        #region Boutons des produits Desserts
        private void btn_dessert1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Mac Flower";
            prixProduit = QueryDessertPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialDessert = 0;
            elementKey = 4;
        }
        private void btn_dessert2_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Milk-Shake";
            prixProduit = QueryDessertPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialDessert = 0;
            elementKey = 4;

        }

        private void btn_dessert3_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Sunny Day";
            prixProduit = QueryDessertPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialDessert = 0;
            elementKey = 4;

        }

        private void btn_dessert4_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "MacPomme Purée";
            prixProduit = QueryDessertPrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialDessert = 0;
            elementKey = 4;
        }
        #endregion

        #region Boutons des Produits Side
        private void btn_side1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Frites";
            prixProduit = QuerySidePrice(nameProduit); 
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialSide = 0;
            elementKey = 2;
        }
        private void btn_side2_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Patatoes";
            prixProduit = QuerySidePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialSide = 0;
            elementKey = 2;
        }

        private void btn_side3_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "La salade Canard";
            prixProduit = QuerySidePrice(nameProduit);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialSide = 0;
            elementKey = 2;

        }



        #endregion

        #region Bouton des Menus
        private void btn_menu1_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Happy Meal";
            prixProduit = QueryMenuPrice(nameProduit, 1, 10, 8, 12);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialMenu = 0;
            elementKey = 5;
        }

        private void btn_menu2_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Grand Duke McDuck";
            prixProduit = QueryMenuPrice(nameProduit, 2, 11, 7, 14);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialMenu = 0;
            elementKey = 5;

        }

        private void btn_menu3_Click(object sender, RoutedEventArgs e)
        {
            nameProduit = "Student McDuck";
            prixProduit = QueryMenuPrice(nameProduit, 1, 10, 8, 13);
            choixUser = $"{nameProduit} - {prixProduit.ToString()} $";
            stockInitialMenu = 0;
            elementKey = 5;
        }
        #endregion
    }
}
