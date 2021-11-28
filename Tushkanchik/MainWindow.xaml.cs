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
using Tushkanchik.Transactions;
using Tushkanchik.Transactions.Categories;

namespace Tushkanchik
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //AddUser DeleteUser при создании 2 юзера всплывает сообщение учитывать его в оьщей
        //статистики ил нет если да то создается аккаунт юзерфемели(фемели создается 1 раз)
       
        private const string IncomeCategoriesPath = "./Incomecategories.txt";
        private const string ExpenseCategoriesPath = "./Expensecategories.txt";
        public string UsersPath = Directory.GetCurrentDirectory() + "\\json\\users.txt";
        public string CardsPath = Directory.GetCurrentDirectory() + "\\json\\cards.txt";
        private ObservableCollection<CardForView> _cardsForView;
        private ObservableCollection<User> _users;
        private User User { get; set; }
        public decimal PercentOfCashBack { get; private set; }

        private ObservableCollection<IncomeCategory> _incomeCategories;

        private ObservableCollection<ExpenseCategorylogic> _expenseCategories;
        private Storage _storage;
       

        public MainWindow()
        {
            InitializeComponent();
            _storage = Storage.GetInstance();

            FillViewData();
        }

        private void FillViewData()
        {
            _users = new ObservableCollection<User>(GetUsersFromJSON());
            ComboBoxUsersList.ItemsSource = _users;

            _cardsForView = new ObservableCollection<CardForView>();
            ComboBoxMoney.ItemsSource = _cardsForView;

            var cards = GetCardsFromJSON();
            foreach (var card in cards)
            {
                var cardForView = new CardForView() { Card = card, NamePlusBalance = card.Name + " " + card.Balance };
                _cardsForView.Add(cardForView);
            }
            _incomeCategories = new ObservableCollection<IncomeCategory>(GetIncomeCategoriesFromJSON());
        }


        public List<IncomeCategory> GetIncomeCategoriesFromJSON()
        {
            if (!File.Exists(IncomeCategoriesPath))
            {
                return new List<IncomeCategory>();
            }
            string json = File.ReadAllText(IncomeCategoriesPath);
            List<IncomeCategory> categories = JsonSerializer.Deserialize<List<IncomeCategory>>(json);
            if (categories is null)
            {
                categories = new List<IncomeCategory>();
                
            }
            return categories;
           
        }
        public List<User> GetUsersFromJSON()
        {
            if (!File.Exists(UsersPath))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(UsersPath));
                    
                FileStream fs = File.Create(UsersPath);
                fs.Close();
                return new List<User>();
            }
            List<User> users = new List<User>();
            string json = File.ReadAllText(UsersPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                users = new List<User>();
            }
            else if (users is null)
            {
                users = new List<User>();
            } else
            {
                users = JsonSerializer.Deserialize<List<User>>(json);
            }
            return users;
        }
        public List<Card> GetCardsFromJSON()
        {
            if (!File.Exists(CardsPath))
            {
                FileStream fs = File.Create(CardsPath);
                fs.Close();
                return new List<Card>();
            }
            List<Card> cards = new List<Card>();
            string json = File.ReadAllText(CardsPath);
            if (string.IsNullOrWhiteSpace(json))
            {
                cards = new List<Card>();
            }
            else
            {
                cards = JsonSerializer.Deserialize<List<Card>>(json);
            }
            return cards;
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
            User user = new User(name) { Name = name };
            if (_users.Contains(user))
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }


            _users.Add(user);

            string converted = JsonSerializer.Serialize(_users);
            File.WriteAllText(UsersPath, converted);

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
            User = (User)ComboBoxUsersList.SelectedItem;
            if (string.IsNullOrWhiteSpace(User.Name))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            nameOfUser.Content = User.Name;
            TabItemMainTab.IsSelected = true;
            entertab.IsEnabled = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string type = categoryBox.Text;
            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //holderName.Background = Brushes.Transparent;
            ExpenseCategorylogic expenseLogic = new ExpenseCategorylogic();
            if (_expenseCategories.Contains(expenseLogic))
            {
                expenseLogic.Create(type);
                MessageBox.Show("Такая категория уже существует");
                return;
            }
            _expenseCategories.Add(expenseLogic);

            string converted = JsonSerializer.Serialize(_expenseCategories);
            File.WriteAllText(ExpenseCategoriesPath, converted);

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAddNewCard_Click(object sender, RoutedEventArgs e)
        {
            string name = cardName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string cardBalance = Cardbalance.Text.Trim();
            if (string.IsNullOrWhiteSpace(cardBalance))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //TODO вынести в отдельный метод
            decimal balance;
            bool isNumber = decimal.TryParse(Cardbalance.Text.Trim(),  out balance);
            if (!isNumber)
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //TODO разобраться с листами юзеров и тд
            List<User> cardUsers = new List<User>();
            cardUsers.Add(User);

            Card card = new Card( User,  balance,  name, PercentOfCashBack) ;
            _cardsForView.Add(new CardForView() { NamePlusBalance = name + " " + balance, Card = card });

            List<Card> cards = new List<Card>();
            foreach(var cardForView in _cardsForView)
            {
                cards.Add(cardForView.Card);
            }

            string converted = JsonSerializer.Serialize(cards);
            File.WriteAllText(CardsPath, converted);

        }
    }
}

