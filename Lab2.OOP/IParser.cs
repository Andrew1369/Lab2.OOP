using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2.OOP
{
    interface IParser
    {
        List<Student> Search(string filePath);
    }
}
