using System;
using System.Windows.Media.Imaging;

using System.Windows;
using System.Windows.Media;

namespace Klarf.Model
{
    class WaferMap
    {
        public BitmapImage LoadWaferMap(string waferImgSrc)
        {
            // TIF 파일을 읽어서 Bitmap 형식으로 반환
            BitmapImage WaferImg = new BitmapImage(new Uri(waferImgSrc, UriKind.RelativeOrAbsolute));
            return WaferImg;
        }
      

        private BitmapSource VisualizeWaferMap(DieInfo[] dieInfos, BitmapImage baseImage)
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                foreach (DieInfo dieInfo in dieInfos)
                {
                    Rect rect = new Rect(dieInfo.X, dieInfo.Y, 10, 10);
                    drawingContext.DrawRectangle(new SolidColorBrush(dieInfo.StatusColor), null, rect);
                }
            }

            RenderTargetBitmap targetBitmap = new RenderTargetBitmap(
                (int)baseImage.Width, (int)baseImage.Height,
                baseImage.PixelWidth, baseImage.PixelHeight,
                PixelFormats.Pbgra32);

            targetBitmap.Render(drawingVisual);
            return targetBitmap;
        }
        public class DieInfo
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Color StatusColor { get; set; }
        }


    }
}
