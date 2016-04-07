<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="js/jquery-2.1.4.js"></script>
    <script src="js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col">
                <div>
                    <br />
                    <asp:Label CssClass="btn-link" ID="lblModalRegistro" runat="server" data-toggle="modal" data-target="#modRegistro" Text="Registro"></asp:Label>
                    <br />
                    <asp:Label CssClass="btn-link" ID="lblModalDocumentos" runat="server" data-toggle="modal" data-target="#modDocumentos" Text="Documentos"></asp:Label>
                    <br />
                    <asp:Label CssClass="btn-link" ID="lblModalPsicometrico" runat="server" data-toggle="modal" data-target="#modPsicometrico" Text="Examen Psicométrico"></asp:Label>
                    <br />
                    <asp:Label CssClass="btn-link" ID="lblModalExamen" runat="server" data-toggle="modal" data-target="#modExamen" Text="Examen Conocimientos"></asp:Label>
                    <br />
                    <asp:Label CssClass="btn-link" ID="lblPagos" runat="server" data-toggle="modal" data-target="#modPagos" Text="Forma de Pago"></asp:Label>
                </div>
            </div>
        </div>
        <div>
            <asp:GridView ID="gvEscuela" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="[Nombre]">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Sexo]">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Fecha de Registro]">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Registro", "{0:d "dd/MM/yyyy"}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Correo electrónico]">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Matricula]">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Documentos]">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Documento") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Tipo de documento]">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("DocTipo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Aprobado]">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Aprobado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Estatus]">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Estatus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Id de Etapa]">
                        <ItemTemplate>
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("EtapaId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Nombre de Etapa]">
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("EtapaNombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Calificacion]">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("calificacion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Aprobado]">
                        <ItemTemplate>
                            <asp:Label ID="Label13" runat="server" Text='<%# Bind("Aprobado") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Fecha de Pago]">
                        <ItemTemplate>
                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("FechaPago", "{0:d "dd/MM/yyyy"}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Cantidad de Pago]">
                        <ItemTemplate>
                            <asp:Label ID="Label15" runat="server" Text='<%# Bind("Cantidad", "{0:C}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Tipo de Pago]">
                        <ItemTemplate>
                            <asp:Label ID="Label16" runat="server" Text='<%# Bind("PagoNombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>

        </div>
        <%-- Primer modal para el registro --%>
        <!-- Modal -->
        <div class="modal fade" id="modRegistro" role="dialog" style="width: 1000px;">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content" style="width: 750px; height: 300px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Registro</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtRegNombre" Placeholder="Ingresa tu nombre." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPaterno" Placeholder="Ingresa tu Apellido Paterno." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtMaterno" Placeholder="Ingresa tu Apellido Materno." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" Placeholder="dd/mm/aaaa" />
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
                                <asp:TextBox runat="server" ID="txtFecRegistro" CssClass="form-control" TextMode="Date" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtCorreo" Placeholder="Ingresa tu correo." CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPromedio" Placeholder="Ingresa tu promedio" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtMatricula" Placeholder="Ingresa tu matricula" CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPassword" Placeholder="Ingresa tu password" CssClass="form-control" TextMode="Password" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtPasswordDos" Placeholder="Confirma tu password" CssClass="form-control" TextMode="Password" />
                                <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtPassword" ControlToCompare="txtPasswordDos" ErrorMessage="No son iguales"></asp:CompareValidator>
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Agregar" runat="server" ID="btnAgregarRegistro" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- Segundo modal para los documentos --%>
        <!-- Modal -->
        <div class="modal fade" id="modDocumentos" role="dialog" style="width: 1000px;">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content" style="width: 750px; height: 300px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Recolección de documentos</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <label class="label label-info">Agrega un documento:</label>
                            </div>
                            <div class="col-xs-6">
                                <br />
                                <asp:FileUpload ID="fuDocumento" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:TextBox runat="server" ID="txtFechaAlta" TextMode="Date" CssClass="form-control" Placeholder="dd/mm/aaaa" />
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Agregar" runat="server" ID="btnAgregarDocumentos" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- Tercer modal para el Examen Psicometrico  --%>
        <!-- Modal -->
        <div class="modal fade" id="modPsicometrico" role="dialog" style="width: 1000px;">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content" style="width: 750px; height: 300px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Examen Psicométrico</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 1:" runat="server" />
                                                <asp:RadioButtonList runat="server" ID="rbtnPreguntaUno">
                                                    <asp:ListItem Text="Cierto" Value="0" />
                                                    <asp:ListItem Text="Falso" Value="1" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 2:" runat="server" />
                                                <asp:RadioButtonList runat="server" ID="rbtnPreguntaDos">
                                                    <asp:ListItem Text="Cierto" Value="1" />
                                                    <asp:ListItem Text="Falso" Value="0" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 3:" runat="server" />
                                                <asp:RadioButtonList runat="server" ID="rbtnPreguntaTres">
                                                    <asp:ListItem Text="Cierto" Value="1" />
                                                    <asp:ListItem Text="Falso" Value="0" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 4:" runat="server" />
                                                <asp:RadioButtonList runat="server" ID="rbtnPreguntaCuatro">
                                                    <asp:ListItem Text="Cierto" Value="0" />
                                                    <asp:ListItem Text="Falso" Value="1" />
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <label class="label label-info">Fecha de Aplicación:</label>
                                <asp:TextBox runat="server" ID="txtFechaPsico" CssClass="form-control" TextMode="Date" />
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Enviar" runat="server" ID="btnEnviarPsico" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- Cuarto modal para el Examen Conocimientos  --%>
        <!-- Modal -->
        <div class="modal fade" id="modExamen" role="dialog" style="width: 1000px;">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content" style="width: 750px; height: 300px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Examen de Conocimientos</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-12">
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 1:" runat="server" />
                                                <asp:TextBox runat="server" ID="txtRespuestaUno" Placeholder="Inserta tu respuesta:" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 2:" runat="server" />
                                                <asp:TextBox runat="server" ID="txtRespuestaDos" Placeholder="Inserta tu respuesta:" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 3:" runat="server" />
                                                <asp:TextBox runat="server" ID="txtRespuestaTres" Placeholder="Inserta tu respuesta:" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Text="Pregunta 4:" runat="server" />
                                                <asp:TextBox runat="server" ID="txtRespuestaCuatro" Placeholder="Inserta tu respuesta:" CssClass="form-control" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <label class="label label-info">Fecha de Aplicación:</label>
                                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="Date" />
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Enviar" runat="server" ID="Button2" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- Quinto modal para los Pagos --%>
        <!-- Modal -->
        <div class="modal fade" id="modPagos" role="dialog" style="width: 1000px;">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content" style="width: 750px; height: 300px;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Forma de Pago</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <asp:Label Text="Fecha de Pago" runat="server" />
                                <asp:TextBox runat="server" ID="txtFechaPago" CssClass="form-control" TextMode="Date" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:Label Text="Cantidad de pago" runat="server" />
                                <asp:TextBox runat="server" ID="txtCantidadPago" CssClass="form-control" TextMode="Number" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:Label Text="Descripcion del pago" runat="server" />
                                <asp:TextBox runat="server" ID="txtDescripcionPago" CssClass="form-control" TextMode="MultiLine" />
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:DropDownList runat="server" ID="ddlTipoPago" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0" Text="[Selecciona]" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-3" style="text-align: center;">
                                <br />
                                <asp:Button Text="Agregar" runat="server" ID="Button1" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <div>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
