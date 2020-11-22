using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ZadatakWM.Models;

namespace ZadatakWM.Services
{
    public class DalServiceFactory
    {
        public static IDalService GetDalService()
        {
            string rez = ConfigurationManager.AppSettings["isJSON"].ToString();

            if (rez == "true")
            {
                return new ProizvodJSONDAL();
            }
            else
            {
                return new ProizvodDAL();
            }


        }
    }
}