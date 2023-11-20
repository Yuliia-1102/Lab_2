using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_2
{
    internal class DomXmlSearch : ISearch
    {
        public DomXmlSearch() { }

        private void ProcessNode(XmlNode n, ObservableCollection<ScientificWorker> results, SearchCriteria criteria)
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

            foreach (XmlNode childNode in n.ChildNodes)
            {
                string nodeValue = childNode.InnerText;

                if (childNode.Name.Equals("Name") && SearchHelper.IsValidEntry(nodeValue, criteria.Name))
                {
                    name = nodeValue;
                }
                if (childNode.Name.Equals("AuthorName") && SearchHelper.IsValidPickerValue(nodeValue, criteria.AuthorName))
                {
                    authorName = nodeValue;
                }
                if (childNode.Name.Equals("Faculty") && SearchHelper.IsValidPickerValue(nodeValue, criteria.Faculty))
                {
                    faculty = nodeValue;
                }
                if (childNode.Name.Equals("Department") && SearchHelper.IsValidPickerValue(nodeValue, criteria.Department))
                {
                    department = nodeValue;
                }
                if (childNode.Name.Equals("DateOfBirth") && SearchHelper.IsValidPickerValue(nodeValue, criteria.DateOfBirth))
                {
                    dateOfBirth = nodeValue;
                }
                if (childNode.Name.Equals("AuthorPosition") && SearchHelper.IsValidPickerValue(nodeValue, criteria.AuthorPosition))
                {
                    authorPosition = nodeValue;
                }
                if (childNode.Name.Equals("StartOnPosition") && SearchHelper.IsValidYear(nodeValue, criteria.StartOnPosition))
                {
                    startOnPosition = nodeValue;
                }
                if (childNode.Name.Equals("LastonPosition") && SearchHelper.IsValidYear(nodeValue, criteria.EndOnPosition))
                {
                    endOnPosition = nodeValue;
                }
                if (childNode.Name.Equals("Gender") && SearchHelper.IsValidPickerValue(nodeValue, criteria.Gender))
                {
                    gender = nodeValue;
                }
                if (childNode.Name.Equals("Address") && SearchHelper.IsValidPickerValue(nodeValue, criteria.Address))
                {
                    address = nodeValue;
                }
                if (childNode.Name.Equals("Age") && SearchHelper.IsValidPickerValue(nodeValue, criteria.Age))
                {
                    age = nodeValue;
                }
                if (childNode.Name.Equals("Branch") && SearchHelper.IsValidPickerValue(nodeValue, criteria.Branch))
                {
                    branch = nodeValue;
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

        public ObservableCollection<ScientificWorker> Search(SearchCriteria criteria, string xmlPath)
        {
            ObservableCollection<ScientificWorker> results = new ObservableCollection<ScientificWorker>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlNode node = doc.DocumentElement;
            foreach (XmlNode nod in node.ChildNodes)
            {
                ProcessNode(nod, results, criteria);
            }
            return results;
        }
    }
}
