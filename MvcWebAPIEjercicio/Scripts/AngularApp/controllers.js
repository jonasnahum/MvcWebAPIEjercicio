var controllers = angular.module('controllers', []);

//$routeParams.id
//servicesFactory.callService(tipo, callback, id, data)
//var alumnoModel = {
//    id: 0,
//    nombre: '',
//    promedio: 0.0,
//    grado: ''
//};

controllers = {
    indexController: function ($routeParams, $scope, servicesFactory) {//se trata acerca de la vista index.        
        $scope.alumnos = null; // el modelo para la vista index hasta aqui es null

        //servicesFactory sabe como hacer los request (Get, put, post, delete) al controller web api
        servicesFactory.callService("GET", function (alumnos) {//consigue el modelo del web controler con estos parametros.
            $scope.alumnos = alumnos;//ahora si le pone el modelo cargado a alumnos.
        });
    },
    newController: function ($routeParams, $scope, $location, servicesFactory) {
        $scope.alumno = {
            id: 0,
            nombre: '',
            promedio: 0.0,
            grado: ''
        };

        var goToIndex = function () {
            $location.path("/");//regresar al index.
        };

        $scope.save = function () {
            servicesFactory.callService("POST", goToIndex, null, $scope.alumno);//equivale al data,
        };

        $scope.cancell = goToIndex;
    }
}