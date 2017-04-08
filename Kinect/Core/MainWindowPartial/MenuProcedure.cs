namespace Kinect
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        void HighResolutionClick(object sender, RoutedEventArgs e)
        {
            mKinect.Init(true, true);
        }

        void LowResolutionClick(object sender, RoutedEventArgs e)
        {
            mKinect.Init(false, true);
        }

        void ButtonScreenshotClick(object sender, RoutedEventArgs e)
        {
            mKinect.ButtonScreenshotClick(sender, e);
        }

        void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mKinect.WindowClosing(sender, e);
        }
    }
}
