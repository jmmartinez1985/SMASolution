using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}