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
    /// Interaction logic for WorklistAssistantWindow.xaml
    /// </summary>
    public partial class WorklistAssistantWindow : Window
    {
        public User LoginUser { get; set; }
        public IList<Worklist> Users { get; set; }
        public WorklistAssistantWindow(User user)
        {
            LoginUser = user;
            Users = FileManager.GetWorklistsForUser(LoginUser);
            InitializeComponent();
            lbxWorklists.ItemsSource = Users;
            lblUserName.Content = LoginUser.Login;
        }

        private void btnLogOut_Click(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Close();
        }

        private void btnSetting_Click(object sender, ExecutedRoutedEventArgs e)
        {
            SettingWindow formSet = new SettingWindow(LoginUser);
            formSet.ShowDialog();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbxWorklists.ItemsSource = FileManager.GetWorklistsForUser(LoginUser);
        }
    }
}
