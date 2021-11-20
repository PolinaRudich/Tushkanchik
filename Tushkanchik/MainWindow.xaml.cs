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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
//using Newtonsoft.Json;
using System.Diagnostics;
using Tushkanchik.Transaction;
using Tushkanchik.Transaction.Categories;
using System.Collections.ObjectModel;

namespace Tushkanchik
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //AddUser DeleteUser при создании 2 юзера всплывает сообщение учитывать его в оьщей
        //статистики ил нет если да то создается аккаунт юзерфемели(фемели создается 1 раз)

        private const string _IncomeCategoriesPath = "./Incomecategories.txt";
        private const string _UsersPath = "./users.txt";

        private ObservableCollection<User> _users;
        private ObservableCollection<IncomeCategory> _incomeCategories;

        public MainWindow()
        {
            InitializeComponent();
            _users = new ObservableCollection<User>(GetUsersFromJSON());
            ComboBoxUsersList.ItemsSource = _users;
          
            _incomeCategories = new ObservableCollection<IncomeCategory>(GetIncomeCategoriesFromJSON());
           
        }


        public List<IncomeCategory> GetIncomeCategoriesFromJSON()
        {
            if (!File.Exists(_IncomeCategoriesPath))
            {
                return new List<IncomeCategory>();
            }
            string json = File.ReadAllText(_IncomeCategoriesPath);
            List<IncomeCategory> categories = JsonSerializer.Deserialize<List<IncomeCategory>>(json);
            if (categories is null)
            {
                categories = new List<IncomeCategory>();
                //если изначально пустой файл мы делвем чтоб он был равен не null а пустой список 
            }
            return categories;
            //StreamReader reader = new StreamReader(_IncomeCategoriesPath);
            // открыть поток для чтения 
            //string json = reader.ReadToEnd();
            //reader.Close();
            //List<IncomeCategory> incomeCategory = JsonSerializer.Deserialize<List<IncomeCategory>>(json);
            //if (incomeCategory is null)
            //{
            //    incomeCategory = new List<IncomeCategory>();
            //    //если изначально пустой файл мы делвем чтоб он был равен не null а пустой список 
            //}
            //return incomeCategory;
        }
        public List<User> GetUsersFromJSON()
        {
            if (!File.Exists(_UsersPath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(_UsersPath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(json);
            if (users is null)
            {
                users = new List<User>();
                //если изначально пустой файл мы делвем чтоб он был равен не null а пустой список 
            }
            return users;
        }


        private void ButtonCreateUser_Click(object sender, RoutedEventArgs e)
        {
            string name = holderName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            holderName.Background = Brushes.Transparent;
            User user = new User() { Name = name };
            if (_users.Contains(user))
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }


            _users.Add(user);

            string converted = JsonSerializer.Serialize(_users);
            File.WriteAllText(_UsersPath, converted);
            _users.Add(user);

            TabItemMainTab.IsSelected = true;
            nameOfUser.Content = name;
            entertab.IsEnabled = false;
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxUsersList.SelectedItem == null)
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var name = ((User)ComboBoxUsersList.SelectedItem).Name;
            if (!string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            nameOfUser.Content = name;
            TabItemMainTab.IsSelected = true;
            entertab.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

