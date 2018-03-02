using System.Drawing;
using System.Windows.Forms;

namespace HopfieldNeuralNetworks.Controls
{
    public class PixelPictureBox : PictureBox
    {
        public static int BlackColor = Color.Black.ToArgb();
        public static int WhiteColor = Color.White.ToArgb();

        public int[,] pixels;

        public int _width, _height;

        private void generatePixels(Image image)
        {
            base.Image = image;

            if (image == null)
                return;

            _width = image.Width;
            _height = image.Height;

            Bitmap bitmap = new Bitmap(image);

            pixels = new int[_width, _height];

            for (int x = 0; x < _width; x++)
                for (int y = 0; y < _height; y++)
                    pixels[x, y] = bitmap.GetPixel(x, y).ToArgb();

            bitmap.Dispose();
        }

        public new Image Image
        {
            get{
                return base.Image;
            }
            set{
                generatePixels(value);
            }
        }

        public new void Invalidate()
        {
            lock (base.Image)
            {
                if (base.Image != null)
                {
                    Bitmap bitmap = new Bitmap(_width, _height);

                    for (int x = 0; x < bitmap.Width; x++)
                        for (int y = 0; y < bitmap.Height; y++)
                        {
                            bitmap.SetPixel(x, y, Color.FromArgb(pixels[x, y]));
                        }

                    base.Image = bitmap;
                }
            }

            base.Invalidate();
        }

        public void InversePixel(int x, int y)
        {
            pixels[x, y] = pixels[x, y] ^ 0xffffff;
        }
    }
}
