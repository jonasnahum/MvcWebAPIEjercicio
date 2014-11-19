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
    indexController: function ($routeParams, $scope, servicesFactory) {        
        $scope.alumnos = null; // el modelo para la vista index

        //servicesFactory sabe como hacer los request (Get, put, post, delete) al controller web api
        servicesFactory.callService("GET", function (alumnos) {
            $scope.alumnos = alumnos;
        });
    }
}