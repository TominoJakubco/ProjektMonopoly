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
    /// Interaction logic for Companies.xaml
    /// </summary>
    public partial class Companies : UserControl
    {
        public new string Name { get; private set; }
        public int Price { get; private set; }
        public int Rent { get; set; }
        public int Space { get; private set; }
        public string? Owner { get; set; }

        public Companies(string name, int price, int rent, int space, string? owner = null)
        {
            Name = name;
            Price = price;
            Rent = rent;
            Space = space;
            Owner = owner;

            InitializeComponent();
            SetupCompany();
        }

        private void SetupCompany()
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
            Image companyImage = new Image();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();


            if (Space == 12)
            {
                bitmap.UriSource = new Uri("pack://application:,,,/Images/ElCompanyImg.png");
                bitmap.EndInit();
                
            }
            else if (Space == 28)
            {
                bitmap.UriSource = new Uri("pack://application:,,,/Images/WaterWorksImg.png");
                bitmap.EndInit();
                
            }
            companyImage.Source = bitmap;
            

            //if (Space < 10) //dolní strana
            //{
            //    //jmeno
            //    RotateTransform rotateTransform = new RotateTransform(0);
            //    nameText.LayoutTransform = rotateTransform;

            //    Grid.SetColumnSpan(nameText, 4);

            //    Grid.SetColumn(nameText, 0);
            //    Grid.SetRow(nameText, 0);

            //    //obrázek
            //    CompanyImage.LayoutTransform = rotateTransform;
            //    CompanyImage.VerticalAlignment = VerticalAlignment.Bottom;


            //    Grid.SetColumnSpan(CompanyImage, 4);
            //    Grid.SetRowSpan(CompanyImage, 2);

            //    Grid.SetColumn(CompanyImage, 0);
            //    Grid.SetRow(CompanyImage, 1);

            //    //hráči



            //    //cena
            //    priceText.LayoutTransform = rotateTransform;

            //    Grid.SetColumnSpan(priceText, 4);

            //    Grid.SetColumn(priceText, 0);
            //    Grid.SetRow(priceText, 3);
            //}
            if (Space < 20) //levá strana
            {
                //jméno
                RotateTransform rotateTransform = new RotateTransform(90);
                nameText.LayoutTransform = rotateTransform;

                Grid.SetRowSpan(nameText, 4);

                Grid.SetColumn(nameText, 3);
                Grid.SetRow(nameText, 0);

                //obrázek
                companyImage.Height = 65;
                companyImage.LayoutTransform = rotateTransform;
                companyImage.HorizontalAlignment = HorizontalAlignment.Left;

                Grid.SetColumnSpan(companyImage, 2);
                Grid.SetRowSpan(companyImage, 4);

                Grid.SetColumn(companyImage, 1);
                Grid.SetRow(companyImage, 0);

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
                companyImage.Width = 65;
                companyImage.LayoutTransform = rotateTransform;
                companyImage.VerticalAlignment = VerticalAlignment.Top;

                Grid.SetColumnSpan(companyImage, 4);
                Grid.SetRowSpan(companyImage, 2);

                Grid.SetColumn(companyImage, 0);
                Grid.SetRow(companyImage, 1);

                //hráči



                //cena
                priceText.LayoutTransform = rotateTransform;

                Grid.SetColumnSpan(priceText, 4);

                Grid.SetColumn(priceText, 0);
                Grid.SetRow(priceText, 0);
            }
            //else //pravá strana
            //{
            //    //jméno
            //    RotateTransform rotateTransform = new RotateTransform(-90);
            //    nameText.LayoutTransform = rotateTransform;

            //    Grid.SetRowSpan(nameText, 4);

            //    Grid.SetColumn(nameText, 0);
            //    Grid.SetRow(nameText, 0);

            //    //obrázek
            //    CompanyImage.LayoutTransform = rotateTransform;
            //    CompanyImage.HorizontalAlignment = HorizontalAlignment.Right;


            //    Grid.SetColumnSpan(CompanyImage, 2);
            //    Grid.SetRowSpan(CompanyImage, 4);

            //    Grid.SetColumn(CompanyImage, 1);
            //    Grid.SetRow(CompanyImage, 0);

            //    //hráči



            //    //cena
            //    priceText.LayoutTransform = rotateTransform;

            //    Grid.SetRowSpan(priceText, 4);

            //    Grid.SetColumn(priceText, 3);
            //    Grid.SetRow(priceText, 0);
            //}
            CompaniesGrid.Children.Add(nameText);
            CompaniesGrid.Children.Add(priceText);
            CompaniesGrid.Children.Add(companyImage);
        }

        //"pack://application:,,,/Images/Advance_To_Boardwalk.png",
        //    "pack://application:,,,/Images/Advance_To_Go.png",
        //    "pack://application:,,,/Images/Chance_ATIA.png",
        //    "pack://application:,,,/Images/Chance_ATSCP.png",
        //    "pack://application:,,,/Images/Chance_ATSCP.png",
        //    "pack://application:,,,/Images/Chance_ATTNU.png",
        //    "pack://application:,,,/Images/Chance_ATSCP.png",
        //    "pack://application:,,,/Images/Chance_GB3S.png",
        //    "pack://application:,,,/Images/Chance_GOOTJF.png",
        //    "pack://application:,,,/Images/Chance_GTJ.png",
        //    "pack://application:,,,/Images/Chance_MGR.png",
        //    "pack://application:,,,/Images/Chance_PPT.png",
        //    "pack://application:,,,/Images/Chance_TAROTR.png",
        //    "pack://application:,,,/Images/Chance_YHBAECOTB.png",
        //    "pack://application:,,,/Images/Chance_YBALM.png"
    }
}
