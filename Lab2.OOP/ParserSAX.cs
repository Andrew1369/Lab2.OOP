using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2.OOP
{
    class ParserSAX : IParser
    {
        public List<Student> Search(string filePath)
        {
            List<Student> students = new List<Student>();
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                string currentElement = string.Empty;
                string fullName = string.Empty, faculty = string.Empty, department = string.Empty;
                string course = string.Empty, room = string.Empty, block = string.Empty;
                string checkInDate = string.Empty, checkOutDate = string.Empty;
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            currentElement = reader.Name;
                            break;

                        case XmlNodeType.Text:
                            switch (currentElement)
                            {
                                case "FullName":
                                    fullName = reader.Value;
                                    break;
                                case "Faculty":
                                    faculty = reader.Value;
                                    break;
                                case "Department":
                                    department = reader.Value;
                                    break;
                                case "Course":
                                    course = reader.Value;
                                    break;
                                case "Room":
                                    room = reader.Value;
                                    break;
                                case "Block":
                                    block = reader.Value;
                                    break;
                                case "CheckInDate":
                                    checkInDate = reader.Value;
                                    break;
                                case "CheckOutDate":
                                    checkOutDate = reader.Value;
                                    break;
                            }
                            break;

                        case XmlNodeType.EndElement:
                            if (reader.Name == "Student")
                            {
                                Student st = new Student(fullName, faculty, department, course, room, block, checkInDate, checkOutDate);
                                students.Add(st);
                                // Скидання змінних
                                fullName = faculty = department = course = room = block = checkInDate = checkOutDate = string.Empty;
                            }
                            break;
                    }
                }
            }
            return students;
        }
    }
}
