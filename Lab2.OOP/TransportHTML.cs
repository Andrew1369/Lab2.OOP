using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Lab2.OOP
{
    class TransportHTML
    {
        public static void TransformXmlToHtml(string xmlFilePath, string xsltFilePath, string outputHtmlFilePath)
        {
            try
            {
                // Завантаження XML-документу
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlFilePath);

                // Ініціалізація XSLT перетворення
                XslCompiledTransform xslTransform = new XslCompiledTransform();
                xslTransform.Load(xsltFilePath);

                // Виконання трансформації та збереження в HTML
                using (XmlWriter writer = XmlWriter.Create(outputHtmlFilePath))
                {
                    xslTransform.Transform(xmlDocument, writer);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
