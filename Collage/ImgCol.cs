using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collage
{
    public class ImgCol
    {
        List<Image> Images = new List<Image>();

        public void Add(string img_file_name)
        {
            Image img = Image.FromFile(img_file_name);
            Images.Add(img);
        }

        public void Add(ImgRow row)
        {
            Images.Add(row.Render());
        }

        public Image Render()
        {

            List<Image> temp = new List<Image>();

            //1 определить максимальную ширину
            int _width = 0;
            foreach (Image img in Images)
            {
                if (img.Width > _width) _width = img.Width;
            }

            //2 подогнать все картинки под одну ширину
            foreach (Image img in Images)
            {
                float k = _width / (float)img.Width;
                temp.Add(ImageProcess.ScaleImage(img, k));
            }

            //3 собрать все картики в одну
            //суммарная высота
            int _height = 0;
            foreach (Image img in temp)
            {
                _height += img.Height;
            }
            Bitmap dest = new Bitmap(_width, _height );

            int y = 0;
            foreach (Image img in temp)
            {
                Graphics.FromImage(dest).DrawImage(img, 0, y);
                y += img.Height;
            }
            return dest;
        }
    }
}
