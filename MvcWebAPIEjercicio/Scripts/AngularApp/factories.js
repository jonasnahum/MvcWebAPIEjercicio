var factories = angular.module('factories', []); //declaramos el modulo factories

function getUrl(id) {
    var url = "api/Servicios/";
    id = id || "";
    return url + id;
}

factories.servicesFactory = function ($http) {//esto equivale al ajax.
    var factory = {};

    factory.callService = function (tipo, callback, id, data) {
        var promise = createRequest(tipo, getUrl(id), data);//crea un request.
        success(promise, callback);//recibe el resultado de la promesa que se hace al webController y la pone el el callback.
        renderError(promise);
    }

    function renderError(promise) {
        promise.error(function (data, status, headers, config) {
            $("body").html(data.MessageDetail);
        });
    }

    function createRequest(tipo, url, data) {

        var promise = $http({   //esto equivale al ajax.
            method: tipo,       //method equivale al tipo GET,POST,PUt, etc.
            url: url,
            data: data        //equivale al data.
        });

        return promise;
    }

    function success(promise, callback) {
        promise.success(function (d) {
            callback(d);
        });
    }

    return factory;
}