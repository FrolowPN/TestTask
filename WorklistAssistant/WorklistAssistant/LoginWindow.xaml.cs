using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;
using System.Diagnostics;


namespace WorklistAssistant
{

    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

      
        public MainWindow()
        {
                InitializeComponent();
            cmbUser.ItemsSource = ClientFileHelper.GetAllLogins();
            //this.Topmost = true;
         
        }

        private async void Button_Login_Click(object sender, ExecutedRoutedEventArgs e)
        {
            var client = new WAService.WAServiceClient("NetTcpBinding_IWAService");
            client.ClientCredentials.UserName.UserName = Helpers.GetUserLogAndPass.Login;
            client.ClientCredentials.UserName.Password = Helpers.GetUserLogAndPass.Password;
            var c = cmbUser.SelectedValue;
            try
            {
                if (await client.VerifyingPasswordAsync(((Login)cmbUser.SelectedValue).MasterUserLogin, psbPassword.Password))
                {
                    WorklistAssistantWindow form = new WorklistAssistantWindow(((Login)cmbUser.SelectedValue).MasterUserLogin);
                    form.Show();
                    client.Close();
                    this.Close();
                }
                else
                {
                    client.Close();
                    psbPassword.Password = null;
                    MessageBox.Show("Password Wrong!");
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                if (client.State != System.ServiceModel.CommunicationState.Faulted)
                {
                    client.Close();
                }
                else
                {
                    MessageBox.Show("Login or Password for Server Wrong! Programm will close!");
                    this.Close();
                }
            }
        }


        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbUser_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            if (cmbUser.SelectedIndex == cmbUser.Items.Count - 1)
            {
                cmbUser.SelectedIndex = -1;
                NewUserWindow form = new NewUserWindow();
                form.Show();
            }
            else
            {
                return;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            cmbUser.ItemsSource = ClientFileHelper.GetAllLogins();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var client = new WAService.WAServiceClient("NetTcpBinding_IWAService");
            client.ClientCredentials.UserName.UserName = Helpers.GetUserLogAndPass.Login;
            client.ClientCredentials.UserName.Password = Helpers.GetUserLogAndPass.Password;
            FrameworkElement frm = new FrameworkElement();
            var parentSender = ((FrameworkElement)sender).Parent;
            var textWithTxtBlock = ((TextBlock)((FrameworkElement)parentSender).FindName("txtBlockLogin")).Text;

            if (await client.DeleteUserFromFileAsync(textWithTxtBlock))
            {
                ClientFileHelper.RemoveUser(textWithTxtBlock);
                //client.DeleteAllWorklistForUser(textWithTxtBlock);
            }
            client.Close();
            Refresh();
        }
    }
}
