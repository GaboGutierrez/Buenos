using Gabo.Escuela.Business.Entidad;
using Gabo.Escuela.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabo.Escuela.Business
{
    public class BusAlumno
    {
        public List<EntAlumno> Mostrar()
        {
            List<EntAlumno> lst = new List<EntAlumno>();
            DataTable dt = new DataTable();
            dt = new DatAlumno().ObtenerAlumnos();
            foreach (DataRow dr in dt.Rows)
            {
                EntAlumno ent = new EntAlumno();
                ent.Id = Convert.ToInt32(dr["ALUM_ID"]);
                ent.Nombre = String.Format("{0} {1} {2}", dr["ALUM_NOMB"].ToString(), dr["ALUM_APAT"].ToString(), dr["ALUM_AMAT"].ToString()); //
                ent.Paterno = dr["ALUM_APAT"].ToString();//
                ent.Materno = dr["ALUM_AMAT"].ToString();//
                ent.Nacimiento = Convert.ToDateTime(dr["ALUM_FNAC"]);
                ent.SexoId = Convert.ToInt32(dr["ALUM_SEXO_ID"]);
                ent.Sexo.Id = Convert.ToInt32(dr["SEXO_ID"]);
                ent.Sexo.Nombre = dr["SEXO_NOMB"].ToString();//
                ent.FechaRegistro = Convert.ToDateTime(dr["ALUM_FREG"]);//
                ent.Correo = dr["ALUM_MAIL"].ToString();//
                ent.Promedio = Convert.ToInt32(dr["ALUM_PRGR"]);
                ent.Matricula = dr["ALUM_MATR"].ToString();//
                ent.DocumentoId = Convert.ToInt32(dr["DOCS_ID"]);
                ent.Documento.AlumnoId = Convert.ToInt32(dr["DOCS_ALUM_ID"]);
                ent.Documento.Nombre = dr["DOCS_NOMB"].ToString();//
                ent.Documento.Tipo = dr["DOCS_TIPO"].ToString();//
                ent.Documento.Aprobado = Convert.ToBoolean(dr["DOCS_APRO"]);//
                ent.Documento.FechaAlta = Convert.ToDateTime(dr["DOCS_FECH_ALTA"]);
                ent.ExamenPsicoId = Convert.ToInt32(dr["ALUM_EXPS_ID"]);
                ent.ExamPsico.Id = Convert.ToInt32(dr["EXPS_ID"]);
                ent.ExamPsico.RespUno = Convert.ToInt32(dr["EXPS_RESP_UNO"]);
                ent.ExamPsico.RespDos = Convert.ToInt32(dr["EXPS_RESP_DOS"]);
                ent.ExamPsico.RespTres = Convert.ToInt32(dr["EXPS_RESP_TRES"]);
                ent.ExamPsico.RespCuatro = Convert.ToInt32(dr["EXPS_RESP_CUAT"]);
                ent.ExamPsico.FechaAplicacion = Convert.ToDateTime(dr["EXPS_FECH_APLI"]);
                ent.ExamPsico.Estatus = Convert.ToBoolean(dr["EXPS_ESTA"]);//
                ent.EtapaId = Convert.ToInt32(dr["ALUM_ETAP_ID"]);//
                ent.Etapa.Id = Convert.ToInt32(dr["ETAP_ID"]);
                ent.Etapa.Nombre = dr["ETAP_NOMB"].ToString();//
                ent.Etapa.Descripcion = dr["ETAP_DESC"].ToString();
                ent.Examen.Id = Convert.ToInt32(dr["EXAM_ID"]);
                ent.Examen.AlumnoId = Convert.ToInt32(dr["EXAM_ALUM_ID"]);
                ent.Examen.RespUno = dr["EXAM_RESP_UNO"].ToString();
                ent.Examen.RespDos = Convert.ToDouble(dr["EXAM_RESP_DOS"]);
                ent.Examen.RespTres = Convert.ToBoolean(dr["EXAM_RESP_TRES"]);
                ent.Examen.RespCuatro = Convert.ToDateTime(dr["EXAM_RESP_CUAT"]);
                ent.Examen.FechaAplicacion = Convert.ToDateTime(dr["EXAM_FECH_APLI"]);
                ent.Examen.Calificacion = Convert.ToDouble(dr["EXAM_CALI"]);//
                ent.Examen.Aprobado = Convert.ToBoolean(dr["EXAM_APRO"]);//
                ent.Pago.Id = Convert.ToInt32(dr["PAGO_ID"]);
                ent.Pago.AlumnoId = Convert.ToInt32(dr["PAGO_ALUM_ID"]);
                ent.Pago.FechaPago = Convert.ToDateTime(dr["PAGO_FECH"]);//
                ent.Pago.Cantidad = Convert.ToDouble(dr["PAGO_CANT"]);//
                ent.Pago.Descripcion = dr["PAGO_DESC"].ToString();
                ent.Pago.TipoPago.Id = Convert.ToInt32(dr["PAGO_TIPO_PAGO_ID"]);
                ent.Pago.TipoPago.Nombre = dr["TIPO_PAGO_NOMB"].ToString();//
                ent.Pago.TipoPago.Descripcion = dr["TIPO_PAGO_DESC"].ToString();
                ent.PerfilId = Convert.ToInt32(dr["ALUM_PERF_ID"]);
                ent.Perfil.Id = Convert.ToInt32(dr["PERF_ID"]);
                ent.Perfil.Nombre = dr["PERF_NOMB"].ToString();
                ent.Password = dr["ALUM_PASS"].ToString();
                lst.Add(ent);
            }
            return lst;

        }
        public List<EntSexo> MostrarSexo()
        {
            List<EntSexo> lst = new List<EntSexo>();
            DataTable dt = new DataTable();
            dt = new DatAlumno().ObtenerSexo();
            foreach (DataRow dr in dt.Rows)
            {
                EntSexo ent = new EntSexo();
                ent.Id = Convert.ToInt32(dr["SEXO_ID"]);
                ent.Nombre = dr["SEXO_NOMB"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
        public List<EntEtapa> MostrarEtapas()
        {
            List<EntEtapa> lst = new List<EntEtapa>();
            DataTable dt = new DataTable();
            dt = new DatAlumno().ObtenerEtapas();
            foreach (DataRow dr in dt.Rows)
            {
                EntEtapa ent = new EntEtapa();
                ent.Id = Convert.ToInt32(dr["ETAP_ID"]);
                ent.Nombre = dr["ETAP_NOMB"].ToString();
                ent.Descripcion = dr["ETAP_DESC"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
        public List<EntTipoPago> MostrarTipoPago()
        {
            List<EntTipoPago> lst = new List<EntTipoPago>();
            DataTable dt = new DataTable();
            dt = new DatAlumno().ObtenerTipoPago();
            foreach (DataRow dr in dt.Rows)
            {
                EntTipoPago ent = new EntTipoPago();
                ent.Id = Convert.ToInt32(dr["TIPO_PAGO_ID"]);
                ent.Nombre = dr["TIPO_PAGO_NOMB"].ToString();
                ent.Descripcion = dr["TIPO_PAGO_DESC"].ToString();
                lst.Add(ent);
            }
            return lst;
        }



    }
}
