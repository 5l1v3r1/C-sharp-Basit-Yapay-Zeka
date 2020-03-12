using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.API.Search;
using System.Net;
using System.IO;
namespace Araştırma_Motoru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            
        }

        void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.MaximumProgress;
            progressBar1.Value = (int)e.CurrentProgress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Google.API.Language.Turkish.ToString();
            IList<IWebResult> ListGoogle = GwebSearcher.Search(textBox.Text, 5);
            foreach (Google.API.Search.IWebResult result in ListGoogle)
            {
                listBox1.Items.Add(result.Title);
                listBox2.Items.Add(result .Url );
                listBox3.Items.Add(result .Content );
                listBox4.Items.Add(result .VisibleUrl );

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind;
            ind = (sender as ListBox).SelectedIndex; //Seçili elemanýn indexi
            //diðer listelerde de ayný elemaný seç
            listBox1.SelectedIndex = ind;
            listBox2.SelectedIndex = ind;
            listBox3.SelectedIndex = ind;
            listBox4.SelectedIndex = ind;
            int Top_ind;
            Top_ind = (sender as ListBox).TopIndex; //Seçili elemanýn top indexi
            //diðer listelerin de TopIndexini ayarla
            listBox1.TopIndex = Top_ind;
            listBox2.TopIndex = Top_ind;
            listBox3.TopIndex = Top_ind;
            listBox4.TopIndex = Top_ind;

            //Listelerdeki bilgileri Text kutularýnda göster
            textBox4.Text = listBox4.Text;
            textBox1.Text = listBox1.Text;
            textBox2.Text = listBox2.Text;
            textBox3.Text = listBox3.Text;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Olaylarý birleþtir. 
            listBox2.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            listBox3.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
            listBox4.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string gelenDeger = textBox4.Text;
            if (gelenDeger == "www.youtube.com")
            {
                MessageBox.Show("bu bir video kaynağıdır");
            }
            else
            {
               webBrowser1.Navigate(textBox2.Text);
               textBox5.Text = textBox1.Text;
            } 

        }
            
        

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (object textBoxlar in this .groupBox4 .Controls)
            { if (textBoxlar is TextBox) { ((TextBox)textBoxlar).Text = ""; } }
            foreach (object textBoxlar in this.groupBox3.Controls)
            { if (textBoxlar is TextBox) { ((TextBox)textBoxlar).Text = ""; } }
            foreach (object textBoxlar in this.groupBox2.Controls)
            { if (textBoxlar is TextBox) { ((TextBox)textBoxlar).Text = ""; } }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          richTextBox1 .Text =  webBrowser1.Document.Body.InnerText.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Ön Bilgi
            string gelen2 = richTextBox1.Text;
            int textUzunlugu = richTextBox1.TextLength;
            int toplam = textUzunlugu + 5;
            textBox7 .Text   = gelen2.PadRight(toplam, '.');

            // Ön Bilgi
            string gelen = textBox7.Text; //6
            int titleIndexBaslangici = gelen.IndexOf(textBox5.Text) + textBox5.TextLength; //7
            int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf(textBox6.Text); //8
            richTextBox2.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9

        }



        private void button3_Click(object sender, EventArgs e)
        {
            // Ön Bilgi
            string gelen = textBox7.Text ; //6
            int titleIndexBaslangici = gelen.IndexOf(textBox5.Text) + textBox5 .TextLength ; //7
            int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf(textBox6.Text); //8
            richTextBox2.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
