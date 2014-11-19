var alumnosApp = angular.module('alumnosApp', ['ngRoute', 'factories', 'controllers']);
alumnosApp.controller(controllers);  //aqui estan los modelos.
alumnosApp.factory(factories); //sabe como hacer los request (Get, put, post, delete) al controller web api

alumnosApp.config(function ($routeProvider) {
    $routeProvider.
    when('/', {//la ruta o el url ra[iz que es el index.
        templateUrl: 'Scripts/AngularApp/Views/Index.html'
    }).when('/edit/:id', {//: para poner una variable
        templateUrl: 'Scripts/AngularApp/Views/Edit.html'
    }).when('/view/:id', {
        templateUrl: 'Scripts/AngularApp/Views/View.html'
    }).when('/new', {
        templateUrl: 'Scripts/AngularApp/Views/New.html'
    }).otherwise({
        redirectTo: '/'
    });
});