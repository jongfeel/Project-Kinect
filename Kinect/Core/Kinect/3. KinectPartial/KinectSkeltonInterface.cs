namespace Kinect.Core
{
    using System.Windows;

    public partial class CKinect
    {
        // Skeleton interface
        public void SeatModeClick(object sender, RoutedEventArgs e)
        {
            if (mSkeleton != null)
                mSkeleton.SeatModeClick(sender, e);
        }
        public void StandModeClick(object sender, RoutedEventArgs e)
        {
            if (mSkeleton != null)
                mSkeleton.StandModeClick(sender, e);
        }
    }
}