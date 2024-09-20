using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Canine_RMS_2._0
{
    internal class ClassDB
    {
        public static MySqlConnection GetCon()
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("Server=localhost; database=crms; uid=root");
                return cn;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
    }
}
