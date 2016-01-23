﻿using System;
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
        public List<UserInClinik> Users { get; set; }
        public WorklistAssistantWindow(User user)
        {
            LoginUser = user;
            Random rnd = new Random();
            InitializeComponent();
            Users = new List<UserInClinik>(){new UserInClinik("Alex", "123", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                new UserInClinik("Alex_1", "sdf", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                new UserInClinik("Alex_2", "dfsdfh", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                    new UserInClinik("Alex", "123", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                new UserInClinik("Alex_112131212321234213423", "sdf", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                new UserInClinik("Alex_212112", "dfsdfh", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                    new UserInClinik("Alex", "123", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                new UserInClinik("Alex_11", "sdf", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2)),
                                                                new UserInClinik("Alex_222", "dfsdfh", rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(1, 100), rnd.Next(0, 2))};
           
            lbxWorklists.ItemsSource = UserManager.ConvertToView(Users);
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
            SettingWindow formSet = new SettingWindow(LoginUser, Users);
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
    }
}
