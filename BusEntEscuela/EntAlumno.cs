using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabo.Escuela.Business.Entidad
{
    public class EntAlumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public DateTime Nacimiento { get; set; }
        private EntSexo sexo;
        public EntSexo Sexo
        {
            get
            {
                if (sexo == null)
                    sexo = new EntSexo();
                return sexo;
            }
            set
            {
                if (sexo == null)
                    sexo = new EntSexo();
                sexo = value;
            }
        }
        public DateTime FechaRegistro { get; set; }
        public string Correo { get; set; }
        public double Promedio { get; set; }
        public string Matricula { get; set; }
        private EntExamPsico ExamPsico;
        public EntExamPsico exampsico
        {
            get
            {
                if (exampsico == null)
                    exampsico = new EntExamPsico();
                return ExamPsico;
            }
            set
            {
                if (exampsico == null)
                    exampsico = new EntExamPsico();
                ExamPsico = value;
            }
        }
        private EntEtapa Etapa;
        public EntEtapa etapa
        {
            get
            {
                if (etapa == null)
                    etapa = new EntEtapa();
                return Etapa;
            }
            set
            {
                if (etapa == null)
                    etapa = new EntEtapa();
                Etapa = value;
            }
        }
        private EntPerfil Perfil;
        public EntPerfil perfil
        {
            get
            {
                if (perfil == null)
                    perfil = new EntPerfil();
                return Perfil;
            }
            set
            {
                if (perfil == null)
                    perfil = new EntPerfil();
                Perfil = value;
            }
        }
        public string Password { get; set; }
    }
    public class EntSexo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class EntExamPsico
    {
        public int Id { get; set; }
        public int RespUno { get; set; }
        public int RespDos { get; set; }
        public int RespTres { get; set; }
        public int RespCuatro { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public bool Estatus { get; set; }
    }
    public class EntEtapa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class EntPerfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class EntDocumentos
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool Aprobado { get; set; }
        public DateTime FechaAlta { get; set; }
    }
    public class EntPago
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public DateTime FechaPago { get; set; }
        public double Cantidad { get; set; }
        public string Descripcion { get; set; }
        private EntTipoPago TipoPago;
        public EntTipoPago tipopago
        {
            get
            {
                if (tipopago == null)
                    tipopago = new EntTipoPago();
                return TipoPago;
            }
            set
            {
                if (tipopago == null)
                    tipopago = new EntTipoPago();
                TipoPago = value;
            }
        }
    }
    public class EntTipoPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class EntExamen
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public string RespUno { get; set; }
        public double RespDos { get; set; }
        public bool RespTres { get; set; }
        public DateTime RespCuatro { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public double Calificacion { get; set; }
        public bool Aprobado { get; set; }
    }
}
