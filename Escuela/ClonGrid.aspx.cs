using Gabo.Escuela.Business;
using Gabo.Escuela.Business.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClonGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string LlenarDdlPagos()
    {
        List<EntTipoPago> ent = new BusAlumno().MostrarTipoPago();
        JavaScriptSerializer oSerializer = new JavaScriptSerializer();
        string json = oSerializer.Serialize(ent);
        return json;
    }

    [WebMethod]
    public static string LlenarGridAlumnos()
    {
        List<EntAlumno> lst = new BusAlumno().Mostrar();     
        string json = new JavaScriptSerializer().Serialize(lst);
        return json;
    }   
}