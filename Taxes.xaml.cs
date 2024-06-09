using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Taxes.xaml
    /// </summary>
    public partial class Taxes : UserControl
    {
        public int Space { get; private set; }
        public int TaxPrice { get; private set; }
        public string Name { get; private set; }

        public Taxes(int space, int taxPrice, string name)
        {
            Space = space;
            TaxPrice = taxPrice;
            Name = name;

            InitializeComponent();
            SetupTax();
        }

        public void SetupTax()
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
                Text = "$" + TaxPrice.ToString(),
                FontSize = 10,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            RotateTransform rotateTransform;
            if (Space == 4)
            {
                rotateTransform = new RotateTransform(0);
                
                //jmeno
                nameText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 0);

                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 3);
            }
            else
            {
                rotateTransform = new RotateTransform(-90);

                //jmeno
                nameText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(nameText, 4);

                Grid.SetColumn(nameText, 0);
                Grid.SetRow(nameText, 0);

                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(priceText, 4);

                Grid.SetColumn(priceText, 3);
                Grid.SetRow(priceText, 0);

                //obrazek
                Image taxImage = new Image();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("pack://application:,,,/Images/LuxTaxImg.png");
                bitmap.EndInit();
                taxImage.Source = bitmap;
                Height = 55;
                taxImage.LayoutTransform = rotateTransform;
                

                Grid.SetColumnSpan(taxImage, 2);
                Grid.SetRowSpan(taxImage, 4);

                Grid.SetColumn(taxImage, 1);
                Grid.SetRow(taxImage, 0);

                TaxGrid.Children.Add(taxImage);
            }

            TaxGrid.Children.Add(nameText);
            TaxGrid.Children.Add(priceText);   
        }
    }
}
