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
             EnterItemSource();
            
        }



        private void Button_Login_Click(object sender, ExecutedRoutedEventArgs e)
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
        public void EnterItemSource()
        {
            List<string> userLogins = UserManager.GetListLogin();
            
            foreach (var login in userLogins)
            {
                StackPanel stPanel = new StackPanel();
                stPanel.Orientation = Orientation.Horizontal;
                Image myImage = new Image();
                BitmapImage bi = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/Resources/s.jpg", UriKind.RelativeOrAbsolute));
                myImage.Source = bi;
                stPanel.Children.Add(myImage);

                TextBlock txt = new TextBlock();
                txt.Text = login;
                stPanel.Children.Add(txt);

                Button btn = new Button();
                StackPanel sp = new StackPanel();
                sp.Children.Add(new Image { Source = bi });
                btn.Content = sp;
                btn.Visibility = Visibility.Hidden;
                
                stPanel.Children.Add(btn);

                cmbUser.Items.Add(stPanel);
                
            }

        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbUser_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            //if (cmbUser.Text == "Add new User")
            //{
            //    cmbUser.SelectedIndex = -1;
            //    NewUserWindow form = new NewUserWindow();
            //    form.Show();

            //}
            //else
            //{
            //    return;
            //}
            if (cmbUser.SelectedIndex == cmbUser.Items.Count-1)
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
            //try
            //{
            //    List<string> users = UserManager.GetListLogin();
            //    cmbUser.ItemsSource = users;
            //}
            //catch (Exception ex)
            //{

            //    logger.Trace(ex + "\r\n");
            //}
            cmbUser.ItemsSource = new List<string>();
            EnterItemSource();

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


     













    }
}
