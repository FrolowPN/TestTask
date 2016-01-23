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
        System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
        public WorklistAssistantWindow(User user)
        {
            LoginUser = user;
            Users = FileManager.GetWorklistsForUser(LoginUser);
            InitializeComponent();
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            var primaryMonitorArea = SystemParameters.WorkArea;
            this.Show();
            Left = primaryMonitorArea.Right - ActualWidth;
            Top = primaryMonitorArea.Bottom - ActualHeight;
            lbxWorklists.ItemsSource = Users;
            lblUserName.Content = LoginUser.Login;
            ni.Icon = new System.Drawing.Icon("Resources/v_icon.ico");
            ni.Visible = true;
            ni.Click += (sndr, args) =>
            {
                
                this.ShowInTaskbar = !this.ShowInTaskbar;

                if (this.ShowInTaskbar)
                {
                    this.Show();
                }
                else

                { this.Hide(); }
            };
            
            
        }

        private void btnLogOut_Click(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Show();
            this.Close();
            ni.Dispose();
        }

        private void btnSetting_Click(object sender, ExecutedRoutedEventArgs e)
        {
            SettingWindow formSet = new SettingWindow(LoginUser);
            formSet.Show();
            this.Close();
            ni.Dispose();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
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
