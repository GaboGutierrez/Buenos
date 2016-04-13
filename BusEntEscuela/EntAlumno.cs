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
        public int SexoId { get; set; }
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
        public string fRegistro { get; set; }
        public string Correo { get; set; }
        public double Promedio { get; set; }
        public string Matricula { get; set; }
        public int DocumentoId { get; set; }
        private EntDocumentos documento;

        public EntDocumentos Documento
        {
            get
            {
                if (documento == null)
                    documento = new EntDocumentos();
                return documento;
            }
            set
            {
                if (documento == null)
                    documento = new EntDocumentos();
                documento = value;
            }
        }


        public int ExamenPsicoId { get; set; }
        private EntExamPsico examPsico;
        public EntExamPsico ExamPsico
        {
            get
            {
                if (examPsico == null)
                    examPsico = new EntExamPsico();
                return examPsico;
            }
            set
            {
                if (examPsico == null)
                    examPsico = new EntExamPsico();
                examPsico = value;
            }
        }
        public int EtapaId { get; set; }
        private EntEtapa etapa;
        public EntEtapa Etapa
        {
            get
            {
                if (etapa == null)
                    etapa = new EntEtapa();
                return etapa;
            }
            set
            {
                if (etapa == null)
                    etapa = new EntEtapa();
                etapa = value;
            }
        }
        public int PerfilId { get; set; }
        private EntPerfil perfil;
        public EntPerfil Perfil
        {
            get
            {
                if (perfil == null)
                    perfil = new EntPerfil();
                return perfil;
            }
            set
            {
                if (perfil == null)
                    perfil = new EntPerfil();
                perfil = value;
            }
        }
        public string Password { get; set; }


        public int PagoId { get; set; }
        private EntPago pago;

        public EntPago Pago
        {
            get
            {
                if (pago == null)
                    pago = new EntPago();
                return pago;
            }
            set
            {
                if (pago == null)
                    pago = new EntPago();
                pago = value;
            }
        }


        public int ExamenId { get; set; }
        private EntExamen examen;

        public EntExamen Examen
        {
            get
            {
                if (examen == null)
                    examen = new EntExamen();
                return examen;
            }
            set
            {
                if (examen == null)
                    examen = new EntExamen();
                examen = value;
            }
        }

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
        public int TipoPagoId { get; set; }
        private EntTipoPago tipopago;
        public EntTipoPago TipoPago
        {
            get
            {
                if (tipopago == null)
                    tipopago = new EntTipoPago();
                return tipopago;
            }
            set
            {
                if (tipopago == null)
                    tipopago = new EntTipoPago();
                tipopago = value;
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
