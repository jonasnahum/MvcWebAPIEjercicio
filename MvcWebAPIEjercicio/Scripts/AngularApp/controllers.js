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
        servicesFactory.callService("GET", function (alumnos) {//consigue el modelo del web controler con estos parametros.
            $scope.alumnos = alumnos;//ahora si le pone el modelo cargado a alumnos.//creo que este es el callback
        });
        function deleteItem(id) {
            servicesFactory.callService("DELETE", function () {
                servicesFactory.callService("GET", function (alumnos) {//consigue el modelo del web controler con estos parametros.
                    $scope.alumnos = alumnos;//ahora si le pone el modelo cargado a alumnos.//creo que este es el callback
                })
            }, id);
        };

        $scope.delete = function (id) {
            if (confirm("¿Desea borrar el alumno con id:" + id + "?")) {
                deleteItem(id);
            }
        };
    },

    newController: function ($routeParams, $scope, $location, servicesFactory) {//se trata acerca de new de la vista.
        $scope.alumno = {//este es el modelo? que viene de la vista y se pone el el servicios controller
            id: 0,
            nombre: '',
            promedio: 0.0,
            grado: ''
        };

        var goToIndex = function () {//un delegado o callback. variable que guarda un metodo.
            $location.path("/");//regresar al index.
        };

        $scope.save = function () {
            servicesFactory.callService("POST", goToIndex, null, $scope.alumno);//goToIndex es callback,$scope.alumno equivale al data,
        };

        $scope.cancell = goToIndex;
    },

    editController: function ($routeParams, $scope, $location, servicesFactory) {//se trata acerca de new de la vista.
        $scope.alumno = {};

        var goToIndex = function () {//un delegado o callback. variable que guarda un metodo.
            $location.path("/");//regresar al index.
        };

        var loadData = function (alumno) {
            $scope.alumno = alumno;
        };

        servicesFactory.callService("GET", loadData, $routeParams.id);

        $scope.save = function () {
            servicesFactory.callService("PUT", goToIndex, $routeParams.id, $scope.alumno);//goToIndex es callback,$scope.alumno equivale al data,
        };

        $scope.cancell = goToIndex;
    },
    viewController: function ($routeParams, $scope, $location, servicesFactory) {//se trata acerca de new de la vista.
        $scope.alumno = {};

        var goToIndex = function () {//un delegado o callback. variable que guarda un metodo.
            $location.path("/");//regresar al index.
        };

        var loadData = function (alumno) {
            $scope.alumno = alumno;
        };

        servicesFactory.callService("GET", loadData, $routeParams.id);

        
        $scope.cancell = goToIndex;
    }

}