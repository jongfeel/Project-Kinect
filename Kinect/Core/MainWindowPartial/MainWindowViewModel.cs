using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinect;
using System.Windows.Input;
using Microsoft.Kinect;

namespace Kinect.Core.MainWindowPartial
{
    public class MainWindowViewModel : PropertyChangedEventBase
    {
        private Action<SkeletonTrackingMode> modeAction = null;
        public MainWindowViewModel(Action<SkeletonTrackingMode> modeAction)
        {
            this.modeAction = modeAction;
        }

        private bool isStand;
        public bool IsStand
        {
            get { return isStand; }
            set
            {
                isStand = value;
                OnPropertyChanged("IsStand");
            }
        }

        private ICommand standCommand;
        public ICommand StandCommand
        {
            get
            {
                standCommand = new RelayCommand((parameter) => 
                {
                    IsStand = true;
                    IsSeated = false;
                    modeAction(SkeletonTrackingMode.Default);
                });
                return standCommand;
            }
        }

        private bool isSeated;
        public bool IsSeated
        {
            get { return isSeated; }
            set
            {
                isSeated = value;
                OnPropertyChanged("IsSeated");
            }
        }

        private ICommand seatCommand;
        public ICommand SeatCommand
        {
            get
            {
                seatCommand = new RelayCommand((parameter) =>
                {
                    IsStand = false;
                    IsSeated = true;
                    modeAction(SkeletonTrackingMode.Seated);
                });
                return seatCommand;
            }
        }
    }
}
