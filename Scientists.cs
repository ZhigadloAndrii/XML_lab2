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
using System.Xml.Xsl;

namespace Scientists
{
    public partial class Scientists : Form
    {
        string path = "C:\\Users\\HP\\Desktop\\Нова папка\\Scientists\\Scientists.xml";
        public Scientist Scientist = null;
        public Scientists()
        {
            InitializeComponent();
        }


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }
        
        private void Search()
        {
            resBox.Clear();
            Scientist = new Scientist();
            IStrategy chosenStrategy;
            if (artistBox.Checked)
            {
                Scientist.Name = artistCmbBox.Text;
            }
            if (genreBox.Checked)
            {
                Scientist.Faculty = genreCmbBox.Text;
            }
            if (countryBox.Checked)
            {
                Scientist.Department = countryCmbBox.Text;
            }
            if (incomeBox.Checked)
            {
                Scientist.Laboratory = incomeCmbBox.Text;
            }
            if (bandBox.Checked)
            {
                Scientist.Position = bandCmbBox.Text;
            }
            if (activityBox.Checked)
            {
                Scientist.Activity = activityCmbBox.Text;
            }

            if (domBtn.Checked)
            {
               chosenStrategy = new DOM();
                List<Scientist> resList = chosenStrategy.Search(Scientist, path);
                ShowResults(resList);
            }
            if (saxBtn.Checked)
            {
                chosenStrategy = new SAX();
                List<Scientist> resList = chosenStrategy.Search(Scientist, path);
                ShowResults(resList);
            }
            if (linqToXmlBtn.Checked)
            {
                chosenStrategy = new LINQtoXML();
                List<Scientist> resList = chosenStrategy.Search(Scientist, path);
                ShowResults(resList);
            }
            
        }

        public void ShowResults(List<Scientist> mArtList)
        {
            for(int i = 0; i < mArtList.Count; i++)
            {
                resBox.AppendText(i + 1 + ".\n");
                resBox.AppendText("Name: " + mArtList[i].Name + "\n");
                resBox.AppendText("Faculty: " + mArtList[i].Faculty + "\n");
                resBox.AppendText("Department: " + mArtList[i].Department + "\n");
                resBox.AppendText("Laboratory: " + mArtList[i].Laboratory + "\n");
                resBox.AppendText("Position: " + mArtList[i].Position + "\n");
                resBox.AppendText("Activity: " + mArtList[i].Activity + "\n");
                resBox.AppendText("------------------------------------------\n");
            }
        }

        private void Scientist_Load(object sender, EventArgs e)
        {
            FillAll();
        }

        public void FillAll()
        {
            XmlDocument currentDoc = new XmlDocument();
            currentDoc.Load(path);
            XmlElement node = currentDoc.DocumentElement;
            XmlNodeList childNodes = node.SelectNodes("Scientist");

            foreach(XmlNode childNode in childNodes)
            {
                if (!artistCmbBox.Items.Contains(childNode.SelectSingleNode("@Name").Value))
                {
                    artistCmbBox.Items.Add(childNode.SelectSingleNode("@Name").Value);
                }
                if (!genreCmbBox.Items.Contains(childNode.SelectSingleNode("@Faculty").Value))
                {
                    genreCmbBox.Items.Add(childNode.SelectSingleNode("@Faculty").Value);
                }
                if (!countryCmbBox.Items.Contains(childNode.SelectSingleNode("@Department").Value))
                {
                    countryCmbBox.Items.Add(childNode.SelectSingleNode("@Department").Value);
                }
                if (!bandCmbBox.Items.Contains(childNode.SelectSingleNode("@Position").Value))
                {
                    bandCmbBox.Items.Add(childNode.SelectSingleNode("@Position").Value);
                }
                if (!incomeCmbBox.Items.Contains(childNode.SelectSingleNode("@Laboratory").Value))
                {
                    incomeCmbBox.Items.Add(childNode.SelectSingleNode("@Laboratory").Value);
                }
                if (!activityCmbBox.Items.Contains(childNode.SelectSingleNode("@Activity").Value))
                {
                    activityCmbBox.Items.Add(childNode.SelectSingleNode("@Activity").Value);
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            resBox.Clear();
            artistBox.Checked = false;
            artistCmbBox.Text = null;

            genreBox.Checked = false;
            genreCmbBox.Text = null;

            countryBox.Checked = false;
            countryCmbBox.Text = null;

            incomeBox.Checked = false;
            incomeCmbBox.Text = null;

            bandBox.Checked = false;
            bandCmbBox.Text = null;

            activityBox.Checked = false;
            activityCmbBox.Text = null;

            domBtn.Checked = false;
            saxBtn.Checked = false;
            linqToXmlBtn.Checked = false;
        }

        private void TransformBtn_Click(object sender, EventArgs e)
        {
            Transform();
        }

        private void Transform()
        {
            XslCompiledTransform xct = new XslCompiledTransform();
            xct.Load("C:\\Users\\HP\\Desktop\\Нова папка\\Scientists\\Scientists.xsl");
            string fXml = "C:\\Users\\HP\\Desktop\\Нова папка\\Scientists\\Scientists.xml";
            string fHtml = "C:\\Users\\HP\\Desktop\\Нова папка/Scientists/Scientists.html";
            xct.Transform(fXml, fHtml);
            MessageBox.Show("Done!");
        }
    }
}
