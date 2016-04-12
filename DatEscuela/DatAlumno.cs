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
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerAlumnos(int id)
        {
            SqlCommand com = new SqlCommand("spMostrarAlumnoId", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Id", Value = id, SqlDbType = SqlDbType.Int });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerSexo()
        {
            SqlCommand com = new SqlCommand("spObtenerSexo", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerEtapas()
        {
            SqlCommand com = new SqlCommand("spObtenerEtapas", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerTipoPago()
        {
            SqlCommand com = new SqlCommand("spObtenerTipoPago", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerAcceso(string correo, string password)
        {
            SqlCommand com = new SqlCommand("spAcceso", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Correo", Value = correo, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Password", Value = password, SqlDbType = SqlDbType.NVarChar });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ObtenerPerfil()
        {
            SqlCommand com = new SqlCommand("spObtenerPerfil", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int AgregarRegistro(string nombre, string paterno, string materno, DateTime nacimiento, int sexoId, DateTime fechaRegistro, string correo, double promedio, string matricula, int etapaId, int perfilId, string password)
        {
            SqlCommand com = new SqlCommand("spRegistrarAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Nombre", Value = nombre, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Paterno", Value = paterno, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Materno", Value = materno, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Nacimiento", Value = nacimiento, SqlDbType = SqlDbType.Date });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@SexoId", Value = sexoId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@FechaRegistro", Value = fechaRegistro, SqlDbType = SqlDbType.SmallDateTime });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Correo", Value = correo, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Promedio", Value = promedio, SqlDbType = SqlDbType.Decimal });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Matricula", Value = matricula, SqlDbType = SqlDbType.NVarChar });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@EtapaId", Value = etapaId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@PerfilId", Value = perfilId, SqlDbType = SqlDbType.Int });
            com.Parameters.Add(new SqlParameter() { ParameterName = "@Password", Value = password, SqlDbType = SqlDbType.NVarChar });
            try
            {
                con.Open();
                int fila = com.ExecuteNonQuery();
                con.Close();
                return fila;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error en la capa de datos, " + ex.Message);
            }



        }
    }
}
