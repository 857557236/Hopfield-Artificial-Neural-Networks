using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HopfieldNeuralNetworks
{
    static class Extensions
    {
        public static int[,] GetPixelArray(this Bitmap bitmap)
        {
            int width = bitmap.Width,
                height = bitmap.Height;

            int[,] pixels = new int[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    pixels[x, y] = bitmap.GetPixel(x, y).ToArgb();

            return pixels;
        }

        public static Bitmap ResizeBitmap(this Bitmap bitmap, int width, int height)
        {
            Rectangle rect = new Rectangle(0, 0, width, height);
            Bitmap result = new Bitmap(width, height);
            result.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(bitmap, rect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return result;
        }
    }
}
