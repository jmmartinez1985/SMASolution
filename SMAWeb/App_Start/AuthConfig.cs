﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using SMAWeb.Models;

namespace SMAWeb
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: ""); 


            //Se debe actualizar estos credenciales por los reales.
            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "65enEdbTTtPbqhTJ3YxMDQ",
                consumerSecret: "hCgzdBLOdorYyjQXTbT2xD0uBpIg78xhuibpYxJV7eg");
                //consumerKey: "nHJFMdJ1sAEFZGP5QAoHDA",
                //consumerSecret: "aRYoXnvom6COSdRA3PQ8Cqot1UkKwB9OyFS6GGr5UC8");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "530931017003510",
                appSecret: "aaa0a1753d6d3143e8b0c2403c625cdd");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
