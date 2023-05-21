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
            InitializeComponent();
            // Привязка событий к элементам управления окна
            ToolBar.MouseDown += (sender, e) => WindowHelper.Window_Moving(this, sender, e);
            MinButton.MouseDown += (sender, e) => WindowHelper.MinButton_MouseDown(this, sender, e);
            CloseButton.MouseDown += (sender, e) => WindowHelper.CloseButton_MouseDown(this, sender, e);

            this.User = user;

            if (User is Admin)
            {
                CurrentView = new AdminView(); // Предполагается, что у вас есть UserControl под названием AdminView
            }
            else if (User is User)
            {
                CurrentView = new UserView();
            }
            else
            {
                throw new ArgumentException("Invalid user type.");
            }

            this.DataContext = this; // Установка DataContext для MainWindow в этот экземпляр класса MainWindow
        }
    }
}
