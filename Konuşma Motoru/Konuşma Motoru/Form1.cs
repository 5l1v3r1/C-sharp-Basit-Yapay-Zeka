using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Konuşma_Motoru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://212.15.10.146:8877/demo.aspx?Voice=Gül+Premium+(Türkçe)&Speech=" + textBox1.Text + "&drpIndex=2&lang=TR");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox2.Text = webBrowser1.Document.Body.InnerHtml.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
                {
            if (textBox2.Text.Contains(".mp3") == true)
            { }
            else
            {
                
                    webBrowser1.Document.GetElementById("Button1").InvokeMember("click"); 
            }
                }                
            catch
            {
            
            }
           
            
            try
            {
                string gelen = textBox2.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox3.Text) + textBox3.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf(textBox4.Text); //8

                textBox5.Text ="http://212.15.10.146:8877" + gelen.Substring(titleIndexBaslangici, titleIndexBitisi); //9
            }
            catch { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            wmp1.URL =textBox5.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wmp1.URL = @"F:\Müzikler\Ahmet Kaya   Kum Gibi.mp3";
            
            wmp2.URL = @"F:\Müzikler\Ahmet Kaya Ağladıkça.mp3";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
