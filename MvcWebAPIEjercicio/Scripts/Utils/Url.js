(function () {
    this.utils = this.utils || {};
    var ns = this.utils;
    
    ns.Url = (function () {
        function Url() {
            /// <summary>
            /// Class used for create urls
            /// </summary>
            Url.prototype.webApi = function (id) {
                /// <summary>
                /// Creates a call to api/Servicios and optionally adds id.
                /// </summary>
                /// <param name="id"></param>
                /// <returns type=""></returns>
                var url = "api/Servicios/";
                id = id || "";
                return url + id;
            };
        }
        return Url;
    })();
        
}());