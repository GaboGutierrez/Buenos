﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mpEscuela.master" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="container">
            <asp:GridView ID="gvEscuela" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Matricula]">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Matricula") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Nombre completo]">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Fecha de Registro]">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("FechaRegistro", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Correo electrónico]">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Examen Psicométrico]">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkExamPsic" runat="server" Text='<%# Bind("ExamPsico.Estatus") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Documentos]">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDocu" runat="server" Text='<%# Bind("Documento.Nombre") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Pagos]">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPago" runat="server" Text='<%# Bind("Pago.TipoPago.Nombre") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Examen Conocimientos]">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkExam" runat="server" Text='<%# Bind("Examen.Aprobado") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-CssClass="text-center; form-control;" HeaderText="[Etapa Actual]">
                        <ItemTemplate>
                            <asp:Label ID="lblCierre" runat="server" Text='<%# Bind("Etapa.Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <label>esto es una prueba</label>
        <br />
        <asp:Label ID="lblAlumno" runat="server" />
        
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
                                <asp:Button Text="Agregar" runat="server" ID="btnAgregarDocumentos" CssClass="btn btn-success" OnClick="btnAgregarDocumentos_Click" />
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
                                <asp:Button Text="Enviar" runat="server" ID="btnEnviarExamen" CssClass="btn btn-success" />
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
                                <asp:Button Text="Agregar" runat="server" ID="btnEnviarPago" CssClass="btn btn-success" />
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


    <script src="js/jquery-2.1.4.js"></script>
    <script src="js/bootstrap.js"></script>
</asp:Content>

