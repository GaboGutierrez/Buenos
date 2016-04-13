$(document).ready(function () {
    'use strict';
    LlenarDdlPagos();
    LlenarGridAlumnos();
    function LlenarDdlPagos() {
        $.ajax({
            type: "POST",
            url: "ClonGrid.aspx/LlenarDdlPagos",
            data: '{}',
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var list = $.parseJSON(msg.d);
                $('#ddlTipoPago').empty();
                $('#ddlTipoPago').append($('<option>', { value: "0", text: "[Selecciona]" }));
                $(list).each(function () {
                    $('#ddlTipoPago').append($('<option>', { value: this.Id, text: this.Nombre }));
                });
            },
            error: function (msg) {
                alert('Error al llenar ddlTipoPago. ' + msg.responseText);
            }
        });//Fin Ajax
    }
    function LlenarGridAlumnos() {
        $.ajax({
            type: "POST",
            url: "ClonGrid.aspx/LlenarGridAlumnos",
            data: '{}',
            async: true,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var list = $.parseJSON(msg.d);
                var tabla = '';
                tabla += '';
                tabla += '<table id="GridAlumnos" class="table table-hover table-responsive">';
                tabla += '<tr style="background-color: #ccc;">';
                tabla += ' <td>[Matricula]</td>';
                tabla += ' <td>[Nombre completo]</td>';
                tabla += ' <td>[Fecha de Registro]</td>';
                tabla += ' <td>[Correo electrónico]</td>';
                tabla += ' <td>[Examen Psicométrico]</td>';
                tabla += ' <td>[Documentos]</td>';
                tabla += ' <td>[Pagos]</td>';
                tabla += ' <td>[Examen Conocimientos]</td>';
                tabla += ' <td>[Etapa Actual]</td>';
                tabla += '</tr>';
                $(list).each(function () {
                    tabla += '<tr>';
                    tabla += ' <td>' + this.Matricula + '</td>';
                    tabla += ' <td>' + this.Nombre + ' ' + this.Paterno + ' ' + this.Materno + '</td>';
                    tabla += ' <td>' + this.fRegistro + ' </td>';
                    tabla += ' <td>' + this.Correo + '</td>';

                    switch (this.EtapaId) {
                        case 1: {
                            tabla += '<td><a data-toggle="modal" data-target="#modPsicometrico",>Presentar Examen</a></td>';
                            tabla += '<td></td>';
                            tabla += '<td></td>';
                            tabla += '<td></td>';
                            tabla += '<td></td>';
                            break;
                        }
                        case 2: {
                            if (this.ExamPsico.Aprobado)
                                tabla += ' <td><label>'+ this.FechaAplicacion + ' Aprobado' + '</label></td>';
                            else
                                tabla += ' <td><label>Reprobado</label></td>';

                            tabla += ' <td><a data-toggle="modal" data-target="#modDocumentos",>CargarArchivo</a></td>';
                            tabla += ' <td></td>';
                            tabla += ' <td></td>';
                            tabla += ' <td></td>';
                            break;
                        }
                        case 3: {
                            tabla += ' <td>[Examen Psicométrico]</td>';
                            tabla += ' <td>[Documentos]</td>';
                            tabla += ' <td>[Pagos]</td>';
                            tabla += ' <td>[Examen Conocimientos]</td>';
                            tabla += ' <td>[Etapa Actual]</td>';
                            break;
                        }
                        case 4: {
                            tabla += ' <td>[Examen Psicométrico]</td>';
                            tabla += ' <td>[Documentos]</td>';
                            tabla += ' <td>[Pagos]</td>';
                            tabla += ' <td>[Examen Conocimientos]</td>';
                            tabla += ' <td>[Etapa Actual]</td>';
                            break;
                        }
                        case 5: {
                            tabla += ' <td>[Examen Psicométrico]</td>';
                            tabla += ' <td>[Documentos]</td>';
                            tabla += ' <td>[Pagos]</td>';
                            tabla += ' <td>[Examen Conocimientos]</td>';
                            tabla += ' <td>[Etapa Actual]</td>';
                            break;
                        }
                        default: { break; }
                    }//fin del Case
                    tabla += '</tr>';
                });
                tabla += '<tr><td colspan="9"><label class="btn btn-success btn-sm" id="btnCrearBoton">crear boton</label></td></tr>';
                tabla += '</table>';
                $('#divTabla').append(tabla);

                $('#btnCrearBoton').bind("click", function () {
                    var tabla = '<tr><td colspan="9"><label class="btn btn-success btn-sm" id="btnHola">Decir hola</label></td></tr>';
                    $('#divTabla').append(tabla);

                    $('#btnHola').on("click", function () {
                        alert("Hola");
                    });
                });
            },
            error: function (msg) {
                alert('Error al llenar ddlTipoPago. ' + msg.responseText);
            }
        });//Fin Ajax
    }
});//Fin del ready()