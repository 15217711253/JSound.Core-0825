using System.Windows;

namespace JSound.App
{


    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private MainWindow mainWindow;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
