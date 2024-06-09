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
    /// Interaction logic for VisitingJail.xaml
    /// </summary>
    public partial class VisitingJail : UserControl
    {
        public int Space { get; private set; }

        public VisitingJail(int space)
        {
            Space = space;

            InitializeComponent();
            SetupJail();
        }

        private void SetupJail()
        {
            //text Just
            TextBlock jailJustText = new TextBlock
            {
                Text = "JUST",
                FontSize = 15,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            RotateTransform rotateTransform = new RotateTransform(90);
            jailJustText.LayoutTransform = rotateTransform;

            Grid.SetColumnSpan(jailJustText, 2);
            Grid.SetRowSpan(jailJustText, 6);

            Grid.SetColumn(jailJustText, 0);
            Grid.SetRow(jailJustText, 0);

            //text Just
            TextBlock jailVisitingText = new TextBlock
            {
                Text = "VISITING",
                FontSize = 15,
                FontWeight = FontWeights.Bold,


                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            RotateTransform rotateTransformNumeroDuo = new RotateTransform(0);
            jailVisitingText.LayoutTransform = rotateTransformNumeroDuo;

            Grid.SetColumnSpan(jailVisitingText, 6);
            Grid.SetRowSpan(jailVisitingText, 2);

            Grid.SetColumn(jailVisitingText, 2);
            Grid.SetRow(jailVisitingText, 6);

            //obrázek
            Image JailImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/JailImg.png");
            bitmap.EndInit();
            JailImage.Source = bitmap;
            JailImage.VerticalAlignment = VerticalAlignment.Center;
            JailImage.HorizontalAlignment = HorizontalAlignment.Center;
            JailImage.Width = 112;

            Grid.SetColumnSpan(JailImage, 6);
            Grid.SetRowSpan(JailImage, 6);

            Grid.SetColumn(JailImage, 2);
            Grid.SetRow(JailImage, 0);

            JailGrid.Children.Add(jailJustText);
            JailGrid.Children.Add(jailVisitingText);
            JailGrid.Children.Add(JailImage);

            //hráči
        }
    }
}
