﻿var alumnosApp = angular.module('alumnosApp', ['ngRoute', 'factories', 'controllers']);//se crea una App y se referencian unos modulos.
alumnosApp.controller(controllers);  //aqui estan los modelos.
alumnosApp.factory(factories); //sabe como hacer los request (Get, put, post, delete) al controller web api

alumnosApp.config(function ($routeProvider) {//esto equvale al RouteConfig de mvc,primero pone la ruta de mvc luego # y luego la ruta esta.. que son vistas html.
    $routeProvider.
    when('/', {//la ruta o el url ra[iz que es el index.
        templateUrl: 'Scripts/AngularApp/Views/Index.html'//son html no cshtml.
    }).when('/edit/:id', {//se usa ':' para poner una variable
        templateUrl: 'Scripts/AngularApp/Views/Edit.html'
    }).when('/view/:id', {
        templateUrl: 'Scripts/AngularApp/Views/View.html'
    }).when('/new', {
        templateUrl: 'Scripts/AngularApp/Views/New.html'
    }).otherwise({
        redirectTo: '/'
    });
});