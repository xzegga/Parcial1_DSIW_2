using System.Configuration;

namespace dataLayer
{
    public class CustomConfigurationManager
    {
        public string connection = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
        public string patron = ConfigurationManager.AppSettings["Patron"].ToString();
    }
}
