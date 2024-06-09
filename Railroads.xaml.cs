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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Net.Mime.MediaTypeNames.Image;

namespace WPF_monopoly
{
    /// <summary>
    /// Interaction logic for Railroads.xaml
    /// </summary>
    public partial class Railroads : UserControl
    {
        public new string Name { get; private set; }
        public int Price { get; private set; }
        public int[] Rent { get; set; }
        public int Space { get; private set; }
        public string? Owner { get; set; }

        public Railroads(string name, int price, int[] rent, int space, string? owner = null)
        {
            Name = name;
            Price = price;
            Rent = rent;
            Space = space;
            Owner = owner;

            InitializeComponent();
            SetupRailroad();
        }

        private void SetupRailroad()
        {
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

            //obrázek
            TrainImage.Width = 65;
            

            if (Space < 10) //dolní strana
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 0);

                //obrázek
                TrainImage.LayoutTransform = rotateTransform;
                TrainImage.VerticalAlignment = VerticalAlignment.Bottom;


                Grid.SetColumnSpan(TrainImage, 4);
                Grid.SetRowSpan(TrainImage, 2);

                Grid.SetColumn(TrainImage, 0);
                Grid.SetRow(TrainImage, 1);

                //hráči



                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 3);
            }
            else if (Space < 20) //levá strana
            {
                //jméno
                RotateTransform rotateTransform = new RotateTransform(90);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(nameText, 4);

                Grid.SetColumn(nameText, 3);
                Grid.SetRow(nameText, 0);

                //obrázek
                TrainImage.LayoutTransform = rotateTransform;
                TrainImage.HorizontalAlignment = HorizontalAlignment.Left;

                Grid.SetColumnSpan(TrainImage, 2);
                Grid.SetRowSpan(TrainImage, 4);

                Grid.SetColumn(TrainImage, 1);
                Grid.SetRow(TrainImage, 0);

                //hráči



                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 0);
            }
            else if (Space < 30) //vrchní strana
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 3);

                //obrázek
                TrainImage.LayoutTransform = rotateTransform;
                TrainImage.VerticalAlignment = VerticalAlignment.Top;

                Grid.SetColumnSpan(TrainImage, 4);
                Grid.SetRowSpan(TrainImage, 2);

                Grid.SetColumn(TrainImage, 0);
                Grid.SetRow(TrainImage, 1);

                //hráči



                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 0);
            }
            else //pravá strana
            {
                //jméno
                RotateTransform rotateTransform = new RotateTransform(-90);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 0);

                //obrázek
                TrainImage.LayoutTransform = rotateTransform;
                TrainImage.HorizontalAlignment = HorizontalAlignment.Right;


                Grid.SetColumnSpan(TrainImage, 2);
                Grid.SetRowSpan(TrainImage, 4);

                Grid.SetColumn(TrainImage, 1);
                Grid.SetRow(TrainImage, 0);

                //hráči



                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(priceText, 4);

                Grid.SetColumn(priceText, 3);
                Grid.SetRow(priceText, 0);
            }
            RailGrid.Children.Add(nameText);
            RailGrid.Children.Add(priceText);
        }
    }
    
}
