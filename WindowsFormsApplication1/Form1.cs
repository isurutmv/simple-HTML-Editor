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


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = richTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile1 = new SaveFileDialog();
            if (savefile1.ShowDialog()==DialogResult.OK)
            {
                using(Stream s=File.Open(savefile1.FileName,FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(richTextBox1.Text);
              
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myst;
            OpenFileDialog opendialog = new OpenFileDialog();
            if (opendialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                if ((myst=opendialog.OpenFile()) !=null  ) {
                    string stfile = opendialog.FileName;
                    string filetext = File.ReadAllText(stfile);
                    richTextBox1.Text = filetext;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
        }
    }
}
