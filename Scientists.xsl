<?xml version = "1.0"?>
<xsl:stylesheet
        xmlns:xsl ="http://www.w3.org/1999/XSL/Transform" version ="1.0">
  <xsl:output method = "html"/>
  <xsl:template match = "Scientists">
    <html>
      <body>
        <table border = "1" width ="1200">
          <TR>
            <th>Name</th>
            <th>Faculty</th>
            <th>Department</th>
            <th>Laboratory</th>
            <th>Position</th>
            <th>Activity</th>
          </TR>
        <xsl:for-each select= "//Scientist">
          <tr>
            <td>
              <xsl:value-of select= "@Name"/>
            </td>
            <td>
              <xsl:value-of select= "@Faculty"/>
            </td>
            <td>
              <xsl:value-of select= "@Department"/>
            </td>
            <td>
              <xsl:value-of select= "@Laboratory"/>
            </td>
            <td>
              <xsl:value-of select= "@Position"/>
            </td>
            <td>
              <xsl:value-of select= "@Activity"/>
            </td>
          </tr>   
        </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>