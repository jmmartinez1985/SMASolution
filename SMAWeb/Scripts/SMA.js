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
});

function CreateCategoria(data) {
    var Titulo = 'Creación de Categoría';
    var Mensaje = '';
    var TipoAlerta = '';
    debugger;
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