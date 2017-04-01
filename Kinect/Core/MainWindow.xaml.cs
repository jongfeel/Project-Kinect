namespace Kinect
{
    using System.Windows;
    using Kinect.Core;

    public partial class MainWindow : Window
    {
        CKinect mKinect = new CKinect();

        public MainWindow()
        {
            InitializeComponent();

            // 최초 연결
            mKinect.Init(mResolutionFlag, StandMode.IsChecked);

            // 자동 키넥트 파인더 활성화
            mKinect.ActiveKinetFinder();
        }
    }
}
