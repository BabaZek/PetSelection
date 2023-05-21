using PetSelection;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using Path = System.IO.Path;

namespace PetSelection
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
            // Привязка событий к элементам управления окна
            ToolBar.MouseDown += (sender, e) => WindowHelper.Window_Moving(this, sender, e);
            MinButton.MouseDown += (sender, e) => WindowHelper.MinButton_MouseDown(this, sender, e);
            CloseButton.MouseDown += (sender, e) => WindowHelper.CloseButton_MouseDown(this, sender, e);
            LogoContainer.MouseDown += (sender, e) => WindowHelper.Window_Moving(this, sender, e);
        }

        // Кнопка авторизации
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            // Получите путь к файлу XML с пользователями
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "users.xml");

            // Загрузите данные пользователей из XML-файла
            UserList users;
            XmlSerializer serializer = new XmlSerializer(typeof(UserList));
            using (StreamReader reader = new StreamReader(filePath))
            {
                users = (UserList)serializer.Deserialize(reader);
            }

            // Получите введенные учетные данные из текстовых полей
            string emailOrPhone = MailTextBox.Text;
            string password = PasswordBox.Password;

            // Проверьте введенные учетные данные с данными из XML-файла
            User loggedInUser = users.userList.FirstOrDefault(u =>
                (u.Email == emailOrPhone || u.PhoneNumber == emailOrPhone) && u.Password == password);

            if (loggedInUser != null)
            {
                MessageBox.Show("Данные корректны");
                MainWindow window = new MainWindow(loggedInUser);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные не корректны");
            }
        }

        // Переход на окно регистрации
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow window = new SignUpWindow();
            window.Show();
            this.Close();
        }
    }
}
