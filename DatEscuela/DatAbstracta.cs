using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabo.Escuela.Data
{
    public class DatAbstracta
    {
        public SqlConnection con;
        public DatAbstracta()
        {
            con = new SqlConnection("Data Source = CASALAP; User Id=sa; Password=12345; Initial Catalog=Escuela;");

        }
    }
}
