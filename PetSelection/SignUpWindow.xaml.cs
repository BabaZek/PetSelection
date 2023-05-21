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
using System.Windows.Shapes;
using System.Xml.Linq;
using System.IO;
using PetSelection;
using System.Xml.Serialization;
using Path = System.IO.Path;

namespace PetSelection
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            // Привязка событий к элементам управления
            ToolBar.MouseDown += (sender, e) => WindowHelper.Window_Moving(this, sender, e);
            MinButton.MouseDown += (sender, e) => WindowHelper.MinButton_MouseDown(this, sender, e);
            CloseButton.MouseDown += (sender, e) => WindowHelper.CloseButton_MouseDown(this, sender, e);
        }

        // Переход на окно авторизации
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow window = new LogInWindow();
            window.Show();
            this.Close();
        }

        // Регистрация нового пользователя
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SurnameTextBox.Text) || string.IsNullOrEmpty(NameTextBox.Text) || string.IsNullOrEmpty(MiddleNameTextBox.Text) || string.IsNullOrEmpty(YearOfBirthTextBox.Text) || string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(PhoneNumberTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Все поля должны быть заполнены");
                return;
            }

            UserList users;
            XmlSerializer serializer = new XmlSerializer(typeof(UserList));

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "users.xml");

            // Загрузить существующих пользователей, если файл существует
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    users = (UserList)serializer.Deserialize(reader);
                }
            }
            else
            {
                users = new UserList();
            }

            // Проверить, зарегистрирован ли уже адрес электронной почты или номер телефона
            if (users.userList.Any(user => user.Email == EmailTextBox.Text || user.PhoneNumber == PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Пользователь с таким адресом электронной почты или номером телефона уже существует");
                return;
            }

            User newUser;

            if (AsAnAdmin.IsChecked == true)
            {
                newUser = new Admin(SurnameTextBox.Text, NameTextBox.Text, MiddleNameTextBox.Text, YearOfBirthTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, PasswordBox.Password);
            }
            else
            {
                newUser = new User(SurnameTextBox.Text, NameTextBox.Text, MiddleNameTextBox.Text, YearOfBirthTextBox.Text, EmailTextBox.Text, PhoneNumberTextBox.Text, PasswordBox.Password);
            }

            users.userList.Add(newUser);


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, users);
            }

            MessageBox.Show("Аккаунт успешно зарегистрирован");

            LogInWindow window = new LogInWindow();
            window.Show();
            this.Close();
        }
    }
}
