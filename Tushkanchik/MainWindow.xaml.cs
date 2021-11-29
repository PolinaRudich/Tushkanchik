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
using System.Text.Encodings.Web;
using System.Text.Unicode;

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
        public ObservableCollection<IncomeForView> _incomesForView;
        public ObservableCollection<User> _users;
        public ObservableCollection<Income> _income;
        public ObservableCollection<Card> _cards;
        private ObservableCollection<IncomeCategory> _incomeCategories;
        private ObservableCollection<ExpenseCategory> _expenseCategories;


        private User User { get; set; }
        private Card Card { get; set; }
        // private ObservableCollection<IncomeCategory> _incomeCategories;
        private Storage _storage;
        private decimal percentOfCashBack;
        private IncomeCategory incomeCategory;
        private readonly User holder;

        public MainWindow()
         {
            InitializeComponent();
            _storage = Storage.GetInstance();
            
            List<Income> incomes = Storage.GetInstance().Income;
            _income = new ObservableCollection<Income>(incomes);
            List<User> usersList = Storage.GetInstance().Users;
            _users = new ObservableCollection<User>(usersList);
            List<Card> cardsList = Storage.GetInstance().Cards;
            _cards = new ObservableCollection<Card>(cardsList);
            _incomeCategories = new ObservableCollection<IncomeCategory>(_storage.IncomeCategoryFromJSON());
            ComboBoxIncomeCategories.ItemsSource = _incomeCategories;

            _expenseCategories = new ObservableCollection<ExpenseCategory>(_storage.ExpenseCategoryFromJSON());
            ComboBoxExpenseCategories.ItemsSource = _expenseCategories;
            FillViewData();
        }

        private void FillViewData()
        {

            ComboBoxUsersList.ItemsSource = _users;
            IncomeOnceInfo.ItemsSource = _incomesForView;
        }
        public void UpDateCardsView(User user)
        {

            _cardsForView = _storage.GetCardsForViewByUser(user);
            ComboBoxMoney.ItemsSource = _cardsForView;
            ComboBoxWallet.ItemsSource = _cardsForView;

        }
        public void UpdateIncomesView(Card card)
        {

           
            _incomesForView = _storage.GetIncomeForViewByCard(card);
            IncomeOnceInfo.ItemsSource = _incomesForView;
        }
        public ObservableCollection<IncomeForView> GetIncomeForViewByCard(Card card)
        {
            ObservableCollection<IncomeForView> incomes = new ObservableCollection<IncomeForView>();


            foreach (Income income in _storage.Income)
            {
                if (income.Card.Name == card.Name)
                {
                    IncomeForView incomeForView = new IncomeForView() { cardName = card.Name, amount = income.Amount, Card = Card, income = income,date=income.Date,comment=income.Comment,incomeCategoryName=income.IncomeCategory.Name};
                    incomes.Add(incomeForView);
                }
            }
            return incomes;
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
            User = new User(name); //{ Name = name };
            if (_users.Contains(User))
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            _users.Add(User);

            string converted = JsonSerializer.Serialize(_users);
            File.WriteAllText(_storage.UsersPath, converted);
            UpDateCardsView(User);
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


            
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
            decimal balance;
            if (Card != null)
            {
                balance = Card.Balance;
            }
            else
            {
                bool isNumber = decimal.TryParse(Cardbalance.Text.Trim(), out balance);
                if (!isNumber)
                {
                    return;
                }   
            }
            string name = cardName.Text.Trim();
            Card = new Card(User, balance, name, percentOfCashBack);
            UpdateIncomesView(Card);
            if (Income.IsSelected)
            {
                GetCardsForViewByUser(User);
                UpdateIncomesView(Card);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click_Add_Income_Category(object sender, RoutedEventArgs e)
        {
            UpdateIncomesView(Card);
            if (ComboBoxIncomeCategories.SelectedItem is null)
            {
                string name = incomeCategoryName.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                incomeCategoryName.Background = Brushes.Transparent;
                IncomeCategory category = new IncomeCategory() { Name = name };
                if (_incomeCategories.Contains(category))
                {
                    MessageBox.Show("Данная категория уже существует.");
                    return;
                }

                _incomeCategories.Add(category);

                string converted = JsonSerializer.Serialize(_incomeCategories);
                File.WriteAllText(_storage.IncomeCategoryPath, converted);
                _incomeCategories.Add(category);
            }
            else
            {
                if (ComboBoxWallet.SelectedItem == null)
                {
                    MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string summary = Summary.Text.Trim();
                string DateOfIncome = dateOfIncome.Text.Trim();
                DateTime parsedDateOfIncome = DateTime.Parse(DateOfIncome);
                string comment = Comment.Text.Trim();
                decimal amount;
                IncomeCategory category = (IncomeCategory)ComboBoxIncomeCategories.SelectedItem;
                Card = ((CardForView)ComboBoxWallet.SelectedItem).Card;
                if (string.IsNullOrWhiteSpace(Card.Name))
                {
                    MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                bool isNumber = decimal.TryParse(Summary.Text.Trim(), out amount);
                if (!isNumber)
                {
                    MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(summary))
                {
                    MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Income income = new Income(amount, parsedDateOfIncome, Card, comment, category); //{ Name = name }; 

                _income.Add(income);
                Card card = new Card(User, Card.Balance, Card.Name, percentOfCashBack);
                _incomesForView.Add(new IncomeForView() { cardName = card.Name, amount = income.Amount, Card = card, income = income, date = income.Date, comment = income.Comment, incomeCategoryName = income.IncomeCategory.Name });

                foreach (var incomeForView in _incomesForView)
                {
                    _storage.Income.Add(incomeForView.income);
                }

                string converted = JsonSerializer.Serialize(_income);
                File.WriteAllText(_storage.IncomePath, converted);
                UpdateIncomesView(Card);
            }



        }

        private void Button_Click_ExitToLoginPage(object sender, RoutedEventArgs e)
        {
            entertab.IsSelected = true;
            entertab.IsEnabled = true;
        }
        private void Button_Click_Add_Expense_Category(object sender, RoutedEventArgs e)
        {
            string name = expenseCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            expenseCategoryName.Background = Brushes.Transparent;
            ExpenseCategory category = new ExpenseCategory() { Name = name };
            if (_expenseCategories.Contains(category))
            {
                MessageBox.Show("Данная категория уже существует.");
                return;
            }

            _expenseCategories.Add(category);

            string converted = JsonSerializer.Serialize(_expenseCategories);
            File.WriteAllText(_storage.ExpenseCategoryPath, converted);
            _expenseCategories.Add(category);
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
        private void ComboBoxWallet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CardForView card = (CardForView)ComboBoxWallet.SelectedItem;
            Card = card.Card;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
           
            if (ComboBoxWallet.SelectedItem == null)
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string summary = Summary.Text.Trim();
            string DateOfIncome = dateOfIncome.Text.Trim();
            DateTime parsedDateOfIncome = DateTime.Parse(DateOfIncome);
            string comment = Comment.Text.Trim();
            decimal amount;
            IncomeCategory incomeCategory = new IncomeCategory() { Name = "Шлюхи" };
            Card = ((CardForView)ComboBoxWallet.SelectedItem).Card;
            if (string.IsNullOrWhiteSpace(Card.Name))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool isNumber = decimal.TryParse(Summary.Text.Trim(), out amount);
            if (!isNumber)
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(summary))
            {
                MessageBox.Show("Вы не можете!", "Мочь или не мочь", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Income income = new Income( amount, parsedDateOfIncome,  Card,  comment,  incomeCategory); //{ Name = name };
           
            _income.Add(income);
            Card card = new Card(User, Card.Balance, Card.Name, percentOfCashBack);
            _incomesForView.Add(new IncomeForView() { cardName = card.Name, amount = income.Amount, Card = card, income = income, date = income.Date, comment = income.Comment, incomeCategoryName = income.IncomeCategory.Name });

            foreach (var incomeForView in _incomesForView)
            {
                _storage.Income.Add(incomeForView.income);
            }

            string converted = JsonSerializer.Serialize(_income);
            File.WriteAllText(_storage.IncomePath, converted);
            UpdateIncomesView(Card);
        }

        private void ComboBoxMoney_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Card = ((CardForView)ComboBoxMoney.SelectedItem).Card;
        }
    }
}







