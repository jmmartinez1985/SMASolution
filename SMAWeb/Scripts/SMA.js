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

jQuery(document).ready(function () {
    //jQuery('.validation-summary-errors').wrap('<div class="alert fade in"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button><strong><p></p></strong><p></p></div>').after('<div id="divBlanco"></div>');
    jQuery('.validation-summary-errors').addClass("alert alert-error");
    

    if (jQuery("#statusMessage").text().trim().length > 0) {
        jQuery('#statusMessage').addClass("alert alert-info");
        jQuery('#statusMessage').append('<button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>');
    }
    else {
        jQuery('#statusMessage').removeClass("alert alert-info");
    }

});



function CreateCategoria(data) {
    var Titulo = 'Creación de Categoría';
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
    jQuery('.alert').alert();
    jQuery('.alert').fadeOut(3000);

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

    return fechaDivida[2] + "/" + fechaDivida[1] + "/" +fechaDivida[0];
};