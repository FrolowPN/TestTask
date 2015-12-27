using BL;
using NLog;
using System;
using System.Collections.Generic;
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

namespace WorklistAssistant
{
    
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent(); 
        }
       


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserManager.VerifyingPassword(cmbUser.Text, psbPassword.Password))
            {

                WorklistAssistantWindow form = new WorklistAssistantWindow(UserManager.GetUserOnLogin(cmbUser.Text));
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password Wrong");
            }
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbUser_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            if (cmbUser.Text == "Add new User")
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
            try
            {
List<string> users = UserManager.GetListLogin();
            cmbUser.ItemsSource = users;
            }
            catch (Exception ex)
            {

                logger.Trace(ex+"\r\n");
            }
            
        }

     

      
        

       


       

       

       

       
    }
}
