using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace image
{
    public partial class Form1 : Form
    {
        //画图函数
        private void  CreatImage()
        {
            //缺页率数组
            int []may={10,40,50,50,60,78,69,45,78,24,54,35,65,65,56,54,63,47,52,58,65,32,45,85,35,61,75,86,84,56};
            int height=600,width=800;
            //bitmap是一种图片通用格式
            Bitmap image = new Bitmap(width, height);
            //graphics是一种c#画图工具
            Graphics graphics = Graphics.FromImage(image);
            try
            {   
                graphics.Clear(Color.White);
                Font font = new Font("Arial", 9, FontStyle.Regular);
                Font font1 = new Font("宋体", 20, FontStyle.Regular);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
                graphics.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
                Brush brush1 = new SolidBrush(Color.Blue);
                //标题
                graphics.DrawString("缺页率统计折线图",font1,brush1,new PointF(130,30));
                //画图片的边框线
                graphics.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 1, image.Height - 1);
                Pen mypen = new Pen(brush, 1);
                //绘制纵向线条
                int x = 100;
                for (int i = 0; i < 30;i++ )
                {
                    graphics.DrawLine(mypen, x, 80, x, 340);
                    x = x + 40;
                }
                Pen mypen1 = new Pen(Color.Blue, 2);
                Pen mypen2=new Pen(Color.Red,2);
                graphics.DrawLine(mypen1, 60, 80, 60, 340);
                //绘制横向线条;
                int y = 100;
                for (int i = 0; i < 10;i++ )
                {
                    graphics.DrawLine(mypen, 60, y, 1000, y);
                    y = y + 24;
                }
                graphics.DrawLine(mypen1, 60, y, 1000, y);
                //x轴
                string[] n = { "100", "90", "80", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
                x = 90;
                for (int i = 0; i < 12;i++ )
                {
                    //设置文字内容及输出位置
                    graphics.DrawString(n[i].ToString(), font, Brushes.Red, x, 348);
                    x = x + 40;
                }
                //y轴，输出数组为m，与随机序列对接
                string[] m = {"100", "90", "80", "70", "60","50","40","30","20","10","0" };
                y = 90;
                for (int i = 0; i < 11;i++ )
                {
                    //设置文字内容及输出位置
                    graphics.DrawString(m[i].ToString(),font, Brushes.Red, 20, y); y = y + 24;
                }
                //记录缺页率对应的坐标数组
                int[] count = new int[30];
                for (int i = 0; i < 30;i++ )
                {
                    count[i] = (100 - may[i])/10 * 24 + 100;
                }
                SolidBrush mybrush = new SolidBrush(Color.Red);
                Point[] myPoint = new Point[30];
                for (int i = 0; i < 30;i++ )
                {
                    myPoint[i].X = 60 + 40 * i;
                    myPoint[i].Y = count[i];
                }
                //绘制折线
                graphics.DrawLines(mypen2, myPoint);
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                image.Save(MStream,System.Drawing.Imaging.ImageFormat.Gif);

                //显示图片
                Bitmap bitMange = new Bitmap(image);
                pictureBox1.Image = bitMange;
            }
            finally
            {
                graphics.Dispose();
                image.Dispose();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreatImage();

        }
    }
}
