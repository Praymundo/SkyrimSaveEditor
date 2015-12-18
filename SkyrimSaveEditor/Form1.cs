using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SkyrimSaveEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox2.Focus();
            textBox1.Text = @"C:\Users\Taulim\Desktop\Save 225 - Taulim  Skyrim  35.52.26.ess";
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {
                SaveGame sg = SaveGame.ReadSaveGame(textBox1.Text);
                textBox2.Text = sg.ToString();
            }
            else
            {
                MessageBox.Show("O arquivo não existe!");
            }
        }
    }
}
