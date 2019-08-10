using Collage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //основная строка картинок, к которую будет добавлено все остальное
            ImgRow root = new ImgRow();
            root.Add("0.jpg");
           
            //колонка из картинок
            ImgCol col = new ImgCol();
            col.Add("2.jpg");

            //еще одна строка
            ImgRow row = new ImgRow();
            row.Add("5.jpg");
            row.Add("6.jpg");
            col.Add(row); //в колонку добавляется строка

            //
            col.Add("3.jpg");

            //в основную строку добавляется колонка
            root.Add(col); 

            root.Add("1.jpg");
            //коллаж собран

            //рендер всего получившегося в одну картинку
            Image result = root.Render();

            //изменить размеры коллажа
            result = ImageProcess.ScaleImage(result, 0.3f);

            //вывести на экран
            pictureBox1.Width = result.Width;
            pictureBox1.Height = result.Height;
            pictureBox1.Image = result;

        }
    }
}
