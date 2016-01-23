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
using NLog;

namespace WorklistAssistant
{
    public partial class SettingWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static string oldUserLogin;
        public User LogUser { get; set; }
        public IList<Worklist> WorkLists { get; set; }
        public SettingWindow(User logUser)
        {
            LogUser = logUser;
            WorkLists = FileManager.GetWorklistsForUser(LogUser);
            InitializeComponent();
            lblUserName.Content = logUser.Login;
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
            try
            {
                FileManager.AddWorklistInFile(LogUser.Login, "-", "-");
                lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
            }
            catch (Exception ex)
            {

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
            try
            {
                FrameworkElement frm = new FrameworkElement();
                var parentSender = ((FrameworkElement)sender).Parent;
                var userName = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
                var masterUserName = LogUser.Login;
                FileManager.DeleteWorklistFromFile(masterUserName, userName);
                lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
            }
            catch (Exception ex)
            {

                logger.Trace(ex + "\r\n");
            }

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
            }
            catch (Exception ex)
            {

                logger.Trace(ex + "\r\n");
            }

        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameworkElement frm = new FrameworkElement();
                var parentSender = ((FrameworkElement)sender).Parent;
                string loginUser = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
                string passUser = ((TextBox)((FrameworkElement)parentSender).FindName("txtPassword")).Text;
                UserManager.EditWorklist(LogUser.Login, oldUserLogin, loginUser, passUser);
                lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
            }
            catch (Exception ex)
            {

                logger.Trace(ex + "\r\n");
            }

        }

    }
}
