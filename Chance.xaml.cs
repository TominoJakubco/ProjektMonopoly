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
    /// Interaction logic for Chance.xaml
    /// </summary>
    public partial class Chance : UserControl
    {
        public int Space { get; private set; }

        private static string[] _deck =
            {
                "pack://application:,,,/Images/Chance/Advance_To_Boardwalk.png",
                "pack://application:,,,/Images/Chance/Advance_To_Go.png",
                "pack://application:,,,/Images/Chance/Chance_ATIA.png",
                "pack://application:,,,/Images/Chance/Chance_ATSCP.png",
                "pack://application:,,,/Images/Chance/Chance_ATSCP.png",
                "pack://application:,,,/Images/Chance/Chance_ATTNU.png",
                "pack://application:,,,/Images/Chance/Chance_ATSCP.png",
                "pack://application:,,,/Images/Chance/Chance_GB3S.png",
                "pack://application:,,,/Images/Chance/Chance_GOOTJF.png",
                "pack://application:,,,/Images/Chance/Chance_GTJ.png",
                "pack://application:,,,/Images/Chance/Chance_MGR.png",
                "pack://application:,,,/Images/Chance/Chance_PPT.png",
                "pack://application:,,,/Images/Chance/Chance_TAROTR.png",
                "pack://application:,,,/Images/Chance/Chance_YHBAECOTB.png",
                "pack://application:,,,/Images/Chance/Chance_YBALM.png"
            };

        private static string[] _usedDeck = new string[16];

        public Chance(int space)
        {
            Space = space;

            InitializeComponent();
            SetupChance();
        }

        private void SetupChance()
        {
            //jmeno
            TextBlock chanceText = new TextBlock
            {
                Text = "Chance",
                FontSize = 10,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //obrazek
            Image chanceImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/ChanceImg.png");
            bitmap.EndInit();
            chanceImage.Source = bitmap;
            chanceImage.Margin = new Thickness(10);

            if (Space == 7)
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                chanceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(chanceText, 4);

                Grid.SetColumn(chanceText, 0);
                Grid.SetRow(chanceText, 0);

                //obrázek
                chanceImage.Width = 65;
                chanceImage.LayoutTransform = rotateTransform;
                chanceImage.VerticalAlignment = VerticalAlignment.Bottom;

                Grid.SetColumnSpan(chanceImage, 4);
                Grid.SetRowSpan(chanceImage, 3);

                Grid.SetColumn(chanceImage, 0);
                Grid.SetRow(chanceImage, 1);

                //hráči
            }
            else if (Space == 22)
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                chanceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(chanceText, 4);

                Grid.SetColumn(chanceText, 0);
                Grid.SetRow(chanceText, 3);

                //obrázek
                chanceImage.Width = 65;
                chanceImage.LayoutTransform = rotateTransform;
                chanceImage.VerticalAlignment = VerticalAlignment.Top;

                Grid.SetColumnSpan(chanceImage, 4);
                Grid.SetRowSpan(chanceImage, 3);

                Grid.SetColumn(chanceImage, 0);
                Grid.SetRow(chanceImage, 0);

                //hráči
            }
            else
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(-90);
                chanceText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(chanceText, 4);

                Grid.SetColumn(chanceText, 0);
                Grid.SetRow(chanceText, 0);

                //obrázek
                chanceImage.Width = 65;
                chanceImage.LayoutTransform = rotateTransform;
                chanceImage.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumnSpan(chanceImage, 3);
                Grid.SetRowSpan(chanceImage, 4);

                Grid.SetColumn(chanceImage, 1);
                Grid.SetRow(chanceImage, 0);

                //hráči
            }
            ChanceGrid.Children.Add(chanceText);
            ChanceGrid.Children.Add(chanceImage);
        }

        
    }
}

