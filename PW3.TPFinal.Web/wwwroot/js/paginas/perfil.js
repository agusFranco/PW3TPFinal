var abrirCancelarEventoModal = function (idEvento) {
    $("#cancelarEventoModal").modal('show');
    $("#idEventoACancelar").val(idEvento);
};

var cancelarEvento = function () {
    let idEvento = $("#idEventoACancelar").val();
    let estadoElement = $(`#evento-${idEvento}-estado`);
    let buttonElement = $(`#evento-${idEvento}-button`);
    let mensajeElement = $("#mensaje");
    let contenedorMensaje = $("#contenedorMensaje");

    // Reset;
    contenedorMensaje.removeClass('alert-success');
    contenedorMensaje.removeClass('alert-danger');

    // url del servidor
    //$.ajax({
    //    url: 'https://localhost:44365/Eventos/prueba',
    //    contentType: 'application/json'
    //}).then((sucessResponse) => {
    //    console.log(sucessResponse);
    //}, (errorResponse) => {
    //    console.log(errorResponse);
    //});

    let ticketValue = 'bearer ' + getCookie('X-PW3-Ticket');

    $.ajax({
        method: 'DELETE',
        headers: {
            'Authorization': ticketValue
        },
        url: 'https://localhost:44365/Eventos/' + idEvento,
        contentType: 'application/json'
    }).then((response) => {
        mensajeElement.text(response.mensaje);
        contenedorMensaje.addClass(response.success ? 'alert-success' : 'alert-danger');
        contenedorMensaje.removeClass('d-initial-none');

        if (response.success) {
            estadoElement.text('Cancelado');
            buttonElement.attr('disabled', true);
        }
    }, (errorResponse) => {

    });
}

var getCookie = function (name) {
    let cookie = {};
    document.cookie.split(';').forEach(function (el) {
        let [k, v] = el.split('=');
        cookie[k.trim()] = v;
    })
    return cookie[name];
}

$(document).ready(function () {

});