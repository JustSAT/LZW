﻿using System;
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
        public Image openedImage = null;
        public byte[] imageBytes = null;
        public byte[] newImageBytes = null;

        //Массив из индексов и строк

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
                            openedImage = Image.FromStream(myStream);
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
            File.Delete("c:/out.txt");
            imageBytes = imageToByteArray(openedImage);
            string inputLine = "";
            StreamWriter writer = new StreamWriter("c:/array.txt");
            for (int i = 0; i < imageBytes.Length; i++)
            {
                //inputLine += (char)imageBytes[i];
                writer.Write((char)imageBytes[i]);
            }

            MessageBox.Show("Start\n" + "Length: " + imageBytes.Length);
            writer.Close();

            inputLine = File.ReadAllText("c:/array.txt");
            //File.Delete("c:/array.txt");

            LZWAlgorithm lzw = new LZWAlgorithm();
            writer = new StreamWriter("c:/out.txt", true, Encoding.Default);
            
            writer.Write(lzw.Compress(inputLine));
            MessageBox.Show("Compressing Done!");
            File.Delete("c:/array.txt");
            writer.Close();

        }
        public static byte[] converterDemo(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();

            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] fileBytes)
        {
            using (MemoryStream fileStream = new MemoryStream(fileBytes))
            {
                return Image.FromStream(fileStream);
            }
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
            LZWAlgorithm lzw = new LZWAlgorithm();
            string input = File.ReadAllText(filePath);
            newImageBytes = new byte[input.Length];
            input = lzw.Decompress(input);
            for (int i = 0; i < input.Length; i++)
            {
                newImageBytes[i] = (byte)input[i];
            }
            //File.WriteAllText("c:/test.txt", input);
            MessageBox.Show(newImageBytes.Length.ToString());
            Image result = byteArrayToImage(newImageBytes);
            result.Save("c:/result");
            MessageBox.Show("Decompressing Done!");
        }
        
    }
}
