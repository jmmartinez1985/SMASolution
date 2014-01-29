/*
 * Scripts para Service Market
 *
 * Copyright (c) 2013 Service Market
 *
 * Project home:
 *   
 *
 * Version:  1.0
 *
 */


function ChangePassword(data) {
    var Titulo = 'Cambio de contraseña';
    $("#OldPassword").val('');
    $("#NewPassword").val('');
    $("#ConfirmPassword").val('');
    $.gritter.add({
        title: Titulo,
        text: data.message
    });
}

function ForgotPassword(data) {
    var Titulo = 'Olvidó su contraseña';
    $("#Email").val('');
    $.gritter.add({
        title: Titulo,
        text: data.message
    });
}

function CreateCategoria(data) {
    var Titulo = 'Creación de Categoría';
    var Mensaje = '';
    //var TipoAlerta = '';
    if (data.wasSuccess) {
        Mensaje = 'Se ha registrado satisfactoriamente los datos ingresados.';
        $("#CD_Descripcion").val('');
    }
    else {
        Mensaje = 'Hubo un error al registrar los datos. Por favor verifique.';
    }

    $.gritter.add({
        title: Titulo,
        text: Mensaje
    });

    //jQuery(".message").prepend('<div class="alert ' + TipoAlerta + ' fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p>' + Titulo + '</p></strong><p>' + Mensaje + '</p></div>');
    //jQuery(".alert").alert();
    //jQuery(".alert").fadeOut(3000);
};

function CreateFAQ(data) {
    var Titulo = 'Creación de FAQ';
    var Mensaje = '';

    if (data.wasSuccess) {
        Mensaje = 'Se ha registrado satisfactoriamente los datos ingresados.';
        $("#FAQ_Question").val('');
        $("#FAQ_Answer").val('');
    }
    else {
        Mensaje = 'Hubo un error al registrar los datos. Por favor verifique.';
    }

    $.gritter.add({
        title: Titulo,
        text: Mensaje
    });

    //jQuery(".message").prepend('<div class="alert ' + TipoAlerta + ' fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p>' + Titulo + '</p></strong><p>' + Mensaje + '</p></div>');
    //jQuery(".alert").alert();
    //jQuery(".alert").fadeOut(3000);
};

function CreateMembresia(data) {

    var Titulo = 'Creación de Membresía';
    var Mensaje = '';

    if (data.wasSuccess) {
        Mensaje = 'Se ha registrado satisfactoriamente los datos ingresados.';
        $("#MP_Descripcion").val('');
        $("#MP_ExpiracionDays").val('');
    }
    else {
        Mensaje = 'Hubo un error al registrar los datos. Por favor verifique.';
    }

    $.gritter.add({
        title: Titulo,
        text: Mensaje
    });

    //jQuery(".message").prepend('<div class="alert ' + TipoAlerta + ' fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p>' + Titulo + '</p></strong><p>' + Mensaje + '</p></div>');
    //jQuery(".alert").alert();
    //jQuery(".alert").fadeOut(3000);

};

function CreatePaises(data) {
    var Titulo = 'Creación de Países';
    var Mensaje = '';
    var TipoAlerta = '';
    if (data.wasSuccess) {
        Mensaje = 'Se ha registrado satisfactoriamente los datos ingresados.';
        TipoAlerta = 'alert-success';
    }
    else {
        Mensaje = 'Hubo un error al registrar los datos. Por favor verifique.';
        TipoAlerta = 'alert-error';
    }

    jQuery(".message").prepend('<div class="alert ' + TipoAlerta + ' fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p>' + Titulo + '</p></strong><p>' + Mensaje + '</p></div>');
    jQuery(".alert").alert();
    jQuery(".alert").fadeOut(3000);

};

function CreateRegion(data) {
    var Titulo = 'Creación de Países';
    var Mensaje = '';
    var TipoAlerta = '';
    if (data.wasSuccess) {
        Mensaje = 'Se ha registrado satisfactoriamente los datos ingresados.';
        TipoAlerta = 'alert-success';
    }
    else {
        Mensaje = 'Hubo un error al registrar los datos. Por favor verifique.';
        TipoAlerta = 'alert-error';
    }

    jQuery(".message").prepend('<div class="alert ' + TipoAlerta + ' fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p>' + Titulo + '</p></strong><p>' + Mensaje + '</p></div>');
    jQuery(".alert").alert();
    jQuery(".alert").fadeOut(3000);

};

function CreateSubCategoria(data) {
    var Titulo = 'Creación de SubCategoría';
    var Mensaje = '';

    if (data.wasSuccess) {
        Mensaje = 'Se ha registrado satisfactoriamente los datos ingresados.';
        $("#SBS_Descripcion").val('');
        $('#CD_Id').prop('selectedIndex', 0)
    }
    else {
        Mensaje = 'Hubo un error al registrar los datos. Por favor verifique.';
    }

    $.gritter.add({
        title: Titulo,
        text: Mensaje
    });

    //jQuery(".message").prepend('<div class="alert ' + TipoAlerta + ' fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p>' + Titulo + '</p></strong><p>' + Mensaje + '</p></div>');
    //jQuery(".alert").alert();
    //jQuery(".alert").fadeOut(3000);
};

function ShortDateTime(dateObject) {
    //var d = new Date(dateObject);
    //var day = d.getDate();
    //var month = d.getMonth();
    //var year = d.getFullYear();

    //if (day < 10) {
    //    day = "0" + day;
    //}

    //if (month < 10) {
    //    month = "0" + month;
    //}

    //var date = day + "/" + month + "/" + year;
    //return date;

    var fecha = dateObject.split('T')
    var fechaDivida = fecha[0].split('-');

    return fechaDivida[2] + "/" + fechaDivida[1] + "/" + fechaDivida[0];
};

var COMMON = COMMON || {};

var ANUNCIOS = ANUNCIOS || {};

var CONTACTOS = CONTACTOS || {};

var HOME = HOME || {};

var MEMBRESIA = MEMBRESIA || {};

var REVIEW = REVIEW || {};

var LAYOUTS = LAYOUTS || {};

var SOLICITUD = SOLICITUD || {};

jQuery(function () {

    LAYOUTS.GetCompanyInformation = function (url) {
        jQuery.ajax(
        {
            type: 'post',
            url: url,
            success: function (data) {
                var result = JSON.parse(data);
                var htmldata = '';
                htmldata +=
                htmldata += '<address>';
                htmldata += result.COM_Nombre;
                htmldata += '<br>';
                htmldata += result.COM_Direccion;
                htmldata += '<br>';
                htmldata += 'Teléfono: ' + result.COM_Telefono;
                htmldata += '<br>';
                htmldata += 'Correo: <a href="mailto:' + result.COM_Correo + '">' + result.COM_Correo + '</a>';
                htmldata += '</address>';
                jQuery('#divAddress').append(htmldata);

            },
            error: function (a, b, c) {

            }
        });
    }

    LAYOUTS.GetLastAnuncios = function (url, urldetails) {
        jQuery.ajax(
        {
            type: 'post',
            url: url,
            success: function (data) {
                var result = JSON.parse(data);
                var htmldata = '';
                jQuery.each(result.$values, function (val, anuncio) {
                    var urlcontent = urldetails + anuncio.AnunciosInfo.AN_Id;
                    htmldata += '<dl class="dl-horizontal"><dt><a href="' + urlcontent + '"><img src=' + anuncio.FirstImage + ' alt=' + anuncio.Usuario + '></a></dt><dd><p><a href="' + urlcontent + '">';
                    htmldata += anuncio.AnunciosInfo.AN_Descripcion;
                    htmldata += '</a></p></dd></dl>';
                });

                jQuery('#UltimosAnuncios').append(htmldata);

            },
            error: function (a, b, c) {

            }
        });
    }

    COMMON.CallProgress = function showProgress(loadingImgSrc) {
        $ki.blockUI({
            message: '<p>Por favor espere mientra se procesa la solicitud...</p><img src="' + loadingImgSrc + '" /> <br>',
            css: {
                width: '450px',
                border: 'none',
                padding: '15px',
                backgroundColor: '#fafafa',
                'border-radius': '10px',
                opacity: .95,
                color: '#000',
                'font-size': '18px',
                'box-shadow': '0px 0px 12px rgba(0,0,0,.6)',
                'z-index': '9999'
            }
        });
    }

    COMMON.HideProgress = function hideProgress() {
        $ki.unblockUI();
    }

    HOME.VerifyCredential = function (url, redirect) {

        jQuery.ajax(
        {
            type: 'post',
            url: url,
            success: function (data) {

                if (data.IsIncomplete == true) {
                    bootbox.confirm("<h5>Estimado usuario, antes de seguir disfrutando de Service Market le solicitamos por favor completar algunos datos requeridos en su perfil. ¿Desea completar su perfil en este momento?</h5>", "Cancelar", "Aceptar", function (result) {
                        if (result) {
                            $(location).attr('href', redirect);
                        }
                    });
                }
            },
            error: function (xhr) {
                if (xhr.status == 403) {

                }
                else {
                    if (xhr.responseText != "")
                        bootbox.alert("<h1>A ocurrido un error</h1> <br />" + xhr.responseText, function () {
                        });
                }
            }
        });
    }

    HOME.GetServices = function (url) {
        jQuery.ajax(
        {
            type: 'post',
            url: url,//'@Url.Action("GetServices", "Home")',
            success: function (data) {

                var result = JSON.parse(data);
                var htmldata = '';
                jQuery('#firstSearch').show(300);
                jQuery('#SecondSearch').hide();
                jQuery.each(result.$values, function (val, anuncio) {

                    var param = {
                        "Id": anuncio.AnunciosInfo.AN_Id,
                        "Nombre": anuncio.Usuario,
                        "Titulo": anuncio.AnunciosInfo.AN_Titulo,
                    };

                    htmldata += '<tr><td><div class="row-fluid">';
                    htmldata += '<div class="span12 booking-blocks"> ';
                    htmldata += '<div class="span10">';
                    ////reviews
                    //htmldata += '<ul class="unstyled inline blog-info">';
                    //htmldata += ' <li><i class="icon-calendar"></i>' + ShortDateTime(anuncio.AnunciosInfo.AN_Fecha) + ' </li>';
                    //htmldata += ' <li><i class="icon-comments"></i> <a href="#">'+ anuncio.Comments+ ' Reviews</a></li>';
                    //htmldata += '</ul>';
                    ////fin reviews
                    htmldata += '<div class="pull-left booking-img">';
                    htmldata += '<img src="' + anuncio.FirstImage + '" alt="' + anuncio.Usuario + '"> ';
                    htmldata += '<ul class="unstyled">';
                    htmldata += '<li><ul class="unstyled inline"><li><div class="ratyclass" id=' + "toraty" + val + '  ratyval= ' + anuncio.Rating + ' style="width:20px;" ></div </li></ul></li>'
                    htmldata += '</ul>';
                    htmldata += '</div>';
                    htmldata += '<div style="overflow: hidden;">';
                    htmldata += '<h2><a href="javascript:SeeAnuncios(' + anuncio.AnunciosInfo.AN_Id + ');">' + anuncio.AnunciosInfo.AN_Titulo + '</a> (' + anuncio.Comments + ' Reviews)</h2> ';
                    htmldata += '<b>' + anuncio.Usuario + '</b>';
                    htmldata += '<ul class="unstyled inline">';
                    htmldata += '<li><i class="icon-calendar"></i>' + ShortDateTime(anuncio.AnunciosInfo.AN_Fecha) + ' </li>&nbsp;';
                    htmldata += '<li><i class="icon-briefcase"></i>' + anuncio.CategoriaDescripcion + '</li> ';
                    htmldata += '<li><i class="icon-map-marker"></i>' + anuncio.AnunciosInfo.AN_Area + '</li>';
                    htmldata += '</ul>';
                    htmldata += '<p>' + anuncio.AnunciosInfo.AN_Descripcion + '</p>';
                    htmldata += '</div>';
                    htmldata += '</div>';
                    htmldata += '<div class="span2">';
                    htmldata += '<button onclick="SeeAnuncios(' + anuncio.AnunciosInfo.AN_Id + ');"class="btn-u btn-u-orange btn-block"><i class="icon-white icon-plus"></i>&nbsp;Leer Más</button>';
                    htmldata += '<button onclick="TakeService(' + anuncio.AnunciosInfo.AN_Id + ');" id= btnTakeService' + anuncio.AnunciosInfo.AN_Id + '  data-nombre= "' + anuncio.Usuario + '" data-titulo= "' + anuncio.AnunciosInfo.AN_Titulo + '" class="btn-u btn-u-orange btn-block"><i class="icon-white icon-ok"></i>&nbsp;Solicitar</button>';
                    htmldata += '</div>';
                    htmldata += '</div>';
                    htmldata += '</div></td> </tr>';
                });
                jQuery('#anunciosAvailable').prepend(htmldata);
                jQuery('.ratyclass').each(function (i, elem) {
                    var ratyvalue = $(this).attr('ratyval');
                    $ki(this).raty({ readOnly: true, score: ratyvalue });
                });
                $ki("div.holder").jPages({
                    containerID: "anunciosAvailable",
                    //              previous: "←",
                    //              next: "→",
                    first: "Primera",
                    previous: "Anterior",
                    next: "Siguiente",
                    last: "Última",
                    perPage: 7,
                    delay: 20
                });
            },
            error: function (xhr) {
                if (xhr.responseText != "")
                    alert('An error has ocurred loading data: ' + xhr.responseText, 'Error');
            }
        });


    }

    HOME.SearchKey = function () {
        jQuery('#txtSearchHome').keyup(function () {
            var text = jQuery('#txtSearchHome').val();
            var rows = jQuery('#anunciosAvailable > tr');
            var isVisible = $('#firstSearch').is(':visible');
            if (!isVisible) {
                rows = jQuery('#SearchData > tr');
            }
            rows.each(function (idx, elem) {
                var rowText = $(elem).text().toLowerCase();
                if (rowText.indexOf(text.toLowerCase()) < 0) {
                    jQuery(elem).hide();
                }
                else {
                    jQuery(elem).show();
                }
            });
            setTimeout(HOME.CheckVisibleProjects(), 300);
        });
    }

    HOME.CheckVisibleProjects = function () {
        var rows = jQuery('#anunciosAvailable > tr');
        if (rows.filter(':hidden').size() == rows.length) {
            jQuery('#divNoAnunciosFound').fadeIn(1000);
        }
        else {
            jQuery('#divNoAnunciosFound').hide();
        }
    }

    HOME.ChangeCategory = function (Control, url) {
        jQuery("#" + Control).change(function () {
            $.ajax({
                dataType: "json",
                type: 'post',
                url: url,
                data: { Cat: parseInt(jQuery("#" + Control).val()) },
                success: function (data) {
                    var result = JSON.parse(data);
                    var select = $('#SBS_Id');
                    if (select.prop) {
                        var options = select.prop('options');
                    }
                    else {
                        var options = select.attr('options');
                    }
                    $('option', select).remove();
                    $.each(result.$values, function (key, val) {
                        options[options.length] = new Option(val.SBS_Descripcion, val.SBS_Id);
                    });
                },
                error: function (a, b, c) {

                },
            });

        });
    }

    HOME.FillFormData = function (search) {
        var form = new FormData();
        if (search == 1) {
            form.append("Categoria", jQuery('#CAT_Id').val());
            form.append("SubCategoria", jQuery('#SBS_Id').val());
            form.append("Lugar", "");
            form.append("Descripcion", "");
        }
        else if (search == 2) {
            form.append("Categoria", "");
            form.append("SubCategoria", "");
            form.append("Descripcion", jQuery('#descriptioninput').val());
            form.append("Lugar", "");
        }
        else {
            form.append("Categoria", "");
            form.append("SubCategoria", "");
            form.append("Descripcion", "");
            form.append("Lugar", jQuery('#placeinput').val());
        }
        return form;
    }

    HOME.CallFilter = function (search, url) {

        var formdata = HOME.FillFormData(search)
        $.ajax({
            url: url,//'@Url.Action("GetInformationAnuncios", "Anuncios")',
            type: 'post',
            data: formdata,
            cache: false,
            contentType: false,
            processData: false,
            beforeSend: function () {
                COMMON.CallProgress(LoadingImage);
            },
            complete: function (data) {
                COMMON.HideProgress();
            },
            success: function (data) {
                if (data.Error) {
                    jQuery('#divNoAnunciosFound').fadeIn(1000);
                    jQuery('#SecondSearch').hide();
                    jQuery('#firstSearch').hide();
                    COMMON.HideProgress();
                    jQuery('#advanced').modal('hide');
                    return true;
                }
                jQuery('#firstSearch').hide(300);
                jQuery('#SecondSearch').show();
                jQuery('#SearchData').html('');
                var result = JSON.parse(data);
                var htmldata = '';
                jQuery.each(result.$values, function (val, anuncio) {
                    htmldata += '<tr><td><div class="row-fluid">';
                    htmldata += '<div class="span12 booking-blocks"> ';
                    htmldata += '<div class="span10">';
                    htmldata += '<div class="pull-left booking-img">';
                    htmldata += '<img src=' + anuncio.FirstImage + ' alt=' + anuncio.Usuario + '> ';
                    htmldata += '<ul class="unstyled">';
                    htmldata += '<li><ul class="unstyled inline"><li><div class="ratyclass" id=' + "toraty" + val + '  ratyval= ' + anuncio.Rating + ' style="width:20px;" ></div </li></ul></li>'
                    htmldata += '</ul>';
                    htmldata += '</div>';
                    htmldata += '<div style="overflow: hidden;">';
                    htmldata += '<h2><a href="javascript:SeeAnuncios(' + anuncio.AnunciosInfo.AN_Id + ');">' + anuncio.AnunciosInfo.AN_Titulo + '</a> (' + anuncio.Comments + ' Reviews)</h2> ';
                    htmldata += '<b>' + anuncio.Usuario + '</b>';
                    htmldata += '<ul class="unstyled inline">';
                    htmldata += '<li><i class="icon-calendar"></i>' + ShortDateTime(anuncio.AnunciosInfo.AN_Fecha) + ' </li>&nbsp;';
                    htmldata += '<li><i class="icon-briefcase"></i>' + anuncio.CategoriaDescripcion + '</li> ';
                    htmldata += '<li><i class="icon-map-marker"></i>' + anuncio.AnunciosInfo.AN_Area + '</li>';
                    htmldata += '</ul>';
                    htmldata += '<p>' + anuncio.AnunciosInfo.AN_Descripcion + '</p>';
                    htmldata += '</div>';
                    htmldata += '</div>';
                    htmldata += '<div class="span2">';
                    htmldata += '<button onclick="SeeAnuncios(' + anuncio.AnunciosInfo.AN_Id + ');"class="btn-u btn-u-orange btn-block"><i class="icon-white icon-plus"></i>&nbsp;Leer Más</button>';
                    htmldata += '<button onclick="TakeService(' + anuncio.AnunciosInfo.AN_Id + ');" class="btn-u btn-u-orange btn-block"><i class="icon-white icon-ok"></i>&nbsp;Solicitar</button>';
                    htmldata += '</div>';
                    htmldata += '</div>';
                    htmldata += '</div></td> </tr>';
                });
                jQuery('#SearchData').prepend(htmldata);
                $ki("div.holder").jPages({
                    containerID: "SearchData",
                    //              previous: "←",
                    //              next: "→",
                    first: "Primera",
                    previous: "Anterior",
                    next: "Siguiente",
                    last: "Última",
                    perPage: 7,
                    delay: 20
                });
                jQuery('.ratyclass').each(function (i, elem) {
                    var ratyvalue = $(this).attr('ratyval');
                    $ki(this).raty({ readOnly: true, score: ratyvalue });
                });
                COMMON.HideProgress();
                jQuery('#advanced').modal('hide');

            },
            error: function (xhr) {
                COMMON.HideProgress();
            }
        });
    }

    HOME.TakeService = function (anuncioid, url, nombre, titulo) {
        debugger;
        var mensaje;
        var data = new FormData();
        data.append("Anuncio", anuncioid);

        mensaje = 'Ha hecho clic en la opción contactar el servicio: <b>"' + titulo + '"</b>. Pronto estaremos enviándole un correo a ' + nombre + ' como parte del proceso de solicitud de servicios de Service Market. ¿Confirma que desea solicitar el servicio?';
        bootbox.confirm(mensaje, "Cancelar", "Aceptar", function (result) {
            if (result) {
                $.ajax({
                    url: url,//'@Url.Action("TakeService", "SolicitudServicio")',
                    type: 'post',
                    data: data,
                    cache: false,
                    contentType: false,
                    processData: false,
                    beforeSend: function () {
                        COMMON.CallProgress(LoadingImage);
                    },
                    complete: function (data) {
                        COMMON.HideProgress();
                    },
                    success: function (data) {
                        debugger;

                        if (data.Message != null | data.Message != undefined) {
                            $.gritter.add({
                                title: 'Solicitud cancelada por SMA',
                                text: data.Message
                            });
                        }
                        else {
                            $.gritter.add({
                                title: 'Servicio Solicitado',
                                text: 'El servicio ha sido solicitado satisfactoriamente. El anunciante recibirá un correo electrónico con sus datos para poder contactarle. Gracias por preferirnos.'
                            });
                        }
                        //$("#anunciosAvailable").prepend('<div class="alert alert-success fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong>Servicio Solicitado!</strong> En breves horas el anunciante se debe contactar con usted para coordinar cita.</div>');
                        //$('.alert').alert();
                        //$('.alert').fadeOut(3000)
                        //  alert('El servicio ha sido solicitado satisfactoriamente.', 'Solicitud de Servicio');
                    },
                    error: function (xhr) {
                        debugger;
                        if (xhr.status == 403) {
                            var response = $.parseJSON(xhr.responseText);
                            window.location = response.LogOnUrl;
                        }
                        else {
                            alert(xhr.responseText, 'An error has ocurred');
                        }
                    }
                });
            }
        });
    }

    ANUNCIOS.PostComment = function (element, userId, url) {
        debugger;
        var review = $(element).attr('data-val');
        var commentElement = "#comentario-" + review;

        var comment = {
            "UserId": userId,
            "CR_Comentario": $(commentElement).val(),
            "RW_Id": review
        };

        var jsonSerialized = JSON.stringify(comment);
        $.ajax({
            url: url,
            type: 'post',
            data: jsonSerialized,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                COMMON.CallProgress(LoadingImage);
            },
            complete: function (data) {
                COMMON.HideProgress();
            },
            success: function (data) {
                $(commentElement).val('');
                var result = JSON.parse(data);
                var html = '';
                var carusel = $("#testimonials-" + review).find('.carousel-inner');
                html += '<div class="item">';
                html += ' <p>' + result.data.Comments + '</p>';
                html += '         <div class="testimonial-info">';
                html += '   <img src="' + result.data.Image + '" width="90px" height="60px" alt="">';
                html += '      <span class="testimonial-author">' + result.data.Name + '';
                html += '         <em>Visitor</em>';
                html += '      </span>';
                html += '   </div>';
                html += ' </div>';
                carusel.append(html);
                jAlert('Comentario publicado.');
            },
            error: function (xhr) {
                if (xhr.status == 403) {
                    var response = $.parseJSON(xhr.responseText);
                    window.location = response.LogOnUrl;
                }
                else {
                    alert(xhr.responseText, 'An error has ocurred');
                }
            }
        });
    }

    ANUNCIOS.DeleteResource = function (id, url, urlLoader) {
        jQuery.ajax(
        {
            type: 'POST',
            url: url + id,
            success: function (data) {
                var element = jQuery(".thumbnails").find('li[itemid= ' + id + ' ]');
                element.remove();
                ANUNCIOS.EnableLoader(urlLoader);
            },
            error: function (a, b, c) {
                alert(a);
            }
        });
    }

    ANUNCIOS.EnableLoader = function (url) {
        jQuery.ajax(
           {
               type: 'GET',
               url: url,

               success: function (data) {
                   jQuery('.divLoader').html(data);
               },
               error: function (a, b, c) {
                   alert(a);
               }
           });
    }

    ANUNCIOS.InactivateAnuncio = function (id, url, self) {
        var titulo;
        var mensaje;
        var estado = $(self).attr('data-estado');

        if (estado == 'Activo') {
            titulo = 'Cambiar el estado del anuncio';
            mensaje = '¿Desea desactivar el anuncio?';
        }
        else {
            titulo = 'Cambiar el estado del anuncio';
            mensaje = '¿Desea activar el anuncio?';
        }

        bootbox.confirm(mensaje, "Cancelar", "Aceptar", function (result) {
            if (result) {
                jQuery.ajax(
               {
                   type: 'post',
                   url: url,
                   data: { id: id },
                   beforeSend: function () {
                       COMMON.CallProgress(LoadingImage);
                   },
                   complete: function (data) {
                       COMMON.HideProgress();
                   },
                   success: function (data) {
                       if (estado == "Activo") {
                           $(self).find("span").text("Activar");
                           $(self).attr("data-estado", "Inactivo");

                           $.gritter.add({
                               title: 'Anuncio Desactivado',
                               text: 'El anuncio ha sido desactivado satisfactoriamente.'
                           });

                       }
                       else {
                           $(self).find("span").text("Desactivar");
                           $(self).attr("data-estado", "Activo");

                           $.gritter.add({
                               title: 'Anuncio Activado',
                               text: 'El anuncio ha sido activado satisfactoriamente.'
                           });
                       }
                   },
                   error: function (xhr) {
                       if (xhr.status == 403) {

                       }
                       else {
                           if (xhr.responseText != "")
                               bootbox.alert("<h1>A ocurrido un error</h1> <br />" + xhr.responseText, function () {
                               });
                       }
                   }
               });
            }
        });
    }

    ANUNCIOS.DeleteAnuncio = function (id, url, self) {
        var anuncio = $(self).closest(".booking-blocks");

        bootbox.confirm("¿Desea eliminar el anuncio publicado?", "Cancelar", "Aceptar", function (result) {
            debugger;
            if (result) {
                jQuery.ajax(
               {
                   type: 'post',
                   url: url,
                   data: { id: id },
                   beforeSend: function () {
                       COMMON.CallProgress(LoadingImage);
                   },
                   complete: function (data) {
                       COMMON.HideProgress();
                   },
                   success: function (data) {
                       anuncio.remove();
                       $.gritter.add({
                           title: 'Anuncio Eliminado',
                           text: 'El anuncio ha sido eliminado satisfactoriamente. Gracias por preferirnos.'
                       });
                   },
                   error: function (xhr) {
                       if (xhr.status == 403) {

                       }
                       else {
                           if (xhr.responseText != "")
                               bootbox.alert("<h1>A ocurrido un error</h1> <br />" + xhr.responseText, function () {
                               });
                       }
                   }
               });
            }
        });

    }

    ANUNCIOS.ValidateCreate = function (url) {
        $.ajax({
            url: url,
            type: 'get',
            dataType: "json",
            contentType: "application/json; charset=utf-8",

            success: function (data) {
                if (data.ErrorMessage != null | data.ErrorMessage != undefined) {
                    $.gritter.add({
                        title: 'Límite de anuncios publicados superado.',
                        text: data.ErrorMessage
                    });
                }
                else if (data.UrlAnuncios != null | data.UrlAnuncios != undefined) {
                    window.location = data.UrlAnuncios;
                }
            },
            error: function (xhr) {
                if (xhr.status == 403) {
                    var response = $.parseJSON(xhr.responseText);
                    window.location = response.LogOnUrl;
                }
                else {
                    alert(xhr.responseText, 'An error has ocurred');
                }
            }
        });
    }

    ANUNCIOS.SetDropDowns = function () {

        var selectpa = $('#PA_Id').attr("paid");
        var selectca = $('#CD_Id').attr("cdid");
        var selectsc = $('#SBS_Id').attr("scid");
        $('#PA_Id option').each(function () {
            if ($(this).val() == selectpa) {
                $(this).prop("selected", true);
                return false;
            }
        });
        $('#CD_Id option').each(function () {
            if ($(this).val() == selectca) {
                $(this).prop("selected", true);
                return false;
            }
        });
        $('#SBS_Id option').each(function () {
            if ($(this).val() == selectsc) {
                $(this).prop("selected", true);
                return false;
            }
        });

    }

    CONTACTOS.Create = function (url, nombre, telefono, celular, email, mensaje) {

        var contacto = {
            "CON_Id": 0,
            "CON_Nombre": nombre,
            "CON_Telefono": telefono,
            "CON_Celular": celular,
            "CON_Email": email,
            "CON_Mensaje": mensaje,
            "CON_Fecha": new Date()
        };

        var jsonSerialized = JSON.stringify(contacto);

        jQuery.ajax(
              {
                  type: 'post',
                  url: url,
                  data: jsonSerialized,
                  dataType: "json",
                  contentType: "application/json; charset=utf-8",
                  beforeSend: function () {
                      COMMON.CallProgress(LoadingImage);
                  },
                  complete: function (data) {
                      COMMON.HideProgress();
                  },
                  success: function (data) {
                      if (data.wasSuccess == "True") {
                          $.gritter.add({
                              title: 'Mensaje Enviado',
                              text: 'Hemos registrado satisfactoriamente su mensaje. Pronto le estaremos contactando para responder a sus consultas. Gracias por preferirnos.'
                          });
                      }
                      else {
                          $.gritter.add({
                              title: 'Datos insuficientes',
                              text: 'Le informamos que no se ha podido enviar su mensaje debido a que no ha completado todos los datos requeridos (*). Gracias por preferirnos.'
                          });
                      }

                  },
                  error: function (xhr) {
                      if (xhr.status == 403) {

                      }
                      else {
                          if (xhr.responseText != "")
                              bootbox.alert("<h1>A ocurrido un error</h1> <br />" + xhr.responseText, function () {
                              });
                      }
                  }
              });
    }
});