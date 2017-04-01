namespace Kinect
{
    using System.Windows;
    using System;
    using System.Windows.Controls;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        TimeSpan mSpanTime = new TimeSpan(0, 0, 0, 0, 1);

        /*void Gif_MediaEnded(object sender, RoutedEventArgs e)
        {
            LoadingLayer.Position = mSpanTime;
            LoadingLayer.Play();
            ProcessUI();
        }*/

        public void LoadLoadingGif()
        {
            //LoadingLayer.MediaEnded += Gif_MediaEnded;
            ColorLayer.Source = null;
            SkeletonLayer.Source = null;
            LoadingLayer.Visibility = Visibility.Visible;
            LoadingLayer.Position = mSpanTime;
            LoadingLayer.Play();
            ProcessUI();
        }

        public void StopGif()
        {
            LoadingLayer.Stop();
            if(LoadingLayer.Visibility == Visibility.Visible) LoadingLayer.Visibility = Visibility.Hidden;
            ProcessUI();
            //LoadingLayer.MediaEnded -= Gif_MediaEnded;
        }
    }
}
