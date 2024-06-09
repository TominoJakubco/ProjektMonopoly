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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : UserControl
    {
        public int Space { get; private set; }

        public Start(int space)
        {
            Space = space;

            InitializeComponent();
            SetupStart();
        }

        private void SetupStart()
        {
            //text
            TextBlock startText = new TextBlock
            {
                Text = "Collect $200 salary as you pass".ToUpper(),
                FontSize = 10,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            RotateTransform rotateTransform = new RotateTransform(-45);
            startText.LayoutTransform = rotateTransform;

            Grid.SetColumnSpan(startText, 5);
            Grid.SetRowSpan(startText, 5);

            Grid.SetColumn(startText, 0);
            Grid.SetRow(startText, 0);

            //šipka
            Image startArrowImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/StartArrowImg.png");
            bitmap.EndInit();
            startArrowImage.Source = bitmap;
            startArrowImage.VerticalAlignment = VerticalAlignment.Center;
            startArrowImage.HorizontalAlignment = HorizontalAlignment.Center;
            startArrowImage.Width = 130;

            Grid.SetColumnSpan(startArrowImage, 8);
            Grid.SetRowSpan(startArrowImage, 3);

            Grid.SetColumn(startArrowImage, 0);
            Grid.SetRow(startArrowImage, 5);

            StartGrid.Children.Add(startText);
            StartGrid.Children.Add(startArrowImage);

            //hráči
        }
    }
}
