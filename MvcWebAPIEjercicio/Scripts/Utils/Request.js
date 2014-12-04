(function () {
    this.utils = this.utils || {};
    var ns = this.utils;

    ns.Request = (function () {
        function Request(paramters) {            

            var _ajax = paramters.ajax || {};
            var _settings = paramters.settings || {};
            var _success = paramters.success || null;
            var _error = paramters.error || null;

            Request.prototype.create = function () {
                var promise = getPromise(_settings);
                if (_success) promise.success(_success);
                if (_error) promise.error(_error);

                return promise;
            };

        }
        return Request;
    })();

}());
