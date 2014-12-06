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
namespace LZW
{
    public partial class Form1 : Form
    {
        public Bitmap openedImage = null;
        public byte[] imageBytes = null;
        private int[] table;

        private Stream openedCompressed = null;
        private string filePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void openImage_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "all files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            openedImage = new Bitmap(Image.FromStream(myStream));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void compress_Click(object sender, EventArgs e)
        {
            MakeTable();
        }

        private void MakeTable()
        {
            StreamWriter outStream = new StreamWriter("C:/out.txt");
            imageBytes = imageToByteArray(openedImage);
            table = new int[openedImage.Width * openedImage.Height];
            for (int i = 0; i < imageBytes.Length; i++)
            {
                table[i] = -1;
            }
            for (int i = 0; i < imageBytes.Length; i++)
            {
                table[imageBytes[i]] = imageBytes[i];
            }

            int curByte = imageBytes[0];
            string str = "" + (char)imageBytes[0];
            int id = 0;
            for (int i = 1; i < imageBytes.Length; i++)
            {
                byte ch = imageBytes[i];
                id = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    id += str[j];
                }
                id += ch;
                if (table[id] != -1)
                {
                    str += ch;
                }
                else
                {
                    //out
                    outStream.Write(str);
                    table[id] = id + ch;
                    str = "" + ch;
                }
            }
            //out
            outStream.Write(str);
            outStream.Close();
            
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        
        private void openCopressed_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            openedCompressed = myStream;
                            filePath = openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void decompress_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(filePath);
            StreamWriter write = new StreamWriter("c:/test.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if(i != lines.Length-1)
                write.WriteLine(lines[i]);
                else
                    write.Write(lines[i]);
            }
            write.Close();
        }
    }
}
