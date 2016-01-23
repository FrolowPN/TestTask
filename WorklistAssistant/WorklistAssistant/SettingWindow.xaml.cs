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

        private void Button_Delete_Click(object sender, ExecutedRoutedEventArgs e)
        {
            //try
            //{
            //    var index = dtGridWorklists.SelectedIndex;
            //    WorkLists.RemoveRange(index, 1);
            //    dtGridWorklists.ItemsSource = UserManager.ConvertToSettingView(WorkLists);
            //}
            //catch (ArgumentOutOfRangeException arg)
            //{
            //    logger.Trace(arg + " Не выбрана строка для удаления\r\n");
            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex);
            //}

        }

        private void Button_EditRow_Click(object sender, ExecutedRoutedEventArgs e)
        {
            //try
            //{
            //    var index = dtGridWorklists.SelectedIndex;
            //    var tempUser = new User(WorkLists[index].Login, WorkLists[index].Password);
            //    UsernameAndPasswordWindow form = new UsernameAndPasswordWindow(tempUser);
            //    form.ShowDialog();
            //}

            //catch (ArgumentOutOfRangeException arg)
            //{
            //    logger.Trace(arg + " Не выбрана строка для редактирования\r\n");
            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex);
            //}

        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Mouse_Add_Click(object sender, ExecutedRoutedEventArgs e)
        {
            FileManager.AddWorklistInFile(LogUser.Login, " ", " ");
            lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
        }

        private void Button_EditWorklist_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement frm = new FrameworkElement();
            var parentSender = ((FrameworkElement)sender).Parent;
            oldUserLogin = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
            ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).IsEnabled = true;
            ((TextBox)((FrameworkElement)parentSender).FindName("txtPassword")).IsEnabled = true;
            ((StackPanel)((FrameworkElement)parentSender).FindName("stpOkCancel")).Visibility = Visibility.Visible;
            ((StackPanel)((FrameworkElement)parentSender).FindName("stpEditDelete")).Visibility = Visibility.Hidden;
           
        }

        private void Button_DeleteWorklist_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement frm = new FrameworkElement();
            var parentSender = ((FrameworkElement)sender).Parent;
            var userName = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
            var masterUserName = LogUser.Login;
            FileManager.DeleteWorklistFromFile(masterUserName, userName);
            lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {     
            lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
        }

        private void Button_Ok_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement frm = new FrameworkElement();
            var parentSender = ((FrameworkElement)sender).Parent;
            string loginUser = ((TextBox)((FrameworkElement)parentSender).FindName("txtLogin")).Text;
            string passUser = ((TextBox)((FrameworkElement)parentSender).FindName("txtPassword")).Text;
            UserManager.EditWorklist(LogUser.Login, oldUserLogin, loginUser, passUser);
            lbxSetting.ItemsSource = FileManager.GetWorklistsForUser(LogUser);
        }

    }
}
