﻿var factories = angular.module('factories', ['url']); //declaramos el modulo factories

factories.servicesFactory = function ($http) {//este metodo solo tiene factory y factory solo tiene callService., y regresa y al ultimo, aquel metodo regresa factory.
    var factory = {};//se crea un objeto vacio

    factory.callService = function (tipo, callback, id, data) {//se agrega una propiedad callService al que era un objeto vacío que es igual a un metodo.
        var promise = createRequest(tipo, url.webApi(id), data);//crea un request.
        success(promise, callback);//recibe el resultado de la promesa que se hace al webController y la pone el el callback.
        renderError(promise);
    }

    function renderError(promise) {//metodo privado.
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