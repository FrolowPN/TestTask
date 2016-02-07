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
using WorklistAssistant.WAService;
using System.Windows.Threading;
using WorklistAssistant.Helpers;

namespace WorklistAssistant
{
    /// <summary>
    /// Interaction logic for WorklistAssistantWindow.xaml
    /// </summary>
    public partial class WorklistAssistantWindow : Window
    {
       DispatcherTimer Timer = new DispatcherTimer();
        public int m = 0;

        public string LoginUser { get; set; }
        public IList<Worklist> Users { get; set; }
        System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
        public WorklistAssistantWindow(string userLogin)
        {

            Timer.Interval = new TimeSpan(0, 1, 0);
            Timer.Tick += new EventHandler(timer);
            Timer.Start();
           
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            LoginUser = userLogin;
            Users = WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LoginUser));
            InitializeComponent();
            lblTimer.Content = "Refreshed " + m.ToString() + " min ago";
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            var primaryMonitorArea = SystemParameters.WorkArea;
            this.Show();
            Left = primaryMonitorArea.Right - ActualWidth;
            Top = primaryMonitorArea.Bottom - ActualHeight;
            lbxWorklists.ItemsSource = Users;
            lblUserName.Content = LoginUser;
            ni.Icon = new System.Drawing.Icon("Resources/v_icon.ico");
            ni.Visible = true;
            ni.DoubleClick += (sndr, args) =>
            {
                this.Show();
                this.WindowState = WindowState.Normal;
            };

            client.Close();
         
        }

        private void timer(object sender, EventArgs e)
        {
            lblTimer.Content = "Refreshed "+ m++.ToString() + " min ago";
            if (m==16)
            {
                var client = new WAServiceClient("BasicHttpBinding_IWAService");
                m = 0;
                lbxWorklists.ItemsSource= WLStatusHelper.UpdateStatusImg(client.GetWorklistsForUser(LoginUser));
                client.Close();
            }
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
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            m = 0;
            lblTimer.Content = "Refreshed " + m.ToString() + " min ago";
            lbxWorklists.ItemsSource = WLStatusHelper.UpdateStatusImg( client.GetWorklistsForUser(LoginUser));
            client.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var client = new WAServiceClient("BasicHttpBinding_IWAService");
            lbxWorklists.ItemsSource = WLStatusHelper.UpdateStatusImg( client.GetWorklistsForUser(LoginUser));
            client.Close();
        }

       
    }
}
