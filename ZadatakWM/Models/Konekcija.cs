using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ZadatakWM.Models
{
    public class Konekcija
    {
        public static string KonekcioniString(string konekcija ="DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[konekcija].ConnectionString;
        }
    }
}