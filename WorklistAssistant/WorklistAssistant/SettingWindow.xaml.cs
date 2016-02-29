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
using NLog;
using WorklistAssistant.WAService;
using WorklistAssistant.Helpers;

namespace WorklistAssistant
{
    public partial class SettingWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string oldUserLogin;
        public string LogUser { get; set; }
        public IList<Worklist> WorkLists { get; set; }
        public SettingWindow(string logUser)
        {
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            LogUser = logUser;
            WorkLists = WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LogUser));
            InitializeComponent();
            lblUserName.Content = logUser;
            lbxSetting.ItemsSource = WorkLists;

        }

        private void Button_Edit_Click(object sender, ExecutedRoutedEventArgs e)
        {
            UsernameAndPasswordWindow form = new UsernameAndPasswordWindow(LogUser);

            this.Close();
            form.Show();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            WorklistAssistantWindow form = new WorklistAssistantWindow(LogUser);
            form.Show();
            this.Close();
        }
        private void Mouse_Add_Click(object sender, ExecutedRoutedEventArgs e)
        {
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            try
            {
              client.AddWorklistInFile(LogUser, "-", "-");
                lbxSetting.ItemsSource = WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LogUser));
                client.Close();
            }
            catch (Exception ex)
            {
                client.Close();
                logger.Trace(ex + "\r\n");
            }

        }

        private void Button_EditWorklist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameworkElement frm = new FrameworkElement();
                var parentSender = ((FrameworkElement)sender).Parent;
                oldUserLogin = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
                ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).IsEnabled = true;
                ((TextBox)((FrameworkElement)parentSender).FindName("txtPassword")).IsEnabled = true;
                ((StackPanel)((FrameworkElement)parentSender).FindName("stpOkCancel")).Visibility = Visibility.Visible;
                ((StackPanel)((FrameworkElement)parentSender).FindName("stpEditDelete")).Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
            }

        }

        private void Button_DeleteWorklist_Click(object sender, RoutedEventArgs e)
        {
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            try
            {
                FrameworkElement frm = new FrameworkElement();
                var parentSender = ((FrameworkElement)sender).Parent;
                var userName = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
                var masterUserName = LogUser;
                client.DeleteWorklistFromFile(masterUserName, userName);
                lbxSetting.ItemsSource = WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LogUser));
                client.Close();
            }
            catch (Exception ex)
            {
                client.Close();
                logger.Trace(ex + "\r\n");
            }

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            try
            {
                lbxSetting.ItemsSource = WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LogUser));
                client.Close();
            }
            catch (Exception ex)
            {
                client.Close();
                logger.Trace(ex + "\r\n");
            }

        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            try
            {
                FrameworkElement frm = new FrameworkElement();
                var parentSender = ((FrameworkElement)sender).Parent;
                string loginUser = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
                string passUser = ((TextBox)((FrameworkElement)parentSender).FindName("txtPassword")).Text;
                client.EditWorklist(LogUser, oldUserLogin, loginUser, passUser);
                lbxSetting.ItemsSource = WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LogUser));
                client.Close();
            }
            catch (Exception ex)
            {
                client.Close();
                logger.Trace(ex + "\r\n");
            }

        }

    }
}
