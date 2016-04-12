using Gabo.Escuela.Business;
using Gabo.Escuela.Business.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            EntAlumno entAcceso = (EntAlumno)Session["Acceso"];

            if (entAcceso != null)
            {
                Label label = (Label)Master.FindControl("lblMasterTitulo");
                if (entAcceso.PerfilId == 1)
                {
                    label.Text = String.Format("Bienvenido {0} {1}, {2}, tu matrícula es: {3}", entAcceso.Perfil.Nombre.ToString(), entAcceso.Nombre.ToString(), entAcceso.Paterno.ToString(), entAcceso.Matricula.ToString());
                    label.Visible = true;
                    LinkButton lkbCierre = (LinkButton)Master.FindControl("lkbMasterCierre");
                    lkbCierre.Visible = true;
                    CargarGrid(entAcceso.Id);
                }
                if (entAcceso.PerfilId == 2)
                {
                    label.Text = String.Format("Bienvenido {0} {1}, {2}", entAcceso.Perfil.Nombre.ToString(), entAcceso.Nombre.ToString(), entAcceso.Paterno.ToString());
                    label.Visible = true;
                    LinkButton lkbCierre = (LinkButton)Master.FindControl("lkbMasterCierre");
                    lkbCierre.Visible = true;
                    CargarGrid();
                }

            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }

            if (!IsPostBack)
            {
                LlenarDDLTipoPago();
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void CargarGrid()
    {
        try
        {
            List<EntAlumno> lst = new BusAlumno().Mostrar();
            gvEscuela.DataSource = lst;
            gvEscuela.DataBind();
            int contador = 0;
            foreach (EntAlumno ent in lst)
            {
                switch (ent.EtapaId)
                {
                    case 1:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            lnkExamPsic.Attributes.Add("data-toggle", "modal");
                            lnkExamPsic.Attributes.Add("data-target", "#modPsicometrico");
                            lnkExamPsic.Attributes.Add("runat", "server");
                            lnkExamPsic.Text = "Presentar Examen";
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            lnkDocu.Visible = false;
                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            lnkPago.Visible = false;
                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            lnkExam.Visible = false;
                            Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                            lblCierre.ForeColor = System.Drawing.Color.Green;
                            lblCierre.Text = "Examen Psicométrico";
                            break;
                        }
                    case 2:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;
                            if (ent.ExamPsico.Estatus)
                            {
                                LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                                lnkDocu.Attributes.Add("data-toggle", "modal");
                                lnkDocu.Attributes.Add("data-target", "#modDocumentos");
                                lnkDocu.Attributes.Add("runat", "server");
                                lnkDocu.Text = "Cargar Archivo";
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                                lblCierre.Text = "Recabar Documentos";
                            }
                            else
                            {
                                LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                                lnkDocu.Visible = false;
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "Rechazado. <br /> No aprobó Examen Psicométrico.";
                            }
                            break;
                        }
                    case 3:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento" : "Cargado";
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString() + "<br/>" + cargado;
                            lnkDocu.Enabled = false;
                            if (ent.Documento.Aprobado)
                            {
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Attributes.Add("data-toggle", "modal");
                                lnkPago.Attributes.Add("data-target", "#modPagos");
                                lnkPago.Attributes.Add("runat", "server");
                                lnkPago.Text = "Realizar un pago";
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Pagos";
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "Aún no entrega documentación";
                            }
                            break;
                        }
                    case 4:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;

                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento" : "Cargado";
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString() + "<br/>" + cargado;
                            lnkDocu.Enabled = false;

                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            string pago = ent.Pago.AlumnoId == 0 ? "No hay pago registrado" : "Pago registrado";
                            lnkPago.ForeColor = ent.Pago.AlumnoId == 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkPago.Text = ent.Pago.FechaPago.ToString("dd/MM/yy") + "<br/>" + ent.Pago.Cantidad + " pesos" + "<br/>" + pago;
                            lnkPago.ToolTip = ent.Pago.TipoPago.Nombre;
                            lnkPago.Enabled = false;

                            if (ent.Pago.Id != 0)
                            {
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Attributes.Add("data-toggle", "modal");
                                lnkExam.Attributes.Add("data-target", "#modExamen");
                                lnkExam.Attributes.Add("runat", "server");
                                lnkExam.Text = "Presentar Examen";
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Examen Conocimientos Generales";
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "No ha sido registrado su pago";
                            }
                            break;
                        }

                    case 5:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;

                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento." : "Guardado.";
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString() + "<br/>" + cargado;
                            lnkDocu.Enabled = false;

                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            string pago = ent.Pago.AlumnoId == 0 ? "No hay pago registrado" : "Pago registrado";
                            lnkPago.ForeColor = ent.Pago.AlumnoId == 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkPago.Text = ent.Pago.FechaPago.ToString("dd/MM/yy") + "<br/>" + ent.Pago.Cantidad + " pesos" + "<br/>" + pago;
                            lnkPago.ToolTip = ent.Pago.TipoPago.Nombre;
                            lnkPago.Enabled = false;

                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            string calificacion = ent.Examen.Aprobado == false ? "No Aprobó" : "Aprobado";
                            lnkExam.ForeColor = ent.Examen.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExam.Text = ent.Examen.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + calificacion;
                            lnkExam.Enabled = false;

                            if (ent.Examen.Aprobado)
                            {
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Aceptado. <br/> Ha concluido la inscripción.";
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "Rechazado." + " <br />" + "No aprobó Examen de conocimientos generales.";
                            }
                            break;
                        }
                    default:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            lnkExamPsic.Visible = false;
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            lnkDocu.Visible = false;
                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            lnkPago.Visible = false;
                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            lnkExam.Visible = false;
                            Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                            lblCierre.Text = "Hay un error en tu registro. <br/> Contacta con un administrador.";
                            lblCierre.ForeColor = System.Drawing.Color.Fuchsia;
                            break;
                        }
                }
                contador++;
                lblAlumno.Text += "El alumno: " + ent.Nombre + " tiene la etapa num: " + ent.EtapaId + "<br/>";
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void CargarGrid(int id)
    {
        try
        {
            List<EntAlumno> lst = new BusAlumno().Mostrar(id);
            gvEscuela.DataSource = lst;
            gvEscuela.DataBind();
            int contador = 0;
            foreach (EntAlumno ent in lst)
            {
                switch (ent.EtapaId)
                {
                    case 1:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            lnkExamPsic.Attributes.Add("data-toggle", "modal");
                            lnkExamPsic.Attributes.Add("data-target", "#modPsicometrico");
                            lnkExamPsic.Attributes.Add("runat", "server");
                            lnkExamPsic.Text = "Presentar Examen";
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            lnkDocu.Visible = false;
                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            lnkPago.Visible = false;
                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            lnkExam.Visible = false;
                            Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                            lblCierre.ForeColor = System.Drawing.Color.Green;
                            lblCierre.Text = "Examen Psicométrico";
                            break;
                        }
                    case 2:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;
                            if (ent.ExamPsico.Estatus)
                            {
                                LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                                lnkDocu.Attributes.Add("data-toggle", "modal");
                                lnkDocu.Attributes.Add("data-target", "#modDocumentos");
                                lnkDocu.Attributes.Add("runat", "server");
                                lnkDocu.Text = "Cargar Archivo";
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                                lblCierre.Text = "Recabar Documentos";
                            }
                            else
                            {
                                LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                                lnkDocu.Visible = false;
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "Rechazado. <br /> No aprobó Examen Psicométrico.";
                            }
                            break;
                        }
                    case 3:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento" : "Cargado";
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString() + "<br/>" + cargado;
                            lnkDocu.Enabled = false;
                            if (ent.Documento.Aprobado)
                            {
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Attributes.Add("data-toggle", "modal");
                                lnkPago.Attributes.Add("data-target", "#modPagos");
                                lnkPago.Attributes.Add("runat", "server");
                                lnkPago.Text = "Realizar un pago";
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Pagos";
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "Aún no entrega documentación";
                            }
                            break;
                        }
                    case 4:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;

                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento" : "Cargado";
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString() + "<br/>" + cargado;
                            lnkDocu.Enabled = false;

                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            string pago = ent.Pago.AlumnoId == 0 ? "No hay pago registrado" : "Pago registrado";
                            lnkPago.ForeColor = ent.Pago.AlumnoId == 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkPago.Text = ent.Pago.FechaPago.ToString("dd/MM/yy") + "<br/>" + ent.Pago.Cantidad + " pesos" + "<br/>" + pago;
                            lnkPago.ToolTip = ent.Pago.TipoPago.Nombre;
                            lnkPago.Enabled = false;

                            if (ent.Pago.Id != 0)
                            {
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Attributes.Add("data-toggle", "modal");
                                lnkExam.Attributes.Add("data-target", "#modExamen");
                                lnkExam.Attributes.Add("runat", "server");
                                lnkExam.Text = "Presentar Examen";
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Examen Conocimientos Generales";
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "No ha sido registrado su pago";
                            }
                            break;
                        }

                    case 5:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            lnkExamPsic.Enabled = false;

                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento." : "Guardado.";
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString() + "<br/>" + cargado;
                            lnkDocu.Enabled = false;

                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            string pago = ent.Pago.AlumnoId == 0 ? "No hay pago registrado" : "Pago registrado";
                            lnkPago.ForeColor = ent.Pago.AlumnoId == 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkPago.Text = ent.Pago.FechaPago.ToString("dd/MM/yy") + "<br/>" + ent.Pago.Cantidad + " pesos" + "<br/>" + pago;
                            lnkPago.ToolTip = ent.Pago.TipoPago.Nombre;
                            lnkPago.Enabled = false;

                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            string calificacion = ent.Examen.Aprobado == false ? "No Aprobó" : "Aprobado";
                            lnkExam.ForeColor = ent.Examen.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExam.Text = ent.Examen.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + calificacion;
                            lnkExam.Enabled = false;

                            if (ent.Examen.Aprobado)
                            {
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Aceptado. <br/> Ha concluido la inscripción.";
                                lblCierre.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.ForeColor = System.Drawing.Color.OrangeRed;
                                lblCierre.Text = "Rechazado." + " <br />" + "No aprobó Examen de conocimientos generales.";
                            }
                            break;
                        }
                    default:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            lnkExamPsic.Visible = false;
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            lnkDocu.Visible = false;
                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            lnkPago.Visible = false;
                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            lnkExam.Visible = false;
                            Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                            lblCierre.Text = "Hay un error en tu registro. <br/> Contacta con un administrador.";
                            lblCierre.ForeColor = System.Drawing.Color.Fuchsia;
                            break;
                        }
                }
                contador++;
                lblAlumno.Text += "El alumno: " + ent.Nombre + " tiene la etapa num: " + ent.EtapaId + "<br/>";
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void LlenarDDLTipoPago()
    {
        try
        {
            ddlTipoPago.DataSource = new BusAlumno().MostrarTipoPago();
            ddlTipoPago.DataTextField = "Nombre";
            ddlTipoPago.DataValueField = "Id";
            ddlTipoPago.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }


    private void MostrarMensaje(string p)
    {
        p = p.Replace("/n", "").Replace("/r", "").Replace("'", "");
        string mensaje = "alert('" + p + "')";
        ScriptManager.RegisterStartupScript(this, GetType(), "", mensaje, true);
    }
    protected void btnAgregarDocumentos_Click(object sender, EventArgs e)
    {
        EntAlumno entAcceso = (EntAlumno)Session["Acceso"];


    }
}