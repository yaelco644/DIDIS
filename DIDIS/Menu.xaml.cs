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

namespace DIDIS
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();

            List<string> subjects = new List<string>();
            subjects.Add("קינוחים");
            subjects.Add("סלטים");
            subjects.Add("עיקריות");
            subjects.Add("הכל");



            foreach (var item in subjects)
            {
                Button btn = new Button()
                {
                    Content = item,
                    FontSize = 10,                  // פונט קטן יותר
                    Background = new SolidColorBrush(Colors.LightGray),
                    Margin = new Thickness(10), // רווח בין הכפתורים      
                };

                btn.Click += ClickedSubject; // ← מוסיפים את האירוע

                mainGrid.Children.Add(btn);

            }

            // הוספה של אוכל לדוגמה
            AddFoodCard("מוקפץ", "29 ₪", "Img/mokpazt.jpeg");
            AddFoodCard("ממולאים", "59 ₪", "Img/mamulaim.jpeg");
            AddFoodCard("סלט ירוק", "50 ₪", "Img/salat.jpeg");
        }

        private void AddFoodCard(string foodName, string price, string imagePath)
        {
            // מסגרת לכרטיס של האוכל
            Border card = new Border()
            {
                Width = 180,
                Height = 230,
                CornerRadius = new CornerRadius(20),
                Background = (Brush)new BrushConverter().ConvertFromString("#FFF8E9"),
                Margin = new Thickness(10),
                Padding = new Thickness(10)
            };

            StackPanel container = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center };

            // לכל אוכל אני פותחת גריד שם יהיה את כל התוכן
            Grid imageArea = new Grid();

            // תכונות לתמונה
            Border imgBorder = new Border()
            {
                Width = 150,
                Height = 150,
                CornerRadius = new CornerRadius(20),
                ClipToBounds = true
            };

            Image img = new Image()
            {
                Stretch = Stretch.Fill,
                Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute))
            };

            imgBorder.Child = img;
            imageArea.Children.Add(imgBorder);  // משייכת את התמונה לגריד

            Button addPlusBtn = new Button()
            {
                Content = "+",
                Width = 28,
                Height = 28,
                FontSize = 16,
                Background = Brushes.White,
                BorderBrush = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5)
            };

            imageArea.Children.Add(addPlusBtn);   // משייכת את ה+ לגריד

            TextBlock FoodName = new TextBlock()
            {
                Text = foodName,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 0),
                FontFamily = new FontFamily("Verdana"),

                HorizontalAlignment = HorizontalAlignment.Center
            };

            TextBlock priceTxt = new TextBlock()
            {
                Text = price,
                Foreground = new SolidColorBrush(Color.FromRgb(34, 174, 76)),
                FontSize = 14,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            container.Children.Add(imageArea);
            container.Children.Add(FoodName);
            container.Children.Add(priceTxt);

            card.Child = container;
            FoodPanel.Children.Add(card);
        }

        private void ClickedSubject(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string subject = clickedButton.Content.ToString();
            //if (subject == "Dresses") subjectFrame.Navigate(new Page1());
            //else if (subject == "Pants") subjectFrame.Navigate(new Page2());
            //else if (subject == "Shoes") subjectFrame.Navigate(new Page1());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var Items = Page.Items;
            //if (Items.Count != 0)
            //{
            //    Window1 window1 = new Window1();
            //    window1.Show();
            //}
            //else
            //{

            //}
        }
    }
}
