using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class bdConnection
    {
        private string user = "p9g5";
        private string password = "-737279605@BD";

        public SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;User ID="+this.user+";Password="+this.password);
        }

    }
}
