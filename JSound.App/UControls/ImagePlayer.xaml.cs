using JSound.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JSound.App.UControls
{
    /// <summary>
    /// ImagePlayer.xaml 的交互逻辑
    /// </summary>
    public partial class ImagePlayer : UserControl
    {
        public ImagePlayer()
        {
            InitializeComponent();


        }

        public RoomPlayerItemViewModel roomsInfo
        {
            get { return (RoomPlayerItemViewModel)GetValue(RoomsInfoProperty); }
            set { SetValue(RoomsInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoomsInfoProperty =
            DependencyProperty.Register("roomsInfo", typeof(RoomPlayerItemViewModel), typeof(ImagePlayer));




        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ImageButton.Visibility = System.Windows.Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ImageButton.Visibility = System.Windows.Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = roomsInfo;

        }
    }
}
