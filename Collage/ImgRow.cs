using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collage
{
    public class ImgRow
    {
        List<Image> Images = new List<Image>();

        public void Add(string img_file_name)
        {
            Image img = Image.FromFile(img_file_name);
            Images.Add(img);
        }

        public void Add(ImgCol col)
        {
            Images.Add(col.Render());
        }

        public Image Render()
        {

            List<Image> temp = new List<Image>();

            //1 определить максимальную высоту
            int height = 0;
            foreach (Image img in Images)
            {
                if (img.Height > height) height = img.Height;
            }

            //2 подогнать все картинки под одну высоту
            foreach (Image img in Images)
            {
                float k = height /(float)img.Height;
                temp.Add(ImageProcess.ScaleImage(img, k));
            }

            //3 собрать все картики в одну
            //суммарная ширина
            int width = 0;
            foreach (Image img in temp)
            {
                width += img.Width;
            }
            Bitmap dest = new Bitmap(width, height);

            int x = 0;
            foreach(Image img in temp)
            {
                Graphics.FromImage(dest).DrawImage(img, x, 0);
                x += img.Width;
            }
            return dest;
        }

    }
}
