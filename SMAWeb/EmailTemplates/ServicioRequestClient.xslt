<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:decimal-format name="us" decimal-separator='.' grouping-separator=',' />
  <xsl:output method="html" indent="yes" />
  <xsl:template match="@* | node()">
    <html>
      <head>
        <title>Service Market - Su proveedor de Servicios Online</title>
        <style type="text/css">
          body
          {
          font-size: 11px;
          font-family: Tahoma;
          }
          div
          {
          padding: 10px 0px 10px 0px;
          }
          div.Header
          {
          background-image: url(http://www.hola.com/images/imagen.gif);
          background-repeat: no-repeat;
          }
          div.Footer
          {
          background-color: #ffffff;
          font-size: 11px;
          color: #696969;
          }
          table.detalle
          {
          width: 100%;
          border-collapse: collapse;
          }
          table.detalle th
          {
          font-size: 11px;
          font-family: Tahoma;
          font-weight: bold;
          color: Black;
          height: auto;
          border-bottom: solid 1px Black;
          }
          table.detalle td, table.detalle th
          {
          font-size: 10px;
          padding: 5px 5px 5px 5px;
          vertical-align: top;
          text-align: left;
          }
          a
          {
          text-decoration: none;
          }
          a:hover
          {
          text-decoration: none;
          }

          .CSSTableGenerator {
          margin:0px;padding:0px;
          width:100%;
          box-shadow: 10px 10px 5px #888888;
          border:1px solid #000000;

          -moz-border-radius-bottomleft:10px;
          -webkit-border-bottom-left-radius:10px;
          border-bottom-left-radius:10px;

          -moz-border-radius-bottomright:10px;
          -webkit-border-bottom-right-radius:10px;
          border-bottom-right-radius:10px;

          -moz-border-radius-topright:10px;
          -webkit-border-top-right-radius:10px;
          border-top-right-radius:10px;

          -moz-border-radius-topleft:10px;
          -webkit-border-top-left-radius:10px;
          border-top-left-radius:10px;
          }.CSSTableGenerator table{
          width:100%;
          height:100%;
          margin:0px;padding:0px;
          }.CSSTableGenerator tr:last-child td:last-child {
          -moz-border-radius-bottomright:10px;
          -webkit-border-bottom-right-radius:10px;
          border-bottom-right-radius:10px;
          }
          .CSSTableGenerator table tr:first-child td:first-child {
          -moz-border-radius-topleft:10px;
          -webkit-border-top-left-radius:10px;
          border-top-left-radius:10px;
          }
          .CSSTableGenerator table tr:first-child td:last-child {
          -moz-border-radius-topright:10px;
          -webkit-border-top-right-radius:10px;
          border-top-right-radius:10px;
          }.CSSTableGenerator tr:last-child td:first-child{
          -moz-border-radius-bottomleft:10px;
          -webkit-border-bottom-left-radius:10px;
          border-bottom-left-radius:10px;
          }.CSSTableGenerator tr:hover td{

          }
          .CSSTableGenerator tr:nth-child(odd){ background-color:#ffaa56; }
          .CSSTableGenerator tr:nth-child(even)    { background-color:#ffffff; }.CSSTableGenerator td{
          vertical-align:middle;


          border:1px solid #000000;
          border-width:0px 1px 1px 0px;
          text-align:left;
          padding:7px;
          font-size:10px;
          font-family:Arial;
          font-weight:bold;
          color:#000000;
          }.CSSTableGenerator tr:last-child td{
          border-width:0px 1px 0px 0px;
          }.CSSTableGenerator tr td:last-child{
          border-width:0px 0px 1px 0px;
          }.CSSTableGenerator tr:last-child td:last-child{
          border-width:0px 0px 0px 0px;
          }
          .CSSTableGenerator tr:first-child td{
          background:-o-linear-gradient(bottom, #ff7f00 5%, #bf5f00 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ff7f00), color-stop(1, #bf5f00) );
          background:-moz-linear-gradient( center top, #ff7f00 5%, #bf5f00 100% );
          filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#ff7f00", endColorstr="#bf5f00");	background: -o-linear-gradient(top,#ff7f00,bf5f00);

          background-color:#ff7f00;
          border:0px solid #000000;
          text-align:center;
          border-width:0px 0px 1px 1px;
          font-size:14px;
          font-family:Arial;
          font-weight:bold;
          color:#ffffff;
          }
          .CSSTableGenerator tr:first-child:hover td{
          background:-o-linear-gradient(bottom, #ff7f00 5%, #bf5f00 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ff7f00), color-stop(1, #bf5f00) );
          background:-moz-linear-gradient( center top, #ff7f00 5%, #bf5f00 100% );
          filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#ff7f00", endColorstr="#bf5f00");	background: -o-linear-gradient(top,#ff7f00,bf5f00);

          background-color:#ff7f00;
          }
          .CSSTableGenerator tr:first-child td:first-child{
          border-width:0px 0px 1px 0px;
          }
          .CSSTableGenerator tr:first-child td:last-child{
          border-width:0px 0px 1px 1px;
          }
        </style>
      </head>
      <body>
        <div class="header">
        </div>
        <br />
        <p>
          <b>
            Estimado <xsl:value-of select="CustomerName"/> :
          </b>
        </p>
        <p>
          Le estamos informando que su solicitud de servicio #<xsl:value-of select="SolicitudId" /> se ha creado satisfactoriamente.
          Dentro de unas horas el anunciante se pondrá en contacto con usted.
          <br />
          <br />
          <span>Le pedimos que sea paciente.</span>

          <div class="CSSTableGenerator" >
            <table >
              <tr>
                <td>
                  Nombre del Anunciante
                </td>
                <td >
                  Correo
                </td>
                <td>
                  Teléfono
                </td>
              </tr>
              <tr>
                <td >
                  <xsl:value-of select="ProviderName" />
                </td>
                <td>
                  <xsl:value-of select="EmailProveedor" />
                </td>
                <td>
                  <xsl:value-of select="TelefonoProveedor" />
                </td>
              </tr>

            </table>
          </div>
        </p>

        <br>

        </br><br>

        </br>
        <p>Le pedimos que sea paciente, ya que el tiempo de atención depende de la disponibilidad del anunciante.</p>
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
