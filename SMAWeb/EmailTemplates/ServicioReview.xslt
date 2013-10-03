<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:decimal-format name="us" decimal-separator='.' grouping-separator=',' />
  <xsl:output method="html" indent="yes" />
  <xsl:template match="@* | node()">
    <html>
      <head>
        <title>Service Market - Su proveedor de Servicios Online</title>
        
      </head>
      <body>
        <div class="header">
        </div>
        <br />
        <p>
          <b>
            Estimado <xsl:value-of select="CustomerName" /> :
          </b>
        </p>
        <p>
          Le solicitamos cordialmente nos dé su opinión acerca del servicio "<xsl:value-of select="AnuncioDescripcion" />" que fue solicitado por usted al usuario <xsl:value-of select="ProviderName" />
        </p>
        <p>
          Para calificar el servicio y dejar sus comentarios haga clic <xsl:element name="a">
            <xsl:attribute name="href">
              <xsl:value-of select="LinkReview"/>
            </xsl:attribute>
            <xsl:value-of select="LinkReview"/>
          </xsl:element> <!--<a href="{LinkReview}"><xsl:value-of select="LinkReview"/>Aquí</a>-->
        </p>
        <br />
        <br />
        <p>Le recordamos la importancia de sus comentarios pues permitiran a otros usuarios tener una referencia de este servicio.</p>


        <br />
        <br />
        <p>Gracias por contar con nosotros</p>
        <br />
        Atentamente,
        <br />
        <br />
        <div class="footer">
          <a href="http://www.smamarket.com">
            <b>Admin Service Market</b>
          </a>
          <br />
          <a href="http://www.smamarket.com">
            <b>Servicio de Solicitud de Servicios</b>
          </a>
          <br />
          <a href="http://www.smamarket.com">www.smamarket.com</a>
        </div>
        <br />
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
