using System;
using System.Collections.Generic;
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

namespace WPF_monopoly
{
    /// <summary>
    /// Interaction logic for PlayerInterface.xaml
    /// </summary>
    public partial class PlayerInterface : UserControl
    {
        public Player Player { get; set; }


        public string PlayerName
        {
            get { return (string)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerNameProperty =
            DependencyProperty.Register("PlayerName", typeof(string), typeof(PlayerInterface), new PropertyMetadata("Player"));



        public string PlayerMoney
        {
            get { return (string)GetValue(PlayerMoneyProperty); }
            set { SetValue(PlayerMoneyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerMoney.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerMoneyProperty =
            DependencyProperty.Register("PlayerMoney", typeof(string), typeof(PlayerInterface), new PropertyMetadata("Money"));






        public PlayerInterface(Player player)
        {
            Player = player;
            
            InitializeComponent();
            SetupPlayerInterface();
        }

        public void SetupPlayerInterface()
        {
            PlayerName = Player.Name;
            PlayerMoney = "Money: $" + Player.Money;
        }
    }
}
