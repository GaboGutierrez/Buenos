using Gabo.Escuela.Business;
using Gabo.Escuela.Business.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                List<string> acceso = new List<string>();
                Session["Acceso"] = acceso;
                LlenarDDLSexo();
                LlenarDDLPerfil();
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    private void LlenarDDLPerfil()
    {
        try
        {
            ddlPerfilModal.DataSource = new BusAlumno().MostrarPerfil();
            ddlPerfilModal.DataTextField = "Nombre";
            ddlPerfilModal.DataValueField = "Id";
            ddlPerfilModal.DataBind();
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
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Inicio.aspx");
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            EntAlumno ent = new BusAlumno().ObtenerAcceso(txtUsuario.Text, txtPassword.Text);
            if (ent != null)
            {
                Session["Acceso"] = ent;
                Response.Redirect("Principal.aspx");
            }
        }
        catch (Exception ex)
        {
            imgNoUsuario.Visible = true;
            MostrarMensaje(ex.Message);
        }
    }
    private void MostrarMensaje(string p)
    {
        p = p.Replace("/n", "").Replace("/r", "").Replace("'", "");
        string mensaje = "alert('" + p + "')";
        ScriptManager.RegisterStartupScript(this, GetType(), "", mensaje, true);
    }
    protected void btnAgregarRegistro_Click(object sender, EventArgs e)
    {
        try
        {
            EntAlumno alumno = new EntAlumno();
            alumno.Nombre = txtNombreModal.Text.Trim();
            alumno.Paterno = txtPaternoModal.Text.Trim() == "" ? "XX" : txtPaternoModal.Text.Trim();
            alumno.Materno = txtMaternoModal.Text.Trim();
            alumno.Nacimiento = Convert.ToDateTime(txtFechaNacimientoModal.Text);
            alumno.SexoId = ddlSexo.SelectedIndex;
            alumno.FechaRegistro = DateTime.Now;
            alumno.Correo = txtCorreoModal.Text.Trim();
            alumno.Promedio = Convert.ToDouble(txtPromedioModal.Text.Trim());
            string cadena = "perro";
            

            //for (int i = 0; i > 1; i++)
            //{
            //    cadena += "G";
            //    cadena += ent.Nombre[i].ToString();
            //    cadena += ent.Paterno[i].ToString();
            //    cadena += ent.Materno[i].ToString();
            //    cadena += ent.Nacimiento.Year;
            //    i++;
            //}
            alumno.Matricula = cadena;
            alumno.EtapaId = 1;
            alumno.PerfilId = ddlPerfilModal.SelectedIndex;
            alumno.Password = txtPasswordDosModal.Text.Trim();
            new BusAlumno().AgregarRegistro(alumno);
            Response.Redirect(Request.CurrentExecutionFilePath);

        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
    protected void ddlPerfilModal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //ddlPerfilModal.Attributes.Add("data-toggle", "modal");
            //ddlPerfilModal.Attributes.Add("data-target", "#modRegistro");
            //ddlPerfilModal.Attributes.Add("runat", "server");
            if (ddlPerfilModal.SelectedIndex == 1)
            {
                btnAgregarRegistro.Enabled = true;
            }
            if (ddlPerfilModal.SelectedIndex == 2)
            {
                btnAgregarRegistro.Enabled = false;
                txtUsuaAdmiModal.Visible = true;
                txtPassAdmiModal.Visible = true;
                btnAutoAdmiModal.Visible = true;
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }

    }
    protected void btnAutoAdmiModal_Click(object sender, EventArgs e)
    {
        try
        {
            EntAlumno ent = new BusAlumno().ObtenerAcceso(txtUsuaAdmiModal.Text, txtPassAdmiModal.Text);
            if (ent != null)
            {
                if (ent.PerfilId == 1)
                {
                    btnAgregarRegistro.Enabled = false;
                    MostrarMensaje("El usuario ingresado no es administrador y tu no puedes asignarte como administrador.");
                }
                else if (ent.PerfilId == 2)
                {
                    MostrarMensaje("Adelante, acceso autorizado para darte de alta como administrador.");
                    btnAgregarRegistro.Enabled = true;
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            MostrarMensaje(ex.Message);
        }
    }
}