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

namespace Tushkanchik
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //AddUser DeleteUser при создании 2 юзера всплывает сообщение учитывать его в оьщей
        //статистики ил нет если да то создается аккаунт юзерфемели(фемели создается 1 раз)

        public MainWindow()
        {
            InitializeComponent();
            _users = GetUsersFromJSON();
            _incomeCategory = GetIncomeCategoriesFromJSON();
            FillUsersComboBox();
        }
        private const string _UsersPath = "./users.txt";
        private const string _IncomeCategoriesPath = "C:/Users/Asus/source/repos/Tushkanchik/json/Incomecategories.txt";
        
        public List<User> _users;
        public List<IncomeCategory> _incomeCategory;
       
        public string _userName;

       public List<IncomeCategory> GetIncomeCategoriesFromJSON()
        {
            StreamReader reader = new StreamReader(_IncomeCategoriesPath);
            // открыть поток для чтения 
            string json = reader.ReadToEnd();
            reader.Close();
            List<Transaction.Categories.IncomeCategory> incomeCategory = JsonSerializer.Deserialize<List<IncomeCategory>>(json);
            if (incomeCategory is null)
            {
                incomeCategory = new List<Transaction.Categories.IncomeCategory>();
                //если изначально пустой файл мы делвем чтоб он был равен не null а пустой список 
            }
            return incomeCategory;
        }
        public List<User> GetUsersFromJSON()
        {
            string json = File.ReadAllText(_UsersPath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(json);
            if (users is null)
            {
                users = new List<User>();
                //если изначально пустой файл мы делвем чтоб он был равен не null а пустой список 
            }
            return users;
        }
      
        public void FillUsersComboBox()
        {
            foreach (User user in _users)
            {
                ComboBoxUsersList.Items.Add(user.Name);
            }
        }
        //public void FillIncomeCategoriesComboBox()
        //{
        //    foreach (IncomeCategories incomeCategory in _incomeCategory)
        //    {
        //        usersList.Items.Add(incomeCategory.GetName());
        //    }
        //}

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //парсинг превращаем текст в список юзеров

            foreach (User user in _users)
            {
                ComboBoxUsersList.Items.Add(user.Name);
            }

        }

        private void ButtonCreateUser_Click(object sender, RoutedEventArgs e)
        {
            string name = holderName.Text;
            if (name.Length == 0)
            {
                holderName.ToolTip = "";
            }
            else
            {
                holderName.Background = Brushes.Transparent;
                User user = new User() { Name = name };
                if ( _users.Contains(user))
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
                else
                {

                    _users.Add(user);

                    string converted = JsonSerializer.Serialize(_users);
                    // парсинг в строку чтоб записать тест в файл 
                    //Trace.WriteLine(converted);
                    File.WriteAllText(_UsersPath, converted);
                    ComboBoxUsersList.Items.Add(user.Name);
                    TabItemMainTab.IsSelected = true;
                    _userName = holderName.Text;
                    nameOfUser.Content = _userName;
                    entertab.IsEnabled = false;
                }

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(ComboBoxUsersList.Text))
            {
                TabItemMainTab.IsSelected = true;
            }
            _userName = ComboBoxUsersList.Text;
            nameOfUser.Content = _userName;
            entertab.IsEnabled = false;
        }
    }
}

