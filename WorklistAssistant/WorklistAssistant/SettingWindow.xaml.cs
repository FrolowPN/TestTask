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
    public partial class SettingWindow : Window
    {
        public User LogUser { get; set; }
        public List<UserInClinik> WorkLists { get; set; }
        public SettingWindow(User logUser, List<UserInClinik> worklists)
        {
            LogUser = logUser;
            WorkLists = worklists;
            InitializeComponent();
            lblUserName.Content = logUser.Login;
            dtGridWorklists.ItemsSource = UserManager.ConvertToSettingView(worklists);
            dtGridWorklists.CanUserAddRows = false;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UsernameAndPasswordWindow form = new UsernameAndPasswordWindow(LogUser);
            form.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var index = dtGridWorklists.SelectedIndex;
            WorkLists.RemoveRange(index, 1);
            dtGridWorklists.ItemsSource = UserManager.ConvertToSettingView(WorkLists); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var index = dtGridWorklists.SelectedIndex;
            var tempUser = new User(WorkLists[index].Login, WorkLists[index].Password);
            UsernameAndPasswordWindow form = new UsernameAndPasswordWindow(tempUser);
            form.ShowDialog();
        }
    }
}
