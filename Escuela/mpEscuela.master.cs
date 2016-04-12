using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mpEscuela : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lkbMasterCierre_Click(object sender, EventArgs e)
    {
        try
        {
            lblMasterTitulo.Text = "";
            lblMasterTitulo.Visible = false;
            lkbMasterCierre.Visible = false;
            Session.Clear();
            Response.Redirect("Inicio.aspx");
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
