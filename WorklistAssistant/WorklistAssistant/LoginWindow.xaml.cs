﻿using BL;
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
        public MainWindow()
        {
            InitializeComponent();
            
            List<string> users = UserManager.GetListLogin();
            cmbUser.ItemsSource =users ;

        }
        public void Refresh()
        {
            List<string> users = UserManager.GetListLogin();
            cmbUser.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserManager.VerifyingPassword(cmbUser.Text, txtPassword.Text))
            {

                WorklistAssistantWindow form = new WorklistAssistantWindow(UserManager.GetUserOnLogin(cmbUser.Text));
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Password Wrong");
            }
            //NewUserWindow form = new NewUserWindow();
            //form.ShowDialog();
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

     

      
        

       


       

       

       

       
    }
}
