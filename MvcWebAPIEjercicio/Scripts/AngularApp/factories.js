var factories = angular.module('factories', []); //declaramos el modulo factories

function getUrl(id) {
    var url = "api/Servicios/";
    id = id || "";
    return url + id;
}

factories.servicesFactory = function ($http) {//esto equivale al ajax.
    var factory = {};

    factory.callService = function (tipo, callback, id, data) {
        var promise = createRequest(tipo, getUrl(id), data);
        success(promise, callback);
        renderError(promise);
    }

    function renderError(promise) {
        promise.error(function (data, status, headers, config) {
            $("body").html(data.MessageDetail);
        });
    }

    function createRequest(tipo, url, data) {        
        var promise = $http({
            method: tipo,
            url: url,
            params: data
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