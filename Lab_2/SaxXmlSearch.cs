using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_2
{
    internal class SaxXmlSearch : ISearch
    {
        public SaxXmlSearch() { }

        public ObservableCollection<ScientificWorker> Search(SearchCriteria criteria, string xmlPath)
        {
            ObservableCollection<ScientificWorker> results = new ObservableCollection<ScientificWorker>();
            
            using (var xmlReader = new XmlTextReader(xmlPath))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "ScientificWork")
                    {
                        string name = "";
                        string authorName = "";
                        string faculty = "";
                        string department = "";
                        string dateOfBirth = "";
                        string authorPosition = "";
                        string startOnPosition = "";
                        string endOnPosition = "";
                        string gender = "";
                        string address = "";
                        string age = "";
                        string branch = "";

                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReader.Name)
                                {
                                    case "Name":
                                        {
                                            xmlReader.Read();
                                            if(xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Name))
                                                {
                                                    name = xmlReader.Value;
                                                }
                                            }
                                            
                                            break;
                                        }
                                    case "AuthorName":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.AuthorName))
                                                {
                                                    authorName = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "Faculty":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Faculty))
                                                {
                                                    faculty = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "Department":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Department))
                                                {
                                                    department = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "DateOfBirth":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.DateOfBirth))
                                                {
                                                    dateOfBirth = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "AuthorPosition":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.AuthorPosition))
                                                {
                                                    authorPosition = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "StartOnPosition":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidYear(xmlReader.Value, criteria.StartOnPosition))
                                                {
                                                    startOnPosition = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "LastonPosition":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidYear(xmlReader.Value, criteria.EndOnPosition))
                                                {
                                                    endOnPosition = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "Gender":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Gender))
                                                {
                                                    gender = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "Address":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Address))
                                                {
                                                    address = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "Age":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Age))
                                                {
                                                    age = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                    case "Branch":
                                        {
                                            xmlReader.Read();
                                            if (xmlReader.NodeType == XmlNodeType.Text)
                                            {
                                                if (SearchHelper.IsValidEntry(xmlReader.Value, criteria.Branch))
                                                {
                                                    branch = xmlReader.Value;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                            else if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "ScientificWork")
                            {
                                break;
                            }
                        }

                        if (name != "" && authorName != "" && faculty != "" && department != "" && dateOfBirth != "" && authorPosition != "" && startOnPosition != "" && endOnPosition != "" && gender != "" && address != "" && age != "" && branch != "")
                        {
                            ScientificWorker work = new ScientificWorker();
                            work.Name = name;
                            work.AuthorName = authorName;
                            work.Faculty = faculty;
                            work.Department = department;
                            work.DateOfBirth = dateOfBirth;
                            work.AuthorPosition = authorPosition;
                            work.StartOnPosition = startOnPosition;
                            work.EndOnPosition = endOnPosition;
                            work.Gender = gender;
                            work.Address = address;
                            work.Age = age;
                            work.Branch = branch;

                            results.Add(work);
                        }
                    }
                }
            }
    
            return results;
        }
    }
}
