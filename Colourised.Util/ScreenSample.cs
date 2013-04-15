using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Colourised.Util
{
    public class ScreenSample
    {
        public static int[] Sample(Rectangle bounds)
        {
            var bmp = new Bitmap(bounds.Width, bounds.Height);

            var g = Graphics.FromImage(bmp);

            g.CopyFromScreen(bounds.X, bounds.Y, 0, 0,
                new Size(
                    bounds.Width,
                    bounds.Height));
            g.Dispose();

            BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            // Declare a single-dimensional array to hold the bytes of the bitmap.
            int pixelCount = bounds.Width * bounds.Height;
            int[] pixels = new int[pixelCount];

            // Copy the RGB values into the array.
            IntPtr ptr = bitmapData.Scan0;
            Marshal.Copy(ptr, pixels, 0, pixelCount);
            bmp.UnlockBits(bitmapData);

            bmp.Dispose();

            return pixels;
        }

        public static Color AverageColor(int[] pixels)
        {
            long[] sums = new long[3];
            int pixelCount = pixels.Length;

            // Possible optimization: There's no need to iterate over every pixel; could just use every second/third/fourth/etc. pixel
            for (int s = 0; s < pixelCount; s++)
            {
                uint pixel = (uint)pixels[s];
                sums[0] += (pixel & 0x00FF0000);
                sums[1] += (pixel & 0x0000FF00);
                sums[2] += (pixel & 0x000000FF);
            }

            byte[] averages = new byte[3];

            // Bitshifting is done on the sums of the values rather than each and every value
            averages[0] = (byte)((sums[0] >> 16) / pixelCount);
            averages[1] = (byte)((sums[1] >> 8) / pixelCount);
            averages[2] = (byte)((sums[2] >> 0) / pixelCount);

            return Color.FromArgb(255, averages[0], averages[1], averages[2]);
        }

    }

}
