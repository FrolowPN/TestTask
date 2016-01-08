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
    public partial class NewUserWindow : Window
    {
        public NewUserWindow()
        {
            InitializeComponent();
        }

        private void button_save_click(object sender, RoutedEventArgs e)
        {
            if (txtNewUser.Text != "" || psbNewPassword.Password !="")
            {
                if (psbConfirmNewPassword.Password == psbNewPassword.Password)
            {
                if (!FileManager.AddUserInFile(txtNewUser.Text, psbNewPassword.Password))
                {
                    MessageBox.Show("Oops! =(");
                }
                else 
                { 
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            } 
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        

      
    }
}
