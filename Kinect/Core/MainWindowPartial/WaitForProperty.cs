namespace Kinect
{
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {
        internal static void WaitForPriority(DispatcherPriority priority)
        {
            DispatcherFrame frame = new DispatcherFrame();
            DispatcherOperation dispatcherOperation =
                Dispatcher.CurrentDispatcher.BeginInvoke(priority,
                    new DispatcherOperationCallback(ExitFrameOperation), frame);
            Dispatcher.PushFrame(frame);
            if (dispatcherOperation.Status != DispatcherOperationStatus.Completed)
            {
                dispatcherOperation.Abort();
            }
        }
        // WaitForPriority(DispatcherPriority.Render);
        public void ProcessUI()
        {
            Thread.Sleep(10);
            Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
            Thread.Sleep(10);
        }

        static object ExitFrameOperation(object obj)
        {
            ((DispatcherFrame)obj).Continue = false;
            return null;
        }
    }
}
