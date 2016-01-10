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
using BL;

namespace WorklistAssistant
{
    /// <summary>
    /// Interaction logic for UsernameAndPasswordWindow.xaml
    /// </summary>
    public partial class UsernameAndPasswordWindow : Window
    {
        public User UserLog { get; set; }
        public UsernameAndPasswordWindow(User user)
        {
            UserLog = user;
            InitializeComponent();
            txtUserName.Text = user.Login;
        }

        private void Button_Save_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (psbOldPassword.Password != UserLog.Password)
            {
                MessageBox.Show("Passwords wrong!");
            }
            else
            {
                if (psbNewPassword.Password == psbConfirmNewPassword.Password)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match!");
                }
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Cancel_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
