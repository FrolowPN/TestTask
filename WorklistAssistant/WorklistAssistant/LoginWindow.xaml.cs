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
            cmbUserInitialize();
            
        }
        public void cmbUserInitialize()
        {
            foreach (var item in UserManager.GetListLogin())
            {
                StackPanel stc = new StackPanel();
                stc.Orientation = Orientation.Horizontal;
                Label lbl = new Label();
                lbl.Content = item;

                Label lbl1 = new Label();
                lbl1.Content = "=)";
                stc.Children.Add(lbl1);
                stc.Children.Add(lbl);
                cmbUser.Items.Add(stc);
            }
            StackPanel stc1 = new StackPanel();
                stc1.Orientation = Orientation.Horizontal;
                Label lblnu = new Label();
                lblnu.Content = "Add new User";

                Label lblnu1 = new Label();
                lblnu1.Content = "+";
                stc1.Children.Add(lblnu1);
                stc1.Children.Add(lblnu);
                Button newBtn = new Button();
                newBtn.Content = stc1;
                newBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF323132"));
                newBtn.Width = 210;
                newBtn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF323132"));
                newBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF323132"));
                cmbUser.Items.Add(newBtn);
            
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
            //Refresh();
            cmbUser.Items.Clear();
            cmbUserInitialize();
        }

     

      
        

       


       

       

       

       
    }
}
