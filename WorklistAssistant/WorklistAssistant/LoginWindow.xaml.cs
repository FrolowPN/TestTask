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
using System.IO;

namespace WorklistAssistant
{

    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent();
            cmbUser.ItemsSource = UserManager.ConvertToBind(UserManager.GetListLogin());
        }


        private void Button_Login_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (UserManager.VerifyingPassword(((UsersListView)cmbUser.SelectedValue).Text, psbPassword.Password))
            {

                WorklistAssistantWindow form = new WorklistAssistantWindow(UserManager.GetUserOnLogin(((UsersListView)cmbUser.SelectedValue).Text));
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
            cmbUser.ItemsSource = UserManager.ConvertToBind(UserManager.GetListLogin());
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement frm = new FrameworkElement();
            var parentSender = ((FrameworkElement)sender).Parent;
            var textWithTxtBlock = ((TextBlock)((FrameworkElement)parentSender).FindName("txtBlockLogin")).Text;
            FileManager.DeleteUserFromFile(textWithTxtBlock);
             Refresh();
        }
















    }
}
