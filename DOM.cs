using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scientists
{
    public class DOM : IStrategy
    {
        public List<Scientist> Search(Scientist _scientist, string path)
        {
            XmlDocument currentDoc = new XmlDocument();
            currentDoc.Load(path);
            List<List<Scientist>> resList = new List<List<Scientist>>();

            if (_scientist.Name == String.Empty && _scientist.Faculty == String.Empty && _scientist.Department == String.Empty
                && _scientist.Laboratory == String.Empty && _scientist.Position == String.Empty && _scientist.Activity == String.Empty)
            {
                return CatchError(currentDoc);
            }

            if (_scientist.Name != String.Empty) resList.Add(SearchByAttribute("Scientist", "Name", _scientist.Name, currentDoc));
            if (_scientist.Faculty != String.Empty) resList.Add(SearchByAttribute("Scientist", "Faculty", _scientist.Faculty, currentDoc));
            if (_scientist.Department != String.Empty) resList.Add(SearchByAttribute("Scientist", "Department", _scientist.Department, currentDoc));
            if (_scientist.Laboratory != String.Empty) resList.Add(SearchByAttribute("Scientist", "Laboratory", _scientist.Laboratory, currentDoc));
            if (_scientist.Position != String.Empty) resList.Add(SearchByAttribute("Scientist", "Position", _scientist.Position, currentDoc));
            if (_scientist.Activity != String.Empty) resList.Add(SearchByAttribute("Scientist", "Activity", _scientist.Activity, currentDoc));

            return FindCrossings(resList, _scientist);
        }

        public List<Scientist> SearchByAttribute(string nodeName, string attribute, string template, XmlDocument doc)
        {
            List<Scientist> resList = new List<Scientist>();

            if(template != String.Empty)
            {
                XmlNodeList list = doc.SelectNodes("//" + nodeName + "[@" + attribute + "=\"" + template + "\"]");
                foreach(XmlNode node in list)
                {
                    resList.Add(GetInfo(node));
                }
            }
            return resList;
        }

        public List<Scientist> CatchError(XmlDocument doc)
        {
            List<Scientist> result = new List<Scientist>();
            XmlNodeList list = doc.SelectNodes("//" + "Scientist");
            foreach(XmlNode node in list)
            {
                result.Add(GetInfo(node));
            }
            return result;
        }

        public Scientist GetInfo(XmlNode node)
        {
            Scientist mA = new Scientist();
            mA.Name = node.Attributes.GetNamedItem("Name").Value;
            mA.Faculty = node.Attributes.GetNamedItem("Faculty").Value;
            mA.Department = node.Attributes.GetNamedItem("Department").Value;
            mA.Laboratory = node.Attributes.GetNamedItem("Laboratory").Value;
            mA.Position = node.Attributes.GetNamedItem("Position").Value;
            mA.Activity = node.Attributes.GetNamedItem("Activity").Value;

            return mA;
        }

        public List<Scientist> FindCrossings(List<List<Scientist>> scientists, Scientist obj)
        {
            List<Scientist> resList = new List<Scientist>();
            List<Scientist> cleared = CheckNodes(scientists, obj);
            foreach(Scientist temp in cleared)
            {
                bool isIn = false;
                foreach (Scientist mA in resList)
                {
                    if (mA.Compare(temp))
                    {
                        isIn = true;
                    }
                }
                if (!isIn)
                {
                    resList.Add(temp);
                }

            }
            return resList;
        }

        public List<Scientist> CheckNodes(List<List<Scientist>> scientists, Scientist obj)
        {
            List<Scientist> newRes = new List<Scientist>();
            foreach(List<Scientist> artList in scientists)
            {
                foreach(Scientist scientist in artList)
                {
                    if ((obj.Name == scientist.Name || obj.Name == String.Empty) &&
                        (obj.Faculty == scientist.Faculty || obj.Faculty == String.Empty) &&
                        (obj.Department == scientist.Department || obj.Department == String.Empty) &&
                        (obj.Laboratory == scientist.Laboratory || obj.Laboratory == String.Empty) &&
                        (obj.Position == scientist.Position || obj.Position == String.Empty) &&
                        (obj.Activity == scientist.Activity || obj.Activity == String.Empty))
                    {
                        newRes.Add(scientist);
                    }
                }
            }
            return newRes;
        }
    }
}
