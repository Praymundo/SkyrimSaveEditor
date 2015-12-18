using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace SkyrimSaveEditor
{
    public class SaveGame
    {
        public string Name { get; private set; }
        public int SaveNumber { get; private set; }
        public int PictureWidth { get; private set; }
        public int PictureHeight { get; private set; }
        public Bitmap Picture { get; private set; }
        public DateTime SaveDate { get; private set; }
        public string FileName { get; private set; }
        public string Texto { get; private set; }
        public int HeaderSize { get; private set; }

        public static SaveGame ReadSaveGame(string Filename)
        {

            SaveGame save = new SaveGame();
            save.FileName = Filename;

            byte[] file = File.ReadAllBytes(Filename);

            int headerWidth = BitConverter.ToInt32(file, 13);
            save.SaveNumber = BitConverter.ToInt32(file, 21);
            short nameWidth = BitConverter.ToInt16(file, 25);

            save.Name = System.Text.Encoding.UTF8.GetString(file, 27, nameWidth);
            save.PictureWidth = BitConverter.ToInt32(file, 13 + headerWidth - 4);
            save.PictureHeight = BitConverter.ToInt32(file, 13 + headerWidth);
            // save.readPictureData(file, 13 + headerWidth + 4, save.PictureWidth, save.PictureHeight);
            save.SaveDate = DateTime.FromFileTime((long)BitConverter.ToUInt64(file, 13 + headerWidth - 12));
            save.HeaderSize = headerWidth;
            save.Texto = file.Length.ToString();
            return save;
        }

        private void readPictureData(byte[] file, int startIndex, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Marshal.Copy(file, startIndex, data.Scan0, width * height * 3);
            bitmap.UnlockBits(data);
            Picture = bitmap;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Nome: {0}", this.Name));
            sb.Append(Environment.NewLine);

            sb.Append(String.Format("Data: {0}", this.SaveDate.ToString()));
            sb.Append(Environment.NewLine);

            sb.Append(String.Format("Numero: {0}", this.SaveNumber));
            sb.Append(Environment.NewLine);

            sb.Append(String.Format("Cabeçalho: {0}", this.HeaderSize));
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
