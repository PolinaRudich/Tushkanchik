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

        public ObservableCollection<CardForView> _cardsForView;
        public ObservableCollection<User> _users;
        public ObservableCollection<Card> _cards;
        private User User { get; set; }
        // private ObservableCollection<IncomeCategory> _incomeCategories;
        private Storage _storage;
        private decimal percentOfCashBack;
        private readonly User holder;

        public MainWindow()
        {
            InitializeComponent();
            _storage = Storage.GetInstance();


            List<User> usersList = Storage.GetInstance().Users;
            _users = new ObservableCollection<User>(usersList);
            List<Card> cardsList = Storage.GetInstance().Cards;
            _cards = new ObservableCollection<Card>(cardsList);
            FillViewData();
        }

        private void FillViewData()
        {

            ComboBoxUsersList.ItemsSource = _users;




        }
        public void UpDateCardsView(User user)
        {

            _cardsForView = _storage.GetCardsForViewByUser(user);
            ComboBoxMoney.ItemsSource = _cardsForView;
        }
        public ObservableCollection<CardForView> GetCardsForViewByUser(User user)
        {
            ObservableCollection<CardForView> cards = new ObservableCollection<CardForView>();


            foreach (Card card in _storage.Cards)
            {
                if (card.Holder.Name == user.Name)
                {
                    CardForView cardForView = new CardForView() { Card = card, NamePlusBalance = card.Name + " " + card.Balance };
                    cards.Add(cardForView);
                }
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
            User user = new User(name); //{ Name = name };
            if (_users.Contains(user))
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            _users.Add(user);

            string converted = JsonSerializer.Serialize(_users);
            File.WriteAllText(_storage.UsersPath, converted);
            UpDateCardsView(user);
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
            UpDateCardsView(User);
            nameOfUser.Content = User.Name;
            TabItemMainTab.IsSelected = true;
            entertab.IsEnabled = false;

        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {


            //ComboBoxWallet.ItemsSource = _storage.GetCardsByUser(User);
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
            bool isNumber = decimal.TryParse(Cardbalance.Text.Trim(), out balance);
            if (!isNumber)
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //TODO разобраться с листами юзеров и тд
            //List<User> cardUsers = new List<User>();
           // cardUsers.Add(User);

            Card card = new Card( User, balance, name,percentOfCashBack);
            _cardsForView.Add(new CardForView() { NamePlusBalance = name + " " + balance, Card = card });

            foreach (var cardForView in _cardsForView)
            {
                _storage.Cards.Add(cardForView.Card);
            }

            string converted = JsonSerializer.Serialize(_storage.Cards);
            File.WriteAllText(_storage.CardsPath, converted);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void ComboBoxMoney_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

 

    



