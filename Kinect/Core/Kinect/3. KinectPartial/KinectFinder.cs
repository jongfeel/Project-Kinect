namespace Kinect.Core
{
    using Microsoft.Kinect;
    using System;
    using System.Windows;
    using System.Windows.Threading;

    public partial class CKinect
    {
        // 자동으로 키넥트를 찾는 기능

        DispatcherTimer mTimer = null;

        public void ActiveKinetFinder()
        {
            if(mTimer == null)
                mTimer = new DispatcherTimer(
                    TimeSpan.FromSeconds(1),
                    DispatcherPriority.Render,
                    (s, e) => { this.KinetFinder(); },
                    Application.Current.Dispatcher
                );
        }

        public void StopKinectFinding() { if (mTimer != null) mTimer.Stop(); }
        public void StartKinectFinding() { if (mTimer != null) mTimer.Start(); }

        void KinetFinder(){
            if (KinectSensor.KinectSensors.Count == 0){
                ((MainWindow)Application.Current.MainWindow).statusBarText.Text = Properties.Resources.AutoReconnecting;
                ((MainWindow)Application.Current.MainWindow).LoadLoadingGif();
            }
            else{
                foreach (var potentialmSensor in KinectSensor.KinectSensors){
                    try { var temp = potentialmSensor.ElevationAngle; } // 키넥트가 정상적으로 동작하지 않는 상황에서 예외를 던진다.
                    catch{
                        Init(((MainWindow)Application.Current.MainWindow).GetResloutionFlag(),
                            ((MainWindow)Application.Current.MainWindow).StandMode.IsChecked);
                    }
                }
            }
        }
    }
}
