using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scientists
{
    public class SAX : IStrategy
    {
        private List<Scientist> lastRes = null;
        public List<Scientist> Search(Scientist _scientist, string path)
        {
            List<Scientist> resList = new List<Scientist>();
            XmlReader reader = XmlReader.Create(path);

            Scientist found = null;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Scientist")
                        {
                            found = new Scientist();
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "Name")
                                {
                                    found.Name = reader.Value;
                                }
                                if (reader.Name == "Faculty")
                                {
                                    found.Faculty = reader.Value;
                                }
                                if (reader.Name == "Department")
                                {
                                    found.Department = reader.Value;
                                }
                                if (reader.Name == "Laboratory")
                                {
                                    found.Laboratory = reader.Value;
                                }
                                if (reader.Name == "Position")
                                {
                                    found.Position = reader.Value;
                                }
                                if (reader.Name == "Activity")
                                {
                                    found.Activity = reader.Value;
                                }
                            }
                            resList.Add(found);
                        }
                        break;
                }
            }
            lastRes = Filter(resList, _scientist);
            return lastRes;
        }
        
        private List<Scientist> Filter(List<Scientist> resList, Scientist temp)
        {
            List<Scientist> newRes = new List<Scientist>();
            if(resList != null)
            {
                foreach(Scientist scientist in resList)
                {
                    if ((temp.Name == scientist.Name || temp.Name == String.Empty) &&
                       (temp.Faculty == scientist.Faculty || temp.Faculty == String.Empty) &&
                       (temp.Department == scientist.Department || temp.Department == String.Empty) &&
                       (temp.Laboratory == scientist.Laboratory || temp.Laboratory == String.Empty) &&
                       (temp.Position == scientist.Position || temp.Position == String.Empty) &&
                       (temp.Activity == scientist.Activity || temp.Activity == String.Empty))
                    {
                        newRes.Add(scientist);
                    }
                }
            }
            return newRes;
        }
    }
}

