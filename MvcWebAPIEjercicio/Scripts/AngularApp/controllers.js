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
    indexController: function ($routeParams, $scope, servicesFactory) {//se trata acerca de la vista index. y este controller tiene acceso a los routeParams que son dirrecciones url, al scope que es el modelo y al modulo de servicesFactories que es donde se hacen los request al api controller.        
        $scope.alumnos = null; // el modelo para la vista index hasta aqui es null               
        servicesFactory.callService("GET", function (alumnos) {//consigue el modelo del web controler con estos parametros.
            $scope.alumnos = alumnos;//este es el callback, lo que se va ejecutar cuando sea exitosa la llamada.
        });
        function deleteItem(id) {//le pasan el id de $scope.delete
            servicesFactory.callService("DELETE", function () {//este es el tipo, borra.
                servicesFactory.callService("GET", function (alumnos) {//vuelve a traer los alumnos para actualizarlos
                    $scope.alumnos = alumnos;//.este callback se ejecuta cuando sea exitoso el call .modelo cargado .
                })
            }, id);//tambien manda el id.
        };

        $scope.delete = function (id) {//recibe del modelo de la vista, del <a> delete(alumno.id)
            if (confirm("¿Desea borrar el alumno con id:" + id + "?")) {
                deleteItem(id);//se manda llamar esta funcion.
            }
        };
    },

    newController: function ($routeParams, $scope, $location, servicesFactory) {//se trata acerca de la vista new. y este controller tiene acceso a los routeParams que son dirrecciones url, al scope que es el modelo y al modulo de servicesFactories que es donde se hacen los request al api controller. y location es el route provider que se encuentra definido en alumnosApp.
        $scope.alumno = {//este es el modelo? que viene de la vista y se pone el el servicios controller
            id: 0,
            nombre: '',//se bindea de la vista as[i:data-ng-model="alumno.nombre" />
            promedio: 0.0,
            grado: ''
        };

        var goToIndex = function () {//un delegado o callback. variable que guarda un metodo.
            $location.path("/");//regresar al index. se puede hacer esto gracias a los parametros que recibe newController
        };

        $scope.save = function () {
            servicesFactory.callService("POST", goToIndex, null, $scope.alumno);//goToIndex es callback que se ejecuta cuando sea exitoso el call,$scope.alumno equivale al data,
        };

        $scope.cancell = goToIndex;
    },

    editController: function ($routeParams, $scope, $location, servicesFactory) {//se trata acerca de la vista edit. y este controller tiene acceso a los routeParams que son dirrecciones url, al scope que es el modelo y al modulo de servicesFactories que es donde se hacen los request al api controller. y location es el route provider que se encuentra definido en alumnosApp.
        $scope.alumno = {};

        var goToIndex = function () {//un delegado o callback. variable que guarda un metodo.
            $location.path("/");//regresar al index.
        };

        var loadData = function (alumno) {
            $scope.alumno = alumno;
        };

        servicesFactory.callService("GET", loadData, $routeParams.id);

        $scope.save = function () {//se manda llamar primero este metodo, el parametro $routeParams.id de callService viene de la url gracias al <a href="#/edit/{{alumno.id}}"> que se encuentra en la vista index.los<a> sirven para poner url.
            servicesFactory.callService("PUT", goToIndex, $routeParams.id, $scope.alumno);//goToIndex es callback que se ejecuta en el call,$scope.alumno equivale al data,
        };

        $scope.cancell = goToIndex;
    },
    viewController: function ($routeParams, $scope, $location, servicesFactory) {//se trata acerca de la vista view. y este controller tiene acceso a los routeParams que son dirrecciones url, al scope que es el modelo y al modulo de servicesFactories que es donde se hacen los request al api controller. y location es el route provider que se encuentra definido en alumnosApp.
        $scope.alumno = {};

        var goToIndex = function () {//un delegado o callback. variable que guarda un metodo.
            $location.path("/");//regresar al index.
        };

        var loadData = function (alumno) {
            $scope.alumno = alumno;//para que en la view le escriban  nombre: {{alumno.nombre}}
        };

        servicesFactory.callService("GET", loadData, $routeParams.id);//el parametro $routeParams.id viene de la Url gracias al <a href="#/view/{{alumno.id}}"> que se encuentra en la vista index. los<a> sirven para poner url.

        
        $scope.cancell = goToIndex;
    }

}