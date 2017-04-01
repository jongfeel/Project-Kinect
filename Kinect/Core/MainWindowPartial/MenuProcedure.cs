namespace Kinect
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        void HighResolutionClick(object sender, RoutedEventArgs e)
        {
            mKinect.Init(true, StandMode.IsChecked);
        }

        void LowResolutionClick(object sender, RoutedEventArgs e)
        {
            mKinect.Init(false, StandMode.IsChecked);
        }

        void ButtonScreenshotClick(object sender, RoutedEventArgs e)
        {
            mKinect.ButtonScreenshotClick(sender, e);
        }

        void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mKinect.WindowClosing(sender, e);
        }

        void SeatMode_Click(object sender, RoutedEventArgs e)
        {
            SeatMode.IsChecked = true;
            StandMode.IsChecked = false;
            mKinect.SeatModeClick(sender, e);
        }

        void StandMode_Click(object sender, RoutedEventArgs e)
        {
            StandMode.IsChecked = true;
            SeatMode.IsChecked = false;
            mKinect.StandModeClick(sender, e);
        }
    }
}
