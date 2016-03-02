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
using System.Windows.Shapes;

namespace WorklistAssistant
{
    public partial class NewUserWindow : Window
    {

        public NewUserWindow()
        {
            InitializeComponent();
        }

        private async void button_save_click(object sender, ExecutedRoutedEventArgs e)
        {
            var client = new WAService.WAServiceClient("BasicHttpBinding_IWAService");
            if (txtNewUser.Text != "" && psbNewPassword.Password != "")
            {
                if (psbConfirmNewPassword.Password == psbNewPassword.Password)
                {
                    if (await client.AddUserInFileAsync(txtNewUser.Text, psbNewPassword.Password))
                    {
                        ClientFileHelper.AddUser(txtNewUser.Text);
                        client.Close();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Oops! =(");
                        client.Close();
                       
                    }
                }
                else
                {
                    client.Close();
                    MessageBox.Show("Passwords do not match");
                }
            }

        }

        private void Button_Close_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ApplicationCommands.Close.Execute(null, this);
        }




    }
}
