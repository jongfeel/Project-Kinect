using System.Windows;
using Kinect.Core;
using Kinect.Core.MainWindowPartial;

namespace Kinect
{
    public partial class MainWindow : Window
    {
        CKinect mKinect = null;

        public MainWindow()
        {
            InitializeComponent();
            
            mKinect = new CKinect(this);

            // 최초 연결
            mKinect.Init(mResolutionFlag, true);

            // 자동 키넥트 파인더 활성화
            mKinect.ActiveKinetFinder();

            DataContext = new MainWindowViewModel(mKinect.SetSkeletonTrackingMode);
        }
    }
}
