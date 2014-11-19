$(function () {
    var url = 'api/Servicios';
    var id = 5;
    var urlId = url + '/' + id;
    var alumno = { nombre: 'rodrigo', promedio: 8.9, id: 4, grado: '1b' };
    var guardadoMsg = "Guardado";
    var encontradoMsg = "Encontrado";
    var borradoMsg = "Borrado";
    var httpCallType = ["GET", "PUT", "POST", "DELETE"];

    $.each(httpCallType, function (i, tipo) {
        switch (tipo) {
            case "GET":
                llamarServicio(tipo, urlId, encontradoMsg);
                llamarServicio(tipo, url, encontradoMsg);
                break;
            case "PUT":
                llamarServicio(tipo, urlId, guardadoMsg, alumno);
                break;
            case "DELETE":
                llamarServicio(tipo, urlId, borradoMsg);
                break;
            case "POST":
                llamarServicio(tipo, url, guardadoMsg, alumno);
                break;

        }
    });
})

function llamarServicio(tipo, url, mensage, data) {
    var promise = crearRequest(tipo, url, data);
    notificarUsuario(promise, mensage);
    manejarError(promise);
}

function manejarError(promise) {
    promise.error(function (a, b, c) {
        $("body").html(a.responseText);
    });
}

function crearRequest(tipo, url, data) {
    var promise = $.ajax({
        type: tipo,
        url: url,
        data: data
    });
    return promise;
}

function notificarUsuario(promise, texto) {
    promise.success(function () {
        alert(texto);
    });
}