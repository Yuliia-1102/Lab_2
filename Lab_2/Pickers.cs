using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_2
{
    class Pickers
    {
        static public void AddPickerValue(XmlNode n, string nodeName, List<string> pickerValues)
        {
            XmlNode childNode = n.SelectSingleNode(nodeName);
            if (childNode != null)
            {
                string nodeValue = childNode.InnerText;
                if (!string.IsNullOrEmpty(nodeValue) && !pickerValues.Contains(nodeValue))
                {
                    pickerValues.Add(nodeValue);
                }
            }
        }

        static public void FillYearPickers(string nodeName, List<string> pickerValues)
        {

            List<int> years = pickerValues.Select(int.Parse).ToList();
            int minYear = years.Min();
            int maxYear = years.Max();

            List<string> yearIntervals = new List<string>();

            for (int year = minYear; year <= maxYear; year += 10)
            {
                int endYear = Math.Min(year + 9, maxYear); 
                yearIntervals.Add($"{year}-{endYear}");
            }

            pickerValues.Clear();
            pickerValues.AddRange(yearIntervals);
        }
    }
}
