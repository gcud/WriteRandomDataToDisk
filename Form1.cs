using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string basepath = textBox2.Text;
            //单位Gb
            long size = GetGB(int.Parse(sizebox.Text));
            //单位Mb
            int filesize = GetMB(int.Parse(filesizebox.Text));
            CreateFile(size, filesize, basepath);
            MessageBox.Show("完成");
        }
        private int GetMB(int num)
        {
            return num * 1048576;
        }
        private long GetGB(int num)
        {
            return num * (long)1073741824;
        }
        private void CreateFile(long Size, int FizeSize, string path)
        {
            path = path + "mem";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            int index = 0;
            int nowsize = 0;
            while (nowsize < Size)
            {
                while (File.Exists(path + "/" + index))
                {
                    index++;
                }
                File.WriteAllText(path + "/" + index, GetRandStr(FizeSize));
                nowsize += FizeSize;
            }
        }
        private string GetRandStr(int size)
        {
            StringBuilder s = new StringBuilder();
            char[] l = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                s.Append(l[r.Next(61)]);
            }
            return s.ToString();
        }
    }
}
