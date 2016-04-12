<%@ Page Title="" Language="C#" MasterPageFile="~/mpEscuela.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container  ">
        <div class="row">
            <div class="col-md-6">
                <asp:Image ImageUrl="~/img/no_encontrado.png" Visible="false" runat="server" ID="imgNoUsuario" />
            </div>
            <div class="col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-4">
                                <h4 style="text-align: center;">Acceso: 
                                </h4>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox class="form-control" ID="txtUsuario" runat="server" Placeholder="Ingresa tu correo." />
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox class="form-control" ID="txtPassword" runat="server" placeholder="Contraseña."
                                    TextMode="Password" />
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer text-center">
                        <div class="row">
                            <div class="col-xs-4">
                                <label class="btn btn-warning" data-toggle="modal" data-target="#modRegistro">Nuevo Usuario</label>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button class="btn btn-default" Text="Cancelar" ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" />
                            </div>
                            <div class="col-xs-4">
                                <asp:Button class="btn btn-info" Text="Aceptar" ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Primer modal para el registro --%>
    <!-- Modal -->
    <div class="container">
        <div class="modal fade bs-example-modal-lg" id="modRegistro" data-backdrop="static" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Registro</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-3">
                                <%--<div class="input-group">aqui hay que darle una buena vista.... </div>--%>
                                <br />
                                <label>Ingresa tu nombre </label>
                                <br />
                                <asp:TextBox runat="server" ID="txtNombreModal" Placeholder="Ingresa tu nombre." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <%--<input type="type" name="name" value=" " />--%>
                                <label>Apellido Paterno </label>
                                <br />
                                <asp:TextBox runat="server" ID="txtPaternoModal" Placeholder="Ingresa tu Apellido Paterno." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtMaternoModal" Placeholder="Ingresa tu Apellido Materno." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtFechaNacimientoModal" CssClass="form-control" TextMode="Date" Placeholder="dd/mm/aaaa" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <asp:DropDownList runat="server" ID="ddlSexo" AppendDataBoundItems="true" CssClass="form-control">
                                    <asp:ListItem Value="0" Text="[Selecciona]" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <%--<asp:TextBox runat="server" ID="txtFecRegistroModal" CssClass="form-control" TextMode="Date" />--%>
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtCorreoModal" Placeholder="Ingresa tu correo." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPromedioModal" Placeholder="Ingresa tu promedio" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <asp:DropDownList ID="ddlPerfilModal" runat="server" AppendDataBoundItems="true" CssClass="form-control" DataTextField="Perfil" OnSelectedIndexChanged="ddlPerfilModal_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0" Text="[Selecciona uno]" />
                                </asp:DropDownList>

                                <%--<asp:TextBox runat="server" ID="txtMatriculaModal" Placeholder="Matrícula" ToolTip="Matrícula" Enabled="false" CssClass="form-control" />--%>
                                <%-- creo que esta se va a ir.... 
                                    
                                    :'(
                                                                        
                                    En este punto deberemos construir la matricula..... la primer letra del nombre, la primer letra del apellido paterno, la primer letra del apellido materno y el año de nacimiento.... a lo mejor agrego otros caracteres.... --%>
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPasswordModal" Placeholder="Ingresa tu password" CssClass="form-control" TextMode="Password" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPasswordDosModal" Placeholder="Confirma tu password" CssClass="form-control" TextMode="Password" />
                                <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtPasswordModal" ControlToCompare="txtPasswordDosModal" ErrorMessage="Las contraseñas no son iguales"></asp:CompareValidator>
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Agregar" runat="server" ID="btnAgregarRegistro" CssClass="btn btn-success" Enabled="false" OnClick="btnAgregarRegistro_Click" />
                                <%-- En este botón deberemos agregar en el código, en que etapa se encuentra.... siendo por default siempre la numero 1...., ya que se acaba de registrar.... --%>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div class="row">
                            <div class="col-md-6">
                                <div>
                                    <asp:TextBox runat="server" ID="txtUsuaAdmiModal" placeholder="Correo" Visible="false" />
                                    <asp:TextBox runat="server" ID="txtPassAdmiModal" placeholder="Contraseña" Visible="false" TextMode="Password" />
                                    <asp:Button runat="server" Text="Autorizar" ID="btnAutoAdmiModal" Visible="false" OnClick="btnAutoAdmiModal_Click" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-2.1.4.js"></script>
    <script src="js/bootstrap.js"></script>
</asp:Content>

