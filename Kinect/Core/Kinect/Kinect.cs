namespace Kinect.Core
{
    using System.Windows;
    using Microsoft.Kinect;
    using Kinect.Core.KinectColor;
    using Kinect.Core.KinectSkeleton;

    public partial class CKinect
    {
        KinectSensor mSensor = null;
        CKinectColor mColor = null;
        CKinectSkeleton mSkeleton = null;

        public void Init(bool ResolutionFlag, bool SkeletonMode)
        {
            StopKinectFinding();
            ((MainWindow)Application.Current.MainWindow).SetResolution(ResolutionFlag);
            ((MainWindow)Application.Current.MainWindow).statusBarText.Text = Properties.Resources.KinectLoading;
            ((MainWindow)Application.Current.MainWindow).LoadLoadingGif();
            SafeRelease();

            // 모든 센서를 살펴보고 처음 연결된 센서를 시작하십시오.
            // 이렇게하려면 앱을 시작할 때 Kinect가 연결되어 있어야합니다.
            // 플러그 앤 플러그에 대해 앱을 강력하게 만들려면,
            // Microsoft.Kinect.Toolkit에 제공된 KinectmSensorChooser를 사용하는 것이 좋습니다 (Toolkit Browser의 구성 요소 참조).
            // 여기서는 내가 타이머로 다르게 구현.. 시간나면 바꿔보던지 해보자.
            try
            {
                foreach (var potentialmSensor in KinectSensor.KinectSensors)
                {
                    if (potentialmSensor.Status == KinectStatus.Connected)
                    {
                        mSensor = potentialmSensor;
                        break;
                    }
                }
            }
            catch { SafeRelease(); ((MainWindow)Application.Current.MainWindow).statusBarText.Text = Properties.Resources.NoKinectLib; }

            if (null != mSensor){
                // Start the mSensor!
                try {
                    SetUp(ResolutionFlag, SkeletonMode);
                    mSensor.Start();
                }
                catch { SafeRelease(); }
            }

            if (null != mSensor){
                ((MainWindow)Application.Current.MainWindow).statusBarText.Text = Properties.Resources.KinectConnected;
                ((MainWindow)Application.Current.MainWindow).StopGif();
            }
            StartKinectFinding();
        }

        void SafeRelease()
        {
            if (mSensor != null) mSensor.Stop();
            if (mColor != null) mColor.SafeRelease();
            if (mSkeleton != null) mSkeleton.SafeRelease();
            mSensor = null;
        }

        void SetUp(bool ResolutionFlag, bool SkeletonMode)
        {
            mColor = new CKinectColor(ref mSensor);
            mColor.Init(ResolutionFlag);
            mSkeleton = new CKinectSkeleton(ref mSensor);
            mSkeleton.Init(SkeletonMode);
        }

        public void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != mSensor) mSensor.Stop();
        }

    }
}
