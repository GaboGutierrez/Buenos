using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabo.Escuela.Data
{
    public class DatAlumno : DatAbstracta
    {
        public DataTable ObtenerAlumnos()
        {
            SqlCommand com = new SqlCommand("spMostrarAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            return dt;
        }
    }
}
