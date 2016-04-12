<%@ Page Title="" Language="C#" MasterPageFile="~/mpEscuela.master" AutoEventWireup="true" CodeFile="ClonInicio.aspx.cs" Inherits="ClonInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
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
                                <h4 style="text-align: center;">Acceso 
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
                            <div class="col-xs-6">
                                <label class="btn btn-block btn-warning" data-toggle="modal" data-target="#modRegistro">Nuevo Usuario</label>
                            </div>
                            <div class="col-xs-6">
                                <asp:Button class="btn btn-block btn-info" Text="Ingresar" ID="btnAceptar" runat="server" />
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
                                <label>Apellido Paterno</label>
                                <br />
                                <asp:TextBox runat="server" ID="txtPaternoModal" Placeholder="Ingresa tu Apellido Paterno." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <label>Apellido Materno</label>
                                <br />
                                <asp:TextBox runat="server" ID="txtMaternoModal" Placeholder="Ingresa tu Apellido Materno." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <label>Fecha de Nacimiento</label>
                                <br />
                                <asp:TextBox runat="server" ID="txtFechaNacimientoModal" CssClass="form-control" TextMode="Date" Placeholder="dd/mm/aaaa" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <label>Genero</label>
                                <br />
                                <asp:DropDownList runat="server" ID="ddlSexo" AppendDataBoundItems="true" CssClass="form-control">
                                    <asp:ListItem Value="0" Text="[Selecciona]" />
                                </asp:DropDownList>
                            </div>
                            <%--<div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtFecRegistroModal" CssClass="form-control" TextMode="Date" />
                            </div>--%>
                            <div class="col-xs-3">
                                <br />
                                <label>Ingresa tu correo electrónico</label>
                                <br />
                                <asp:TextBox runat="server" ID="txtCorreoModal" Placeholder="Ingresa tu correo." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <label>Promedio general</label>
                                <br />
                                <asp:TextBox runat="server" ID="txtPromedioModal" Placeholder="Ingresa tu promedio" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <label>Perfil </label>
                                <br />
                                <asp:DropDownList ID="ddlPerfilModal" runat="server" AppendDataBoundItems="true" CssClass="form-control" DataTextField="Perfil">
                                    <asp:ListItem Value="0" Text="[Selecciona uno]" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <label>Contraseña para tu cuenta</label>
                                <br />
                                <asp:TextBox runat="server" ID="txtPasswordModal" Placeholder="Ingresa tu password" CssClass="form-control" TextMode="Password" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <label>Confirma tu contraseña </label>
                                <br />
                                <asp:TextBox runat="server" ID="txtPasswordDosModal" Placeholder="Confirma tu password" CssClass="form-control" TextMode="Password" />
                                <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtPasswordModal" ControlToCompare="txtPasswordDosModal" ErrorMessage="Las contraseñas no son iguales"></asp:CompareValidator>
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Agregar" runat="server" ID="btnAgregarRegistro" CssClass="btn btn-success" Enabled="false" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer" style="text-align: center;">
                        <div class="row">
                            <div class="col-md-6">
                                <div id="divAutorizar" style="display: none">
                                    <label>Debe autorizar un administrador.</label>
                                    <input type="text" id="txtCorreo" placeholder="Correo" class="form-control" />
                                    <input type="password" id="txtContraseña" placeholder="Contraseña" class="form-control" />
                                    <br />
                                    <label id="btnAutorizar" class="btn btn-sm btn-success">Autorizar</label>
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
    <script>
        $(document).ready(function () {
            $('#body_ddlPerfilModal').change(function () {
                if ($(this).val() == "2") {
                    $('#divAutorizar').show();
                    $('#body_btnAgregarRegistro').prop("disabled", true);
                } else if ($(this).val() == "1") {
                    $('#body_btnAgregarRegistro').prop("disabled", false);
                    $('#divAutorizar').hide();
                } else {
                    $('#divAutorizar').hide();
                    $('#body_btnAgregarRegistro').prop("disabled", true);
                }
            });
            $('#btnAutorizar').on("click", function () {
                var usuario = $('#txtCorreo').val();
                var password = $('#txtContraseña').val();
                misDatos = '{"usuario":"' + usuario + '", "password":"' + password + '" }';
                $.ajax({
                    type: "POST",
                    url: "Inicio.aspx/Autorizar",
                    data: misDatos,
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var list = $.parseJSON(msg.d);
                        if (list.PerfilId == "1") {
                            alert("El usuario ingresado no es administrador y tu no puedes asignarte como administrador.");
                        }
                        else if (list.PerfilId == "2") {
                            alert("Adelante, acceso autorizado para darte de alta como administrador.");
                            $('#body_btnAgregarRegistro').prop("disabled", false);
                            $('#divAutorizar').hide();
                        }
                    },
                    error: function (msg) {
                        alert('Error al validar datos. ' + msg.responseText);
                    }
                });//Fin Ajax
            });//Fin de btnAutoriza

        });
    </script>
</asp:Content>

