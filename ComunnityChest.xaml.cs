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
    /// Interaction logic for ComunnityChest.xaml
    /// </summary>
    public partial class ComunnityChest : UserControl
    {
        public int Space { get; private set; }

        private static string[] _deck =
        {
            "pack://application:,,,/Images/ComChest/CC_Advance_toGo.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_BEIYF.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_DF.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_FSOS.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_GOO.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_GOOJF.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_GTJ.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_ITR.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_LIM.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_PH.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_PST.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_RFS.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_XFM.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_YAAFSR.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_YHWSPABC.png",
            "pack://application:,,,/Images/ComChest/Community_Chest_YI.png",

        };

        private static string[] _usedDeck = new string[16];

        public ComunnityChest(int space)
        {
            Space = space;

            InitializeComponent();
            SetupComChest();
        }

        private void SetupComChest()
        {
            //jmeno
            TextBlock comChestText = new TextBlock
            {
                Text = "Comunnity Chest",
                FontSize = 10,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            //obrazek
            Image comChestImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/ComunnityChestImg.png");
            bitmap.EndInit();
            comChestImage.Source = bitmap;
            comChestImage.Margin = new Thickness(10);

            if (Space == 2)
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(0);
                comChestText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(comChestText, 4);

                Grid.SetColumn(comChestText, 0);
                Grid.SetRow(comChestText, 0);

                //obrázek
                comChestImage.LayoutTransform = rotateTransform;
                comChestImage.VerticalAlignment = VerticalAlignment.Bottom;
                comChestImage.HorizontalAlignment = HorizontalAlignment.Center;

                Grid.SetColumnSpan(comChestImage, 4);
                Grid.SetRowSpan(comChestImage, 3);

                Grid.SetColumn(comChestImage, 0);
                Grid.SetRow(comChestImage, 1);

                //hráči
            }
            else if (Space == 17)
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(90);
                comChestText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(comChestText, 4);

                Grid.SetColumn(comChestText, 3);
                Grid.SetRow(comChestText, 0);

                //obrázek
                comChestImage.LayoutTransform = rotateTransform;
                comChestImage.VerticalAlignment = VerticalAlignment.Center;
                comChestImage.HorizontalAlignment = HorizontalAlignment.Left;


                Grid.SetColumnSpan(comChestImage, 3);
                Grid.SetRowSpan(comChestImage, 4);

                Grid.SetColumn(comChestImage, 0);
                Grid.SetRow(comChestImage, 0);

                //hráči
            }
            else
            {
                //jmeno
                RotateTransform rotateTransform = new RotateTransform(-90);
                comChestText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(comChestText, 4);

                Grid.SetColumn(comChestText, 0);
                Grid.SetRow(comChestText, 0);

                //obrázek
                comChestImage.LayoutTransform = rotateTransform;
                comChestImage.VerticalAlignment = VerticalAlignment.Center;
                comChestImage.HorizontalAlignment = HorizontalAlignment.Right;


                Grid.SetColumnSpan(comChestImage, 3);
                Grid.SetRowSpan(comChestImage, 4);

                Grid.SetColumn(comChestImage, 1);
                Grid.SetRow(comChestImage, 0);

                //hráči
            }
            ComChestGrid.Children.Add(comChestText);
            ComChestGrid.Children.Add(comChestImage);
        }
    }
}
