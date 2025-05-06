using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace deneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\HP\Desktop\deneme.xml");
            XmlElement ogr = doc.CreateElement("ogr");
            ogr.SetAttribute("Tc", textBox1.Text);
            XmlNode sicil = doc.CreateNode(XmlNodeType.Element, "sicil", "");
            sicil.InnerText = textBox2.Text;
            ogr.AppendChild(sicil);
            XmlNode ad = doc.CreateNode(XmlNodeType.Element, "ad", "");
            ad.InnerText = textBox3.Text;
            ogr.AppendChild(ad);
            XmlNode soyad = doc.CreateNode(XmlNodeType.Element, "soyad", "");
            soyad.InnerText = textBox4.Text;
            ogr.AppendChild(soyad);
            XmlNode adres = doc.CreateNode(XmlNodeType.Element, "adres", "");
            adres.InnerText = textBox5.Text;
            ogr.AppendChild(adres);
            XmlNode dogyer = doc.CreateNode(XmlNodeType.Element, "dogyer", "");
            dogyer.InnerText = textBox6.Text;
            ogr.AppendChild(dogyer);
            XmlNode dogyil = doc.CreateNode(XmlNodeType.Element, "dogyil", "");
            dogyil.InnerText = textBox7.Text;
            ogr.AppendChild(dogyil);
            XmlNode isbas = doc.CreateNode(XmlNodeType.Element, "isbas", "");
            isbas.InnerText = textBox8.Text;
            ogr.AppendChild(isbas);
            XmlNode gorev = doc.CreateNode(XmlNodeType.Element, "gorev", "");
            gorev.InnerText = textBox9.Text;
            ogr.AppendChild(gorev);
            XmlNode mezun = doc.CreateNode(XmlNodeType.Element, "mezun", "");
            mezun.InnerText = textBox10.Text;
            ogr.AppendChild(mezun);
            XmlNode medeni = doc.CreateNode(XmlNodeType.Element, "medeni", "");
            medeni.InnerText = textBox11.Text;
            ogr.AppendChild(medeni);
            XmlNode cocuk = doc.CreateNode(XmlNodeType.Element, "cocuk", "");
            cocuk.InnerText = textBox12.Text;
            ogr.AppendChild(cocuk);
            XmlNode uyruk = doc.CreateNode(XmlNodeType.Element, "uyruk", "");
            uyruk.InnerText = textBox13.Text;
            ogr.AppendChild(uyruk);
            doc.DocumentElement.AppendChild(ogr);
            doc.Save(@"C:\Users\HP\Desktop\deneme.xml");}

        private void button2_Click(object sender, EventArgs e)
        {
            /* XmlDocument doc = new XmlDocument();
             doc.Load(@"C:\Users\HP\Desktop\deneme.xml");

             XmlNodeList liste = doc.GetElementsByTagName("ogr");
             listView1.GridLines = true;
             ListViewItem oge = new ListViewItem();
             oge = new ListViewItem(textBox1.Text);
             oge.SubItems.Add(textBox2.Text);
             oge.SubItems.Add(textBox3.Text);
             oge.SubItems.Add(textBox4.Text);
             oge.SubItems.Add(textBox5.Text);
             oge.SubItems.Add(textBox6.Text);
             oge.SubItems.Add(textBox7.Text);
             oge.SubItems.Add(textBox8.Text);
             oge.SubItems.Add(textBox9.Text);
             oge.SubItems.Add(textBox10.Text);
             oge.SubItems.Add(textBox11.Text);
             oge.SubItems.Add(textBox12.Text);
             oge.SubItems.Add(textBox13.Text);
             oge.ImageIndex = 1;
             listView1.Items.Add(oge);*/
            {
                // XML dosyasını yükle
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Users\HP\Desktop\deneme.xml");

                // ListView'i temizle
                listView1.Items.Clear();

                // Her "ogr" düğümü için döngü
                foreach (XmlNode ogr in doc.GetElementsByTagName("ogr"))
                {
                    // Yeni bir satır (ListViewItem) oluştur
                    ListViewItem oge = new ListViewItem(ogr.Attributes["Tc"].InnerText); // "Tc" özelliği

                    // Alt elemanları ekle
                    oge.SubItems.Add(ogr["sicil"].InnerText);
                    oge.SubItems.Add(ogr["ad"].InnerText);
                    oge.SubItems.Add(ogr["soyad"].InnerText);
                    oge.SubItems.Add(ogr["adres"].InnerText);
                    oge.SubItems.Add(ogr["dogyer"].InnerText);
                    oge.SubItems.Add(ogr["dogyil"].InnerText);
                    oge.SubItems.Add(ogr["isbas"].InnerText);
                    oge.SubItems.Add(ogr["gorev"].InnerText);
                    oge.SubItems.Add(ogr["mezun"].InnerText);
                    oge.SubItems.Add(ogr["medeni"].InnerText);
                    oge.SubItems.Add(ogr["cocuk"].InnerText);
                    oge.SubItems.Add(ogr["uyruk"].InnerText);

                    // ListView'e satırı ekle
                    listView1.Items.Add(oge);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("tc", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("sicil", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Ad", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Soyad", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("adres", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("dogyer", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("dogyil", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("isbas", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("gorev", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("mezun", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("medeni", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("cocuk", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("uyruk", 100, HorizontalAlignment.Center);
            listView1.View = View.Details;
        }
    }
}
