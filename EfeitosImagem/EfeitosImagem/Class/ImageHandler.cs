using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfeitosImagem.Class
{
    class ImageHandler
    {
        public enum MirrorType
        {
            None,
            Horizontal,
            Vertical
        }

        public Bitmap Image { get; set; }

        public MirrorType enuMirrorType { get; set; }

        public ImageHandler(Bitmap image, MirrorType enuMirrorType)
        {
            Image = image;
            this.enuMirrorType = enuMirrorType;
        }

        public Bitmap ApplayNegative(bool transform = true)
        {
            Bitmap newImage = this.Image;

            if (transform)
            {
                if (this.enuMirrorType == MirrorType.Horizontal)
                {
                    newImage = new ImageHandler(this.ApplayFlipHorizontal(), this.enuMirrorType).ApplayGreyScale(false);
                }                 
                else if (this.enuMirrorType == MirrorType.Vertical)
                {
                    newImage = new ImageHandler(this.ApplayFlipVertical(), this.enuMirrorType).ApplayGreyScale(false);
                }                    
            }
                
            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                rgbValues[i] = (byte)(255 - rgbValues[i]);
                rgbValues[i + 1] = (byte)(255 - rgbValues[i + 1]);
                rgbValues[i + 2] = (byte)(255 - rgbValues[i + 2]);
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplayBlackAndWhite(bool transform = true)
        {
            Bitmap newImage = this.Image;

            if (transform)
            {
                if (this.enuMirrorType == MirrorType.Horizontal)
                {
                    newImage = this.ApplayFlipHorizontal();
                }
                else if (this.enuMirrorType == MirrorType.Vertical)
                {
                    newImage = this.ApplayFlipVertical();
                }
            }

            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int threshold = 127;

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                int average = (rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3;

                rgbValues[i] = (byte)(average >= threshold ? 255 : 0);
                rgbValues[i + 1] = (byte)(average >= threshold ? 255 : 0);
                rgbValues[i + 2] = (byte)(average >= threshold ? 255 : 0);
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplaySepia(bool transform = true)
        {
            Bitmap newImage = this.Image;

            if (transform)
            {
                if (this.enuMirrorType == MirrorType.Horizontal)
                {
                    newImage = this.ApplayFlipHorizontal();
                }
                else if (this.enuMirrorType == MirrorType.Vertical)
                {
                    newImage = this.ApplayFlipVertical();
                }
            }

            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                int tr = (int)(0.393 * rgbValues[i] + 0.769 * rgbValues[i + 1] + 0.189 * rgbValues[i + 2]);
                int tg = (int)(0.349 * rgbValues[i] + 0.686 * rgbValues[i + 1] + 0.168 * rgbValues[i + 2]);
                int tb = (int)(0.272 * rgbValues[i] + 0.534 * rgbValues[i + 1] + 0.131 * rgbValues[i + 2]);
                tr = tr > 255 ? 255 : tr;
                tg = tg > 255 ? 255 : tg;
                tb = tb > 255 ? 255 : tb;

                rgbValues[i] = (byte)(tr);
                rgbValues[i + 1] = (byte)(tg);
                rgbValues[i + 2] = (byte)(tb);
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplayGreyScale(bool transform = true)
        {
            Bitmap newImage = this.Image;

            if (transform)
            {
                if (this.enuMirrorType == MirrorType.Horizontal)
                {
                    newImage = this.ApplayFlipHorizontal();
                }
                else if (this.enuMirrorType == MirrorType.Vertical)
                {
                    newImage = this.ApplayFlipVertical();
                }
            }

            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                int average = (rgbValues[i] + rgbValues[i + 1] + rgbValues[i + 2]) / 3;

                rgbValues[i] = (byte)(average);
                rgbValues[i + 1] = (byte)(average);
                rgbValues[i + 2] = (byte)(average);
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplayPixelize(bool transform = true)
        {
            Bitmap newImage = this.Image;

            if (transform)
            {
                if (this.enuMirrorType == MirrorType.Horizontal)
                {
                    newImage = this.ApplayFlipHorizontal();
                }
                else if (this.enuMirrorType == MirrorType.Vertical)
                {
                    newImage = this.ApplayFlipVertical();
                }
            }

            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int blockSize = 7; 

            for (int y = 0; y < newImage.Height; y += blockSize)
            {
                for (int x = 0; x < newImage.Width; x += blockSize)
                {
                    int sumR = 0, sumG = 0, sumB = 0;
                    int count = 0;
                    
                    for (int dy = 0; dy < blockSize && y + dy < newImage.Height; dy++)
                    {
                        for (int dx = 0; dx < blockSize && x + dx < newImage.Width; dx++)
                        {
                            int index = ((y + dy) * bmpData.Stride) + ((x + dx) * 3);

                            sumR += rgbValues[index];
                            sumG += rgbValues[index + 1];
                            sumB += rgbValues[index + 2];
                            count++;
                        }
                    }

                    byte avgR = (byte)(sumR / count);
                    byte avgG = (byte)(sumG / count);
                    byte avgB = (byte)(sumB / count);
                    
                    for (int dy = 0; dy < blockSize && y + dy < newImage.Height; dy++)
                    {
                        for (int dx = 0; dx < blockSize && x + dx < newImage.Width; dx++)
                        {
                            int index = ((y + dy) * bmpData.Stride) + ((x + dx) * 3);
                            rgbValues[index] = avgR;
                            rgbValues[index + 1] = avgG;
                            rgbValues[index + 2] = avgB;
                        }
                    }
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplayGaussianBlur(bool transform = true)
        {
            Bitmap newImage = this.Image;

            if (transform)
            {
                if (this.enuMirrorType == MirrorType.Horizontal)
                {
                    newImage = this.ApplayFlipHorizontal();
                }
                else if (this.enuMirrorType == MirrorType.Vertical)
                {
                    newImage = this.ApplayFlipVertical();
                }
            }

            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            int[,] kernel = { { 1, 2, 1 },
                  { 2, 4, 2 },
                  { 1, 2, 1 } }; 

            int kernelWidth = 3;
            int kernelHeight = 3;
            int kernelSum = 16;

            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < newImage.Width; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;
                    
                    for (int ky = 0; ky < kernelHeight; ky++)
                    {
                        for (int kx = 0; kx < kernelWidth; kx++)
                        {
                            int pixelX = x + kx - 1;
                            int pixelY = y + ky - 1;
                            if (pixelX >= 0 && pixelX < newImage.Width &&
                                pixelY >= 0 && pixelY < newImage.Height)
                            {
                                int index = (pixelY * bmpData.Stride) + (pixelX * 3);
                                int weight = kernel[ky, kx];
                                sumR += rgbValues[index] * weight;
                                sumG += rgbValues[index + 1] * weight;
                                sumB += rgbValues[index + 2] * weight;
                            }
                        }
                    }
                    byte avgR = (byte)(sumR / kernelSum);
                    byte avgG = (byte)(sumG / kernelSum);
                    byte avgB = (byte)(sumB / kernelSum);
                    
                    int pixelIndex = (y * bmpData.Stride) + (x * 3);
                    rgbValues[pixelIndex] = avgR;
                    rgbValues[pixelIndex + 1] = avgG;
                    rgbValues[pixelIndex + 2] = avgB;
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplayFlipHorizontal()
        {
            Bitmap newImage = Image;
            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int y = 0; y < newImage.Height; y++)
            {
                for (int x = 0; x < (newImage.Width / 2); x++)
                {
                    int i = y * bmpData.Stride + x * 3;
                    int j = y * bmpData.Stride + (newImage.Width - x - 1) * 3;

                    byte tmpB = rgbValues[i];
                    byte tmpG = rgbValues[i + 1];
                    byte tmpR = rgbValues[i + 2];

                    rgbValues[i] = rgbValues[j];
                    rgbValues[i + 1] = rgbValues[j + 1];
                    rgbValues[i + 2] = rgbValues[j + 2];

                    rgbValues[j] = tmpB;
                    rgbValues[j + 1] = tmpG;
                    rgbValues[j + 2] = tmpR;
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }

        public Bitmap ApplayFlipVertical()
        {
            Bitmap newImage = Image;
            Rectangle rect = new Rectangle(0, 0, newImage.Width, newImage.Height);
            BitmapData bmpData = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * newImage.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int y = 0; y < newImage.Height / 2; y++)
            {
                for (int x = 0; x < newImage.Width * 3; x++)
                {
                    int i = y * bmpData.Stride + x;
                    int j = (newImage.Height - y - 1) * bmpData.Stride + x;
                    byte tmp = rgbValues[i];
                    rgbValues[i] = rgbValues[j];
                    rgbValues[j] = tmp;
                }
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);
            newImage.UnlockBits(bmpData);

            return newImage;
        }
    }
}
