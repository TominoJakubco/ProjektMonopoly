 using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Street.xaml
    /// </summary>
    /// 
    public partial class Street : UserControl
    {
        public new string Name { get; private set; }
        public int Price { get; private set; }
        public int[] Rent { get; set; }
        public int HousePrice { get; private set; }
        public int Space { get; private set; }
        public Brush Color { get; private set; }
        public Player? Owner { get; set; }
        public Street(string name, int price, int[] rent,int housePrice, int space, Brush color, Player owner = null)
        {
            Name = name;
            Price = price;
            Rent = rent;
            HousePrice = housePrice;
            Space = space;
            Color = color;
            Owner = owner;

            InitializeComponent();
            SetupStreet();
        }

        public void SetupStreet()
        {
            //barva
            Rectangle streetCol = new Rectangle();
            streetCol.Fill = Color;
            streetCol.Stroke = Brushes.Black;
            streetCol.StrokeThickness = 3;

            //hráči

            //jmeno
            TextBlock nameText = new TextBlock
            {
                Text = Name,
                FontSize = 10,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //cena
            TextBlock priceText = new TextBlock
            {
                Text = "$" + Price.ToString(),
                FontSize = 10,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            if (Space < 10) //dolní strana
            {
                
                //barva
                Grid.SetColumnSpan(streetCol, 4);

                Grid.SetColumn(streetCol, 0);
                Grid.SetRow(streetCol, 0);

                //hráči

                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                nameText.LayoutTransform = rotateTransform;
                
                Grid.SetColumnSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 2);

                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 3);
            }
            else if (Space < 20) //levá strana
            {
                //barva
                Grid.SetRowSpan(streetCol, 4);

                Grid.SetColumn(streetCol, 3);
                Grid.SetRow(streetCol, 0);

                //hráči
                
                //jméno
                RotateTransform rotateTransform = new RotateTransform(90);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(nameText, 4);

                Grid.SetColumn(nameText, 1);
                Grid.SetRow(nameText, 0);

                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 0);
            }
            else if (Space < 30) //vrchní strana
            {
                //barva
                Grid.SetColumnSpan(streetCol, 4);

                Grid.SetColumn(streetCol, 0);
                Grid.SetRow(streetCol, 3);
                
                //hráči
                
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 1);

                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 0);
            }
            else //pravá strana
            {
                //barva
                Grid.SetRowSpan(streetCol, 4);

                Grid.SetColumn(streetCol, 0);
                Grid.SetRow(streetCol, 0);
                
                //hráči
                
                //jméno
                RotateTransform rotateTransform = new RotateTransform(-90);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(nameText, 4);

                Grid.SetColumn(nameText, 2);
                Grid.SetRow(nameText, 0);

                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(priceText, 4);

                Grid.SetColumn(priceText, 3);
                Grid.SetRow(priceText, 0);
            }
            SpaceGrid.Children.Add(streetCol);
            SpaceGrid.Children.Add(nameText);
            SpaceGrid.Children.Add(priceText);
        }
    }
}
