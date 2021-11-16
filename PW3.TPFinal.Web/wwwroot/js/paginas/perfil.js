var abrirCancelarEventoModal = function (idEvento) {
    $("#cancelarEventoModal").modal('show');
    $("#idEventoACancelar").val(idEvento);
};

var cancelarEvento = function () {
    var idEvento = $("#idEventoACancelar").val();

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
    }).then((sucessResponse) => {
        console.log(sucessResponse);
    }, (errorResponse) => {
        console.log(errorResponse);
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