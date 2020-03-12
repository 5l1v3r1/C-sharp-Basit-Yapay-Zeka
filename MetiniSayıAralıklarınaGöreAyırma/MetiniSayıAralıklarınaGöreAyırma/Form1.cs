using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            try
            {

            // Metin Kodları
            string kelime = richTextBox1.Text;

            if (label11.Text == "250") 
            { } 
                else 
                { }
            textBox1.Text = kelime.Substring(0,250);
            textBox2.Text = kelime.Substring(250, 250);
            textBox3.Text = kelime.Substring(500, 250);
            textBox4.Text = kelime.Substring(750, 250);
            textBox5.Text = kelime.Substring(1000, 250);
            textBox6.Text = kelime.Substring(1250, 250);
                
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = richTextBox1.TextLength.ToString ();

            label1.Text = textBox1 .TextLength.ToString ();
            label2.Text = textBox2.TextLength.ToString();
            label3.Text = textBox3.TextLength.ToString();
            label4.Text = textBox4.TextLength.ToString();
            label5.Text = textBox5.TextLength.ToString();
            label6.Text = textBox6.TextLength.ToString();
        }


    }
}
