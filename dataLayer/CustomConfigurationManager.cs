using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer
{
    public class CustomConfigurationManager
    {
        public string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
        public string patron = ConfigurationManager.AppSettings["Patron"].ToString();
    }
}
