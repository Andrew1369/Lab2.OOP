<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" encoding="UTF-8" />

  <xsl:template match="/">
    <html>
      <head>
        <title>Гуртожиток - Інформація про студентів</title>
        <style>
          table {
          border-collapse: collapse;
          width: 100%;
          }
          th, td {
          border: 1px solid #ddd;
          padding: 8px;
          }
          th {
          background-color: #f2f2f2;
          text-align: left;
          }
          tr:hover {
          background-color: #f1f1f1;
          }
        </style>
      </head>
      <body>
        <h1>Список студентів</h1>
        <table>
          <tr>
            <th>П.І.П.</th>
            <th>Факультет</th>
            <th>Кафедра</th>
            <th>Курс</th>
            <th>Кімната</th>
            <th>Блок</th>
            <th>Дата заселення</th>
            <th>Дата виселення</th>
          </tr>
          <xsl:for-each select="Dormitory/Student">
            <tr>
              <td>
                <xsl:value-of select="FullName" />
              </td>
              <td>
                <xsl:value-of select="Faculty" />
              </td>
              <td>
                <xsl:value-of select="Department" />
              </td>
              <td>
                <xsl:value-of select="Course" />
              </td>
              <td>
                <xsl:value-of select="Room" />
              </td>
              <td>
                <xsl:value-of select="Block" />
              </td>
              <td>
                <xsl:value-of select="CheckInDate" />
              </td>
              <td>
                <xsl:value-of select="CheckOutDate" />
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
