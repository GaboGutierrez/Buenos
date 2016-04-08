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
        if (!IsPostBack)
        {

            CargarGrid();
            LlenarDDLSexo();
            LlenarDDLTipoPago();
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
    private void LlenarDDLSexo()
    {
        try
        {
            ddlSexo.DataSource = new BusAlumno().MostrarSexo();
            ddlSexo.DataTextField = "Nombre";
            ddlSexo.DataValueField = "Id";
            ddlSexo.DataBind();
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
            CargarGrid();

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
                            lnkExamPsic.Text = "Presentar Examen";
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            lnkDocu.Visible = false;
                            LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                            lnkPago.Visible = false;
                            LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                            lnkExam.Visible = false;
                            Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                            lblCierre.Text = "Examen Psicométrico";
                            break;
                        }
                    case 2:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.Enabled = false;
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            if (ent.ExamPsico.Estatus)
                            {
                                LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                                lnkDocu.Text = "Cargar Archivo";
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
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
                                lblCierre.Text = "Rechazado <br /> No aprobó Examen Psico";
                            }

                            break;
                        }
                    case 3:
                        {
                            LinkButton lnkExamPsic = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExamPsic");
                            string resultado = ent.ExamPsico.Estatus == false ? "Reprobado" : "Aprobado";
                            lnkExamPsic.Enabled = false;
                            lnkExamPsic.ForeColor = ent.ExamPsico.Estatus == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            lnkExamPsic.Text = ent.ExamPsico.FechaAplicacion.ToString("dd/MM/yy") + "<br />" + resultado;
                            LinkButton lnkDocu = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkDocu");
                            string cargado = ent.Documento.Aprobado == false ? "No hay documento" : "Cargado";
                            lnkDocu.Enabled = false;
                            lnkDocu.ForeColor = ent.Documento.Aprobado == false ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                            //lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString();
                            if (ent.Documento.Aprobado)
                            {
                                lnkDocu.Text = ent.Documento.FechaAlta.ToString("dd/MM/yy") + "<br/>" + ent.Documento.Nombre.ToString() + "<br/>" + ent.Documento.Tipo.ToString();
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Realizar Pago";
                            }
                            else
                            {
                                LinkButton lnkPago = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkPago");
                                lnkPago.Visible = false;
                                LinkButton lnkExam = (LinkButton)gvEscuela.Rows[contador].FindControl("lnkExam");
                                lnkExam.Visible = false;
                                Label lblCierre = (Label)gvEscuela.Rows[contador].FindControl("lblCierre");
                                lblCierre.Text = "Falta documentación";
                            }




                            break;
                        }
                    default: { break; }

                }
                contador++;
            }

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void CargarGV()
    {
        try
        {
            gvPrueba.DataSource = new BusAlumno().Mostrar();
            gvPrueba.DataBind();

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }

    private void MostrarMensaje(string p)
    {
        string mensaje = "Error: " + p;
        ScriptManager.RegisterStartupScript(this, GetType(), "", mensaje, true);
    }

}