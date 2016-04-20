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
using WorklistAssistant.WAService;

namespace WorklistAssistant
{
    /// <summary>
    /// Interaction logic for UsernameAndPasswordWindow.xaml
    /// </summary>
    public partial class UsernameAndPasswordWindow : Window
    {
        public string UserLog { get; set; }
        public UsernameAndPasswordWindow(string user)
        {
            UserLog = user;
            InitializeComponent();
            txtUserName.Text = UserLog;
        }

        private async void Button_Save_Click(object sender, ExecutedRoutedEventArgs e)
        {
            var client = new WAService.WAServiceClient("NetTcpBinding_IWAService");
            client.ClientCredentials.UserName.UserName = Helpers.GetUserLogAndPass.Login;
            client.ClientCredentials.UserName.Password = Helpers.GetUserLogAndPass.Password;
            if (await client.VerifyingPasswordAsync(UserLog, psbOldPassword.Password))
            {
                if (psbNewPassword.Password == psbConfirmNewPassword.Password)
                {
                    if (await client.EditUserAsync(UserLog, txtUserName.Text, psbConfirmNewPassword.Password))
                    {
                        ClientFileHelper.UpdateUser(UserLog, txtUserName.Text);
                        // client.ChangeMasterUserForWorklists(UserLog, txtUserName.Text);
                    }
                    SettingWindow form = new SettingWindow(txtUserName.Text);
                    form.Show();
                    client.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match!");
                }
            }
            else
            {
                client.Close();
                MessageBox.Show("Passwords wrong!");
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
            SettingWindow form = new SettingWindow(UserLog);
            form.Show();
            this.Close(); 
        }

        private void Label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Cancel_Click(object sender, ExecutedRoutedEventArgs e)
        {
            SettingWindow form = new SettingWindow(UserLog);
            form.Show();
            this.Close();
        }


    }
}
