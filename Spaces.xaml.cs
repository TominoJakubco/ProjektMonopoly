using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace WPF_monopoly
{
    /// <summary>
    /// Interaction logic for Spaces.xaml
    /// </summary>
    public partial class Spaces : UserControl
    {
        public int Number { get; private set; }
        public Rectangle[] PlayerFigures;
        public bool IsOwnable { get; private set; }
        public Player Owner = null;
        public static Street[] StreetsArray = new Street[22];
        public static Railroads[] RailroadsArray = new Railroads[4];
        public static Companies[] CompaniesArray = new Companies[2];
        

        //public Rectangle[] Players { get; set; }

        //propdp

        private static int _streetCount = 0;
        private static int _railCount = 0;
        private static int _companyCount = 0;
        private static int _chanceCount = 0;
        private static int _comChestCount = 0;
        private static int _taxCount = 0;

        public Spaces(int number)
        {
            Number = number;
            
            InitializeComponent();
            SetupSpace();
            SetupPlayers();
            SetupBorder();
        }

        int[] streetNum = { 1, 3, 6, 8, 9, 11, 13, 14, 16, 18, 19, 21, 23, 24, 26, 27, 29, 31, 32, 34, 37, 39 };
        int[] railroadNum = { 5, 15, 25, 35 };
        int[] companyNum = { 12, 28 };
        int[] chanceNum = { 7, 22, 36 };
        int[] comChestNum = { 2, 17, 33 };
        int[] taxNum = { 4, 38 };

        Brush[] currentStreetColor = {
            Brushes.Brown, Brushes.Brown,
            Brushes.Cyan, Brushes.Cyan, Brushes.Cyan,
            Brushes.Magenta, Brushes.Magenta, Brushes.Magenta,
            Brushes.Orange, Brushes.Orange, Brushes.Orange,
            Brushes.Red, Brushes.Red, Brushes.Red,
            Brushes.Yellow, Brushes.Yellow, Brushes.Yellow,
            Brushes.Green, Brushes.Green, Brushes.Green,
            Brushes.Blue, Brushes.Blue
        };

        string[] streetNames = 
            {
                "Mediterranean Avenue",
                "Baltic Avenue",
                "Oriental Avenue",
                "Vermont Avenue",
                "Connecticut Avenue",
                "St. Charles Place",
                "States Avenue",
                "Virginia Avenue",
                "St. James Place",
                "Tennessee Avenue",
                "New York Avenue",
                "Kentucky Avenue",
                "Indiana Avenue",
                "Illinois Avenue",
                "Atlantic Avenue",
                "Ventnor Avenue",
                "Marvin Gardens",
                "Pacific Avenue",
                "North Carolina Avenue",
                "Pennsylvania Avenue",
                "Park Place",
                "Boardwalk"
            };
        string[] railNames =
        {
            "Reading Railroad",
            "Pennsylvania Railroad",
            "B&O Railroad",
            "Short Line"
        };
        string[] companyNames =
        {
            "Electric Company",
            "Water Works"
        };
        string[] taxNames =
        {
            "Income Tax",
            "Luxury Tax"
        };
            
        int[] streetPrices = [60, 60, 100, 100, 120, 140, 140, 160, 180, 180, 200, 220, 220, 240, 260, 260, 280, 300, 300, 320, 350, 400];
        int[,] streetRent = 
            {
                {2, 10, 30, 90, 160, 250},
                {4, 20, 60, 180, 320, 450},
                {6, 30, 90, 270, 400, 550},
                {6, 30, 90, 270, 400, 550},
                {8, 40, 100, 300, 450, 600},
                {10, 50, 150, 450, 625, 750},
                {10, 50, 150, 450, 625, 750},
                {12, 60, 180, 500, 700, 900},
                {14, 70, 200, 550, 750, 950},
                {14, 70, 200, 550, 750, 950},
                {16, 80, 220, 600, 800, 1000},
                {18, 90, 250, 700, 875, 1050},
                {18, 90, 250, 700, 875, 1050},
                {20, 100, 300, 750, 925, 1100},
                {22, 110, 330, 800, 975, 1150},
                {22, 110, 330, 800, 975, 1150},
                {24, 120, 360, 850, 1025, 1200},
                {26, 130, 390, 900, 1100, 1275},
                {26, 130, 390, 900, 1100, 1275},
                {28, 150, 450, 1000, 1200, 1400},
                {35, 175, 500, 1100, 1300, 1500},
                {50, 200, 600, 1400, 1700, 2000}
            };
        int[] railRent = { 25, 50, 100, 200 };
        int[] taxPrices = { 200, 100 };

        int[] housePrices = [50, 100, 150, 200];

        Street[,] streetSets = new Street[8, 3];

        public void SetupSpace()
        {
            if (Number == 0)
            {
                Start start = new Start(Number);
                SetSpan(start, 8);

                Space.Children.Add(start); 
            }
            else if (Number == 10)
            {
                VisitingJail jail = new VisitingJail(Number);
                SetSpan(jail, 8);
                Space.Children.Add(jail);
            }
            else if (Number == 20)
            {
                FreeParking parking = new FreeParking(Number);
                SetSpan(parking, 8);
                Space.Children.Add(parking);
            }
            else if (Number == 30)
            {
                GoToJail goToJail = new GoToJail(Number);
                SetSpan(goToJail, 8);
                Space.Children.Add(goToJail);
            }
            else if (streetNum.Contains(Number))
            {
                int[] RentArray = new int[6];
                for (int i = 0; i < 6; i++)
                    RentArray[i] = streetRent[_streetCount, i];
                
                Street street = new Street(streetNames[_streetCount], streetPrices[_streetCount], RentArray, housePrices[Number / 10], Number, currentStreetColor[_streetCount]);
                SetSpan(street, 8);
                

                if(_streetCount < 2)
                {
                    streetSets[0, _streetCount] = street;
                }
                else if(_streetCount > 1 && _streetCount < 20)
                {
                    streetSets[(_streetCount + 1) / 3, _streetCount % 3] = street;
                }
                else
                {
                    streetSets[7, _streetCount % 3] = street;
                }

                IsOwnable = true;
                StreetsArray[_streetCount] = street;
                Space.Children.Add(street);
                _streetCount++;
            }
            else if (railroadNum.Contains(Number))
            {
                Railroads railroad = new Railroads(railNames[_railCount], 200, railRent, Number);
                SetSpan(railroad, 8);

                IsOwnable = true;
                RailroadsArray[_railCount] = railroad;
                Space.Children.Add(railroad);
                _railCount++;
            }
            else if (companyNum.Contains(Number))
            {
                Companies company = new Companies(companyNames[_companyCount], 150, 0, Number);
                SetSpan(company, 8);

                IsOwnable = true;
                CompaniesArray[_companyCount] = company;
                Space.Children.Add(company);
                _companyCount++;
            }
            else if (chanceNum.Contains(Number))
            {
                Chance chance = new Chance(Number);
                SetSpan(chance, 8);

                Space.Children.Add(chance);
            }
            else if (comChestNum.Contains(Number))
            {
                ComunnityChest comChest = new ComunnityChest(Number);
                SetSpan(comChest, 8);

                Space.Children.Add(comChest);
            }
            else if (taxNum.Contains(Number))
            {
                Taxes tax = new Taxes(Number, taxPrices[_taxCount], taxNames[_taxCount]);
                SetSpan(tax, 8);

                Space.Children.Add(tax);
                _taxCount++;
            }

            
        }
        public void SetSpan(UserControl control, int num)
        {
            Grid.SetColumnSpan(control, num);
            Grid.SetRowSpan(control, num);
        }

        public void SetupPlayers()
        {
            //int count = 0;
            
            PlayerFigures = new Rectangle[4];
            Brush[] playerColors = { Brushes.Red, Brushes.Yellow, Brushes.Blue, Brushes.Green };

            for (int i = 0; i < 4; i++)
            {
                Rectangle player = new Rectangle();
                player.Visibility = Visibility.Hidden;
                player.Fill = playerColors[i];
                if (Number % 10 == 0)
                {
                        switch (Number)
                        {
                            case 0:
                                switch (i)
                                {
                                    case 0:
                                        Grid.SetRow(player, 3);
                                        Grid.SetColumn(player, 3);
                                        break;
                                    case 1:
                                        Grid.SetRow(player, 3);
                                        Grid.SetColumn(player, 5);
                                        break;
                                    case 2:
                                        Grid.SetRow(player, 5);
                                        Grid.SetColumn(player, 3);
                                        break;
                                    case 3:
                                        Grid.SetRow(player, 5);
                                        Grid.SetColumn(player, 5);
                                        break;
                                    default:
                                        break;
                                }
                                
                                break;
                            case 10:
                                switch (i)
                                {
                                    case 0:
                                        Grid.SetRow(player, 0);
                                        Grid.SetColumn(player, 1);
                                        break;
                                    case 1:
                                        Grid.SetRow(player, 5);
                                        Grid.SetColumn(player, 1);
                                        break;
                                    case 2:
                                        Grid.SetRow(player, 6);
                                        Grid.SetColumn(player, 2);
                                        break;
                                    case 3:
                                        Grid.SetRow(player, 6);
                                        Grid.SetColumn(player, 7);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                                case 20:
                                    switch (i)
                                    {
                                        case 0:
                                            Grid.SetRow(player, 2);
                                            Grid.SetColumn(player, 2);
                                            break;
                                        case 1:
                                            Grid.SetRow(player, 2);
                                            Grid.SetColumn(player, 5);
                                            break;
                                        case 2:
                                            Grid.SetRow(player, 5);
                                            Grid.SetColumn(player, 2);
                                            break;
                                        case 3:
                                            Grid.SetRow(player, 5);
                                            Grid.SetColumn(player, 5);
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            case 30:
                                switch (i)
                                {
                                    case 0:
                                        Grid.SetRow(player, 2);
                                        Grid.SetColumn(player, 2);
                                        break;
                                    case 1:
                                        Grid.SetRow(player, 2);
                                        Grid.SetColumn(player, 5);
                                        break;
                                    case 2:
                                        Grid.SetRow(player, 5);
                                        Grid.SetColumn(player, 2);
                                        break;
                                    case 3:
                                        Grid.SetRow(player, 5);
                                        Grid.SetColumn(player, 5);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                        default:
                                break;
                        }
                    }
                else if (Number < 10)
                {
                    Grid.SetColumnSpan(player, 2);
                    Grid.SetRowSpan(player, 2);

                    Grid.SetRow(player, 2);
                    Grid.SetColumn(player, 2 * i);
                }
                else if (Number < 20)
                {
                    Grid.SetColumnSpan(player, 2);
                    Grid.SetRowSpan(player, 2);

                    Grid.SetRow(player, 2 * i);
                    Grid.SetColumn(player, 4);
                }
                else if (Number < 30)
                {
                    Grid.SetColumnSpan(player, 2);
                    Grid.SetRowSpan(player, 2);

                    Grid.SetRow(player, 4);
                    Grid.SetColumn(player, 2 * i);
                }
                else if (Number < 40)
                {
                    Grid.SetColumnSpan(player, 2);
                    Grid.SetRowSpan(player, 2);

                    Grid.SetRow(player, 2 * i);
                    Grid.SetColumn(player, 2);
                }

                PlayerFigures[i] = player;
                Space.Children.Add(player);  
            }

            
        }

        public void CheckForPlayers(int playerNumber, int currentPlayerSpace, int currentSpace)
        {
            if(currentPlayerSpace == currentSpace)
            {
                PlayerFigures[playerNumber].Visibility = Visibility.Visible;
            }
            else
                PlayerFigures[playerNumber].Visibility = Visibility.Hidden;
        }



        public void SetupBorder()
        {
            Border border = new Border
            {
                BorderThickness = new Thickness(3, 3, 3, 3),
                BorderBrush = Brushes.Black
            };

            Grid.SetColumnSpan(border, 8);
            Grid.SetRowSpan(border, 8);

            Space.Children.Add(border);
        }

        public void BuyProperty(Player player)
        {
            if(streetNum.Contains(player.Space))
            {
                for (int i = 0; i < streetNum.Length; i++)
                {
                    if (streetNum[i] == player.Space && player.Money >= streetPrices[i])
                    {
                        player.Money -= streetPrices[i];
                        Owner = player;
                        player.OwnedStreets.Add(StreetsArray[i]);
                        break;
                    }
                        
                }
            }
            else if(railroadNum.Contains(player.Space))
            {
                for (int i = 0; i < railroadNum.Length; i++)
                {
                    if (railroadNum[i] == player.Space && player.Money >= 200)
                    {
                        player.Money -= 200;
                        Owner = player;
                        player.OwnedRails.Add(RailroadsArray[i]);
                        break;
                    }

                }
            }
            else if(companyNum.Contains(player.Space))
            {
                for (int i = 0; i < companyNum.Length; i++)
                {
                    if (companyNum[i] == player.Space && player.Money >= 150)
                    {
                        player.Money -= 150;
                        Owner = player;
                        player.OwnedCompanies.Add(CompaniesArray[i]);
                        break;
                    }
                    
                }
            }
        }

        public void Pay(Player player, int roll)
        {
            if (streetNum.Contains(player.Space))
            {
                for (int i = 0; i < streetNum.Length; i++)
                {
                    if (streetNum[i] == player.Space)
                    {
                        player.Money -= streetRent[i, 0];
                    }

                }
            }
            else if (railroadNum.Contains(player.Space))
            {
                for (int i = 0; i < railroadNum.Length; i++)
                {
                    if (railroadNum[i] == player.Space)
                    {       
                        player.Money -= 50 * Owner.OwnedRails.Count;
                    }

                }
            }
            else if (companyNum.Contains(player.Space))
            {
                for (int i = 0; i < companyNum.Length; i++)
                {
                    if (companyNum[i] == player.Space && player.Money >= 150)
                    {
                        if(Owner.OwnedCompanies.Count == 1)
                        {
                            player.Money -= roll * 4;
                        }
                        else if(Owner.OwnedCompanies.Count == 2)
                        {
                            player.Money -= roll * 10;
                        }
                    }

                }
            }
        }
    }
}
