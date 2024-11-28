using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2.OOP
{
    class ParserDOM : IParser
    {
        public List<Student> Search(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            var results = new List<Student>();
            XmlNodeList elements = xmlDoc.GetElementsByTagName("Student");

            foreach (XmlNode studentNode in elements)
            {
                string fullName = studentNode.SelectSingleNode("FullName")?.InnerText;
                string faculty = studentNode.SelectSingleNode("Faculty")?.InnerText;
                string department = studentNode.SelectSingleNode("Department")?.InnerText;
                string course = studentNode.SelectSingleNode("Course")?.InnerText;
                string room = studentNode.SelectSingleNode("Room")?.InnerText;
                string block = studentNode.SelectSingleNode("Block")?.InnerText;
                string checkInDate = studentNode.SelectSingleNode("CheckInDate")?.InnerText;
                string checkOutDate = studentNode.SelectSingleNode("CheckOutDate")?.InnerText;
                

                Student st = new Student(fullName, faculty, department, course, room, block, checkInDate, checkOutDate);
                results.Add(st);
            }
            return results;
        }

    }
}
