
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.Threading;

namespace Kinect.Core.KinectColor
{
    public class CKinectColor
    {
        private KinectSensor mSensor = null;
        public CKinectColor(ref KinectSensor sensor)
        {
            mSensor = sensor;
        }

        // 색상 정보를 유지할 비트 맵
        private WriteableBitmap colorBitmap = null;

        // 카메라에서 수신 한 컬러 데이터를 임시 저장
        private byte[] colorPixels = null;

        public void Init(bool ResolutionFlag)
        {
            // 색상 프레임을 수신하려면 색상 스트림을 켭니다.
            if (ResolutionFlag == true)
                mSensor.ColorStream.Enable(ColorImageFormat.RgbResolution1280x960Fps12);
            else mSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

            // 수신 할 픽셀을 넣을 공간을 할당합니다.
            this.colorPixels = new byte[this.mSensor.ColorStream.FramePixelDataLength];

            // colorBitmap은 화면에 표시 할 비트 맵입니다.
            this.colorBitmap = new WriteableBitmap(this.mSensor.ColorStream.FrameWidth,
                this.mSensor.ColorStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

            // ColorLayer 데이터를 배치 할 비트 맵을 가리 키도록 표시된 ColorLayer를 설정합니다.
            ((MainWindow)Application.Current.MainWindow).ColorLayer.Source = this.colorBitmap;

            // 새 색상 프레임 데이터가 있을 때마다 호출 할 이벤트 핸들러를 추가합니다.
            mSensor.ColorFrameReady += SensorColorFrameReady;
        }

        public void SafeRelease()
        {
            if (mSensor != null) mSensor.ColorFrameReady -= SensorColorFrameReady;
            ((MainWindow)Application.Current.MainWindow).ColorLayer.Source = null;
            colorBitmap = null;
            colorPixels = null;
            mSensor = null;
        }

        /// <summary>
        /// Kinect 센서의 ColorFrameReady 이벤트 용 이벤트 핸들러
        /// </summary>
        public void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null && mSensor != null && colorBitmap != null)
                {
                    // ColorLayer에 렌더링될 픽셀 데이터를 임시 배열에 복사합니다.
                    colorFrame.CopyPixelDataTo(this.colorPixels);

                    // 비트 맵에 픽셀 데이터를 씁니다. colorBitmap은 ColorLayer.Source와 연동되어있음.
                    this.colorBitmap.WritePixels(
                            new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
                            this.colorPixels,
                            this.colorBitmap.PixelWidth * sizeof(int), 0);
                }
            }
        }
        
        public void ButtonScreenshotClick(object sender, RoutedEventArgs e)
        {
            if (null == this.mSensor)
                return;

            // .png 파일을 저장하는 방법을 알고있는 png 비트 맵 인코더를 만듭니다.
            BitmapEncoder encoder = new PngBitmapEncoder();

            // writeablebitmap에서 프레임을 만들고 인코더에 추가합니다.
            encoder.Frames.Add(BitmapFrame.Create(this.colorBitmap));

            string time = System.DateTime.Now.ToString("hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            string myPhotos = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            string path = Path.Combine(myPhotos, "KinectSnapshot-" + time + ".png");

            // 새 파일을 디스크에 쓴다.
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    encoder.Save(fs);
                }

                ((MainWindow)Application.Current.MainWindow).statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteSuccess, path);
            }
            catch (IOException)
            {
                ((MainWindow)Application.Current.MainWindow).statusBarText.Text = string.Format(CultureInfo.InvariantCulture, "{0} {1}", Properties.Resources.ScreenshotWriteFailed, path);
            }
        }
    }
}
