using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPF_monopoly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Player CurrentPlayer;
        public int PlayerCount;
        public Player[] Players;
        public Brush[] playerColors = { Brushes.Red, Brushes.Yellow, Brushes.Blue, Brushes.Green };
        public static Spaces[] SpacesArray = new Spaces[40];
        private static int _pCounter = 0;
        private static PlayerInterface[] PlayerInterfaces = new PlayerInterface[4];
        
        //public TextBlock PlayerMoney { get; set; }
        //public TextBox PlayerName { get; set; }

        public MainWindow()
        {
            PlayerCount = 4;
            Players = new Player[PlayerCount];
            for (int i = 0; i < Players.Length; i++)
            {
                Player player = new Player(i, "Player" + (i + 1).ToString(), playerColors[i], 0, 1500/*, null, null, null, null*/);
                Players[i] = player;
            }
            InitializeComponent();
            SetupBoard();
            StartGame();
        }


        
       

        public void StartGame()
        {
            
            
            //int round = 0;
            //Player currentPlayer;

            //while(true)
            {

                int pICount = 0;
                foreach (Player pl in Players)
                {
                    
                    foreach (Spaces sp in SpacesArray)
                    {
                        sp.CheckForPlayers(pl.PlayerID, pl.Space, sp.Number);
                    }
                    PlayerInterface plInt = new PlayerInterface(pl);
                    plInt.Visibility = Visibility.Hidden;
                    UserInt.Children.Add(plInt);
                    PlayerInterfaces[pICount] = plInt;
                    pICount++;
                }

                SetupCurrentPlayer();
            }
        }

        public void SetupBoard()
        {
            Board.Background = Brushes.LightCyan;

            int num = 0;
            int x = 10;
            int y = 10;
            for (int b = 10; b > 0; b--)
            {
                Spaces space = new Spaces(num);

                Grid.SetColumn(space, b);
                Grid.SetRow(space, y);
                Board.Children.Add(space);
                x = 0;
                SpacesArray[num] = space;
                num++;
            }
            for (int l = 10; l > 0; l--)
            {
                Spaces space = new Spaces(num);

                Grid.SetColumn(space, x);
                Grid.SetRow(space, l);
                Board.Children.Add(space);
                y = 0;
                SpacesArray[num] = space;
                num++;
            }
            for (int t = 0; t < 10; t++)
            {
                Spaces space = new Spaces(num);

                Grid.SetColumn(space, t);
                Grid.SetRow(space, y);
                Board.Children.Add(space);
                x = 10;
                SpacesArray[num] = space;
                num++;
            }
            for (int r = 0; r < 10; r++)
            {
                Spaces space = new Spaces(num);

                Grid.SetColumn(space, x);
                Grid.SetRow(space, r);
                Board.Children.Add(space);
                SpacesArray[num] = space;
                num++;
            }
        }

        //public void SetupPlayerInterface(Player player)
        //{
        //    UserInt.Background = Brushes.LightCyan;

        //    //jméno hráče
        //    PlayerName = new TextBox
        //    {
        //        Text = player.Name,
        //        FontFamily = new FontFamily("Segoe UI"),
        //        Margin = new Thickness(10),
        //        Padding = new Thickness(5),
        //        FontSize = 30,
        //        FontWeight = FontWeights.Black,
        //        BorderBrush = Brushes.Gray,
        //        BorderThickness = new Thickness(3),
        //        Background = Brushes.White,
        //        Foreground = Brushes.Black,
        //        VerticalContentAlignment = VerticalAlignment.Center,
        //        HorizontalContentAlignment = HorizontalAlignment.Center,
        //        Height = 100,
        //        Width = 870,

        //        HorizontalAlignment = HorizontalAlignment.Center,
        //        VerticalAlignment = VerticalAlignment.Top,
        //    };

        //    PlayerMoney = new TextBlock
        //    {
        //        Text = "Peníze:  $" + player.Money,
        //        FontFamily = new FontFamily("Segoe UI"),
        //        Margin = new Thickness(10, 150, 10, 10),
        //        Padding = new Thickness(5),
        //        FontSize = 30,
        //        FontWeight = FontWeights.Black,
        //        Height = 100,
        //        Width = 870,

        //        HorizontalAlignment = HorizontalAlignment.Center,
        //        VerticalAlignment = VerticalAlignment.Top,
        //    };

        //    Border playerInventoryBorder = new Border
        //    {
        //        BorderBrush = Brushes.Black,
        //        BorderThickness = new Thickness(3),

        //        Width = 875,
        //        Height = 580,
        //        Margin = new Thickness(10, 0, 5, 0),
        //    };

        //    //Peníze
        //    //pozemky
        //    //výška 225
        //    //možnost prodat
        //    //tlačítko hodit kostkou

        //    UserInt.Children.Add(PlayerName);
        //    UserInt.Children.Add(PlayerMoney);
        //}

        public void SetupCurrentPlayer()
        {
            CurrentPlayer = Players[_pCounter];
            PlayerInterfaces[_pCounter].SetupPlayerInterface();
            PlayerInterfaces[_pCounter].Visibility = Visibility.Visible;
            CheckSpace(CurrentPlayer.Space, 0);
        }

        private void DiceClick(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int diceRoll = rnd.Next(2, 13);
            diceRoll = 3;

            if(CurrentPlayer.Space + diceRoll < 40)
            {
                CurrentPlayer.Space += diceRoll;
            }
            else
            {
                CurrentPlayer.Space = CurrentPlayer.Space + diceRoll - 40;
            }
            foreach (Spaces sp in SpacesArray)
            {
                sp.CheckForPlayers(CurrentPlayer.PlayerID, CurrentPlayer.Space, sp.Number);
                
            }

            CheckSpace(CurrentPlayer.Space, diceRoll);
            
        }

        public void CheckSpace(int space, int roll)
        {
            //nakup
            if(SpacesArray[space].IsOwnable)
            {
                if (SpacesArray[space].IsOwnable && SpacesArray[space].Owner == null)
                {
                    BuyBtn.Visibility = Visibility.Visible;
                    SellBtn.Visibility = Visibility.Hidden;
                }
                else if(SpacesArray[space].IsOwnable && SpacesArray[space].Owner != CurrentPlayer && SpacesArray[space].Owner != null)
                {
                    BuyBtn.Visibility = Visibility.Hidden;
                    SellBtn.Visibility = Visibility.Hidden;
                    SpacesArray[space].Pay(CurrentPlayer, roll);
                    PlayerInterfaces[_pCounter].SetupPlayerInterface();
                }
                else if(SpacesArray[space].IsOwnable && SpacesArray[space].Owner == CurrentPlayer)
                {
                    BuyBtn.Visibility = Visibility.Hidden;
                    SellBtn.Visibility = Visibility.Visible;
                }
            }
        }

        //public void CheckForPurchase(int space)
        //{
        //    if (Spaces[space].IsOwnable && Spaces[space].Owner == null)
        //    {
        //        BuyBtn.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        BuyBtn.Visibility = Visibility.Hidden;
        //    }
        //}

        private void ChangePlayerClick(object sender, RoutedEventArgs e)
        {
            PlayerInterfaces[_pCounter].Visibility = Visibility.Hidden;
            if (_pCounter == 3)
                _pCounter = 0;
            else
                _pCounter++;
            PlayerInterfaces[_pCounter].Visibility = Visibility.Visible;

            SetupCurrentPlayer();
        }

        private void BuyBtnClick(object sender, RoutedEventArgs e)
        {
            SpacesArray[CurrentPlayer.Space].BuyProperty(CurrentPlayer);
            BuyBtn.Visibility = Visibility.Hidden;


            //UserInt.Children.Remove(PlayerName);
            //PlayerName.Text = CurrentPlayer.Name;
            //UserInt.Children.Remove(PlayerMoney);
            PlayerInterfaces[_pCounter].SetupPlayerInterface();
        }

        private void SellBtnClick(object sender, RoutedEventArgs e)
        {
            SpacesArray[CurrentPlayer.Space]
        }
    }
}