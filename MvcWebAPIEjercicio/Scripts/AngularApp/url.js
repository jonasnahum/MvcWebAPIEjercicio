var url = angular.module('url', []);

url.webApi = function (id) {
    /// <summary>
    /// Creates a call to api/Servicios and optionally adds id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns type=""></returns>
    var url = "api/Servicios/";
    id = id || "";
    return url + id;
};