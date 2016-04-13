<%@ Page Title="" Language="C#" MasterPageFile="~/mpEscuela.master" AutoEventWireup="true" CodeFile="ClonGrid.aspx.cs" Inherits="ClonGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
        <div id="divTabla"></div>
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
                            <input type="text" id="txtFechaAlta" class="form-control" placeholder="dd/mm/aaaa" />
                        </div>
                        <div class="col-xs-3" style="text-align: center;">
                            <br />
                            <button id="btnAgregarDocumentos" class="btn btn-success">Agregar</button>
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
                                            <label>Pregunta 1:</label>
                                            Cierto<input type="radio" id="rblPUno" name="pUno" value="1" />
                                            Falso<input type="radio" name="pUno" value="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Pregunta 2:</label>
                                            Cierto<input type="radio" id="rblPDos" name="pDos" value="1" />
                                            Falso<input type="radio" name="pDos" value="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Pregunta 3:</label>
                                            Cierto<input type="radio" id="rblPTres" name="pTres" value="1" />
                                            Falso<input type="radio" name="pTres" value="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Pregunta 4:</label>
                                            Cierto<input type="radio" id="rblPCuatro" name="pCuatro" value="1" />
                                            Falso<input type="radio" name="pCuatro" value="0" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-xs-3" style="text-align: center;">
                            <br />
                            <label id="btnEnviarPsico" class="btn btn-success">Enviar</label>
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
                                            <label>Pregunta 1:</label>
                                            <input type="text" id="txtRespuestaUno" placeholder="Inserta tu respuesta:" class="form-control" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Pregunta 2:</label>
                                            <input type="text" id="txtRespuestaDos" placeholder="Inserta tu respuesta:" class="form-control" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Pregunta 3:</label>
                                            <input type="text" id="txtRespuestaTres" placeholder="Inserta tu respuesta:" class="form-control" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Pregunta 4:</label>
                                            <input type="text" id="txtRespuestaCuatro" placeholder="Inserta tu respuesta:" class="form-control" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-xs-3" style="text-align: center;">
                            <br />
                            <label id="btnEnviarExamen" class="btn btn-success">Enviar</label>
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
                            <label>Fecha de Pago:</label>
                            <input type="date" id="txtFechaPago" class="form-control" />
                        </div>
                        <div class="col-xs-3">
                            <br />
                            <label>Cantidad de pago: </label>
                            <input type="text" id="txtCantidadPago" class="form-control" />
                        </div>
                        <div class="col-xs-3">
                            <br />
                            <label>"Descripcion del pago</label>
                            <textarea rows="4" id="txtDescripcionPago" class="form-control"></textarea>
                        </div>
                        <div class="col-xs-3">
                            <br />
                            <select id="ddlTipoPago">
                                <option value="0">[Selecciona]</option>
                            </select>
                        </div>
                        <div class="col-xs-3" style="text-align: center;">
                            <br />
                            <label id="btnEnviarPago" class="btn btn-success">Agregar</label>
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
    <script src="js/app.js"></script>
</asp:Content>

