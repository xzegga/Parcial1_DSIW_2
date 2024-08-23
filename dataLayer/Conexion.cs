using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLayer
{
    public class Conexion
    {
        public static string cnn = ConfigurationManager.ConnectionStrings["ConexionSql"].ToString();
    }
}
