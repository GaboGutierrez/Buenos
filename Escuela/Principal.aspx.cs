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

        }
    }

    private void CargarGrid()
    {
        try
        {

            //gvEscolar.DataBind();
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