namespace Kinect.Core
{
    using System.Windows;

    public partial class CKinect
    {
        // Color interface
        public void ButtonScreenshotClick(object sender, RoutedEventArgs e)
        {
            if (mColor != null)
                mColor.ButtonScreenshotClick(sender, e);
        }
    }
}