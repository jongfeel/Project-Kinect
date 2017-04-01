namespace Kinect
{
    using System.Windows;

    public partial class MainWindow : Window
    {
        bool mResolutionFlag = false;

        public bool GetResloutionFlag() { return mResolutionFlag; }

        public void SetResolution(bool ResolutionFlag)
        {
            mResolutionFlag = ResolutionFlag;
            //Left = 0; Top = 0;

            double mHeight = SystemParameters.WindowCaptionHeight + SystemParameters.ResizeFrameHorizontalBorderHeight;

            if (mResolutionFlag == true)
            {
                Left = 0; Top = 0;
                Width = 1280;
                Height = 960 + 40 + mHeight;    // 40은 메뉴 + 상태표시줄
            }
            else
            {
                Width = 640;
                Height = 480 + 40 + mHeight;
            }
        }
    }
}