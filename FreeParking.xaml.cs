﻿using System;
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
    /// Interaction logic for FreeParking.xaml
    /// </summary>
    public partial class FreeParking : UserControl
    {
        public int Space { get; private set; }

        public FreeParking(int space)
        {
            Space = Space;

            InitializeComponent();
            SetupFreeParking();
        }

        private void SetupFreeParking()
        {
            //text Free
            TextBlock freeText = new TextBlock
            {
                Text = "FREE",
                FontSize = 15,
                FontWeight = FontWeights.Bold,

                Width = 65,
                TextWrapping = TextWrapping.Wrap,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            RotateTransform rotateTransformText = new RotateTransform(-45);
            RotateTransform rotateTransformImage = new RotateTransform(135);
            freeText.LayoutTransform = rotateTransformText;

            Grid.SetColumnSpan(freeText, 4);
            Grid.SetRowSpan(freeText, 4);

            Grid.SetColumn(freeText, 0);
            Grid.SetRow(freeText, 0);

            TextBlock parkingText = new TextBlock
            {
                Text = "PARKING",
                FontSize = 15,
                FontWeight = FontWeights.Bold,

                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            parkingText.LayoutTransform = rotateTransformText;

            Grid.SetColumnSpan(parkingText, 4);
            Grid.SetRowSpan(parkingText, 4);

            Grid.SetColumn(parkingText, 4);
            Grid.SetRow(parkingText, 4);



            //obrázek
            Image freeParkingImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/FreeParkingImg.png");
            bitmap.EndInit();
            freeParkingImage.Source = bitmap;
            freeParkingImage.LayoutTransform = rotateTransformImage;
            freeParkingImage.VerticalAlignment = VerticalAlignment.Center;
            freeParkingImage.HorizontalAlignment = HorizontalAlignment.Center;
            freeParkingImage.Width = 112;

            Grid.SetColumnSpan(freeParkingImage, 6);
            Grid.SetRowSpan(freeParkingImage, 6);

            Grid.SetColumn(freeParkingImage, 1);
            Grid.SetRow(freeParkingImage, 1);

            FreeParkingGrid.Children.Add(freeText);
            FreeParkingGrid.Children.Add(parkingText);
            FreeParkingGrid.Children.Add(freeParkingImage);
        }
    }
}
