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

namespace PetSelection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User User { get; set; }

        public UserControl CurrentView { get; set; }

        public MainWindow(User user)
        {
            this.User = user;
            InitializeComponent();

            if (User.AccessLevel == "admin")
            {
                CurrentView = new AdminView(); // Предполагается, что у вас есть UserControl под названием AdminView
            }
            if (User.AccessLevel == "user")
            {
                CurrentView = new UserView();
            }

            this.DataContext = this; // Установка DataContext для MainWindow в этот экземпляр класса MainWindow
        }
    }
}
