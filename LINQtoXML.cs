using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Scientists
{
    public class LINQtoXML : IStrategy
    {
        private List<Scientist> resList = null;
        XDocument currentDoc = new XDocument();
        public List<Scientist> Search(Scientist _scientist, string path)
        {
            currentDoc = XDocument.Load(@path);
            resList = new List<Scientist>();

            List<XElement> matches = (from value in currentDoc.Descendants("Scientist")
                                      where ((_scientist.Name == String.Empty || _scientist.Name == value.Attribute("Name").Value) &&
                                      (_scientist.Faculty == String.Empty || _scientist.Faculty == value.Attribute("Faculty").Value) &&
                                      (_scientist.Laboratory == String.Empty || _scientist.Laboratory == value.Attribute("Laboratory").Value) &&
                                      (_scientist.Department == String.Empty || _scientist.Department == value.Attribute("Department").Value) &&
                                      (_scientist.Position == String.Empty || _scientist.Position == value.Attribute("Position").Value) &&
                                      (_scientist.Activity == String.Empty || _scientist.Activity == value.Attribute("Activity").Value))
                                      select value).ToList();
            foreach(XElement match in matches)
            {
                Scientist scientist = new Scientist();
                scientist.Name = match.Attribute("Name").Value;
                scientist.Faculty = match.Attribute("Faculty").Value;
                scientist.Department = match.Attribute("Department").Value;
                scientist.Laboratory = match.Attribute("Laboratory").Value;
                scientist.Position = match.Attribute("Position").Value;
                scientist.Activity = match.Attribute("Activity").Value;
                resList.Add(scientist);
            }
            return resList;
        }
    }
}
