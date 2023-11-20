using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_2
{
    internal class LinqXmlSearch : ISearch
    {
        public LinqXmlSearch() { }

        public ObservableCollection<ScientificWorker> Search(SearchCriteria criteria, string xmlPath)
        {
            ObservableCollection<ScientificWorker> results = new ObservableCollection<ScientificWorker>();
            var doc = XDocument.Load(xmlPath);
            var result = from work in doc.Descendants("ScientificWorker")
                         where (
                         SearchHelper.IsValidEntry(work.Element("Name").Value, criteria.Name) &&
                         SearchHelper.IsValidPickerValue(work.Element("AuthorName").Value, criteria.AuthorName) &&
                         SearchHelper.IsValidPickerValue(work.Element("Faculty").Value, criteria.Faculty) &&
                         SearchHelper.IsValidPickerValue(work.Element("Department").Value, criteria.Department) &&
                         SearchHelper.IsValidPickerValue(work.Element("DateOfBirth").Value, criteria.DateOfBirth) &&
                         SearchHelper.IsValidPickerValue(work.Element("AuthorPosition").Value, criteria.AuthorPosition) &&
                         SearchHelper.IsValidYear(work.Element("StartOnPosition").Value, criteria.StartOnPosition) &&
                         SearchHelper.IsValidYear(work.Element("LastonPosition").Value, criteria.EndOnPosition) &&
                         SearchHelper.IsValidPickerValue(work.Element("Gender").Value, criteria.Gender) &&
                         SearchHelper.IsValidPickerValue(work.Element("Address").Value, criteria.Address) &&
                         SearchHelper.IsValidPickerValue(work.Element("Age").Value, criteria.Age) &&
                         SearchHelper.IsValidPickerValue(work.Element("Branch").Value, criteria.Branch)
                         )
                         select new ScientificWorker
                         {
                             Name = work.Element("Name").Value,
                             AuthorName = work.Element("AuthorName").Value,
                             Faculty=work.Element("Faculty").Value,
                             Department = work.Element("Department").Value,
                             DateOfBirth = work.Element("DateOfBirth").Value,
                             AuthorPosition = work.Element("AuthorPosition").Value,
                             StartOnPosition = work.Element("StartOnPosition").Value,
                             EndOnPosition = work.Element("LastonPosition").Value,
                             Gender = work.Element("Gender").Value,
                             Address = work.Element("Address").Value,
                             Age = work.Element("Age").Value,
                             Branch = work.Element("Branch").Value
                         };

            foreach(var work in result)
            {
                results.Add(work);
            }

            return results;
        }
    }
}
