using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace SMAWeb.Extensions
{
    public static class ExtensionHelper
    {
        public static string SerializeToJson(this object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.All;
            return JsonConvert.SerializeObject(obj, settings).Replace("\\u0027", "\u0027");
        }

        public static string Serialize<T>(this T obj) where T : class, new()
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize((TextWriter)writer, obj);
                return writer.ToString();
            }
        }

        public static T SaveChanges<T>(this DbContext context, T entity) where T : class
        {
            if (entity == null)
                throw new ArgumentException("Cannot add a null entity.");
            var recordAdded = context.Set<T>().Add(entity);
            context.SaveChanges();
            return recordAdded;
        }

        public static string ConvertXML(this string pXml, string pXslFilePath)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(pXml);
            StringWriter writer = new StringWriter();
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(pXslFilePath);
            transform.Transform((IXPathNavigable)document.CreateNavigator(), null, (TextWriter)writer);
            return writer.ToString();
        }

        public static string SendEmail(string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";

            string senderID = System.Configuration.ConfigurationManager.AppSettings["EmailId"]; ;// use sender's email id here..
            string senderPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPwd"]; // sender password here...

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here...
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                    

                };

                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                message.IsBodyHtml = true;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }

            return result;
        }

    }
}