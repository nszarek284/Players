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
using System.IO;

namespace Players
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Player> list_players = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 33; i++)
            {
                ComboBox1.Items.Add(18 + i);
            }
            ComboBox1.Text = "18";
            Player player = new Player();


            if(File.Exists(@"player_data.txt"))
            {
                foreach(string s in File.ReadAllLines(@"player_data.txt"))
                {
                    list_players.Add(new Player(s));
                }
                ListBox.ItemsSource = list_players;
            }

            

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            slider.Value = Math.Round(slider.Value, 1);

        }

        private void Imie_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }

        private void Nazwisko_tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (Imie.Text.Length != 0 && Nazwisko.Text.Length != 0)
            {
                Player player = new Player();
                player.Imie = Imie.Text;
                player.Nazwisko = Nazwisko.Text;
                player.Wiek = Int32.Parse(ComboBox1.Text);
                player.Waga = Slider.Value;

                list_players.Add(player);
                ListBox.ItemsSource = list_players;
                ListBox.Items.Refresh();

                Imie.Text = "";
                Nazwisko.Text = "";
                ComboBox1.Text = "18";
                Slider.Value = 75;
            }
            else
            {
                MessageBox.Show("Pola imię oraz nazwisko są obowiązkowe", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Modyfikuj_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {

                Player player = (Player)list_players[ListBox.SelectedIndex];

                player.Imie = Imie.Text;
                player.Nazwisko = Nazwisko.Text;
                player.Wiek = Int32.Parse(ComboBox1.Text);
                player.Waga = Slider.Value;

                
                ListBox.ItemsSource = list_players;
                ListBox.Items.Refresh();
                if (Imie.Text.Length != 0 && Nazwisko.Text.Length != 0)
                {
                    list_players[ListBox.SelectedIndex] = player;
                    ListBox.ItemsSource = list_players;
                    ListBox.Items.Refresh();
                }
                else
                    MessageBox.Show("Pola imię oraz nazwisko są obowiązkowe","Ostrzeżenie", MessageBoxButton.OK,MessageBoxImage.Error);
            }


        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                Player player = (Player)ListBox.Items[ListBox.SelectedIndex];
                int index = ListBox.SelectedIndex;
                Imie.Text = player.Imie;
                Nazwisko.Text = player.Nazwisko;
                ComboBox1.Text = player.Wiek.ToString();
                Slider.Value = player.Waga;

            }
            
        }


        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            // ListBox.Items.Remove(ListBox.SelectedItem);

            if (ListBox.SelectedIndex != -1)
            {
                
                list_players.RemoveAt(ListBox.SelectedIndex);
                ListBox.Items.Refresh();
                ListBox.ItemsSource = list_players;

            }
        }

        private void Imie_GotFocus(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void Nazwisko_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Imie_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Imie.Text.Length == 0)
            {
                Imie.BorderThickness = new Thickness(5);
                Imie.BorderBrush = Brushes.Red;
            }
            else
            {
                Imie.BorderThickness = new Thickness(3);
                Imie.BorderBrush = Brushes.Gray;
            }
        }

        private void Nazwisko_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Nazwisko.Text.Length == 0)
            {
                Nazwisko.BorderThickness = new Thickness(5);
                Nazwisko.BorderBrush = Brushes.Red;
            }
            else
            {
                Nazwisko.BorderThickness = new Thickness(3);
                Nazwisko.BorderBrush = Brushes.Gray;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string s;
            using (StreamWriter writeFile = new StreamWriter(@"player_data.txt"))
            {
                foreach(Player player_l in list_players)
                {
                    s = player_l.ToString();
                    writeFile.WriteLine(player_l.ToString());

                }
            }
        }
    }    
}
