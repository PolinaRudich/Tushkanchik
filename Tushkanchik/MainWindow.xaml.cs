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
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Diagnostics;

namespace Tushkanchik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _UsersPath = "C:/Users/Asus/source/repos/Tushkanchik/json/users.txt";
        public List<User> _users;
        public MainWindow()
        {

            _users = GetUsersFromJSON();
            InitializeComponent();
            FillUsersComboBox();


        }
        public List<User> GetUsersFromJSON()
        {
            StreamReader reader = new StreamReader(_UsersPath);
            // открыть поток для чтения 
            string json = reader.ReadToEnd();
            reader.Close();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            if (users is null)
            {
                users = new List<User>();
                //если изначально пустой файл мы делвем чтоб он был равен не нул а пустой список 
            }
            return users;
        }
        public void FillUsersComboBox()
        {
            foreach (User user in _users)
            {
                usersList.Items.Add(user.GetName());
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //парсинг превращаем текст в список юзеров

            foreach (User user in _users)
            {
                usersList.Items.Add(user.GetName());
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = @holderName.Text;
            if (name.Length==0)
            {
                holderName.ToolTip = "";
            }
            else
            {
                holderName.Background = Brushes.Transparent;
                User user = new User(name);
                if (user.IsIn(_users))
                {
                    MessageBox.Show("Такой пользователь уже существует");
                }
                else
                {
                   
                   _users.Add(user);

                    //foreach (User u in users)
                    //{
                    //    Trace.WriteLine("Name: " + u.GetName());
                    //}
                    string converted = JsonConvert.SerializeObject(_users);
                    // парсинг в строку чтоб записать тест в файл 
                    //Trace.WriteLine(converted);
                    File.WriteAllText(_UsersPath, converted);
                    usersList.Items.Add(user._name);
                    MainPage mainPage = new MainPage();
                   this.Hide();
                    mainPage.Show();
                }
                
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MainPage mainPage = new MainPage();
            this.Hide();
            mainPage.Show();



        }
    }
}
