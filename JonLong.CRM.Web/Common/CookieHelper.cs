using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonLong.CRM.Web.Common
{
    public class CookieHelper
    {
        public static void Set(string key, string value)
        {
            var userCookie = new HttpCookie(key, value);
            userCookie.Expires.AddHours(24);
            HttpContext.Current.Response.SetCookie(userCookie);
        }

        public static void Set(string key, object value, int validHours)
        {
            string json = JsonConvert.SerializeObject(value);
            var cookie = new HttpCookie(key, json);
            cookie.Expires.AddHours(validHours);
            HttpContext.Current.Response.SetCookie(cookie);
        }

        public static string Get(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null && !String.IsNullOrEmpty(cookie.Value))
            {
                return cookie.Value;
            }
            return String.Empty;
        }

        public static T Get<T>(string key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null && !String.IsNullOrEmpty(cookie.Value))
            {
                return JsonConvert.DeserializeObject<T>(cookie.Value);
            }

            return default(T);
        }

    }
}