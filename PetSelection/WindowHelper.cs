using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace PetSelection
{
    public static class WindowHelper
    {
        public static void CloseButton_MouseDown(Window window, object sender, MouseButtonEventArgs e)
        {
            window.Close();
        }

        public static void MinButton_MouseDown(Window window, object sender, MouseButtonEventArgs e)
        {
            window.WindowState = WindowState.Minimized;
        }

        public static void Window_Moving(Window window, object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                window.DragMove();
            }
        }
    }
}
