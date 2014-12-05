
describe("url returns valid addresses", function () {
    
    beforeEach(function () {
        angular.module('url');
    });

    it("url without id", function () {
        //arrangement
        var expected = "api/Servicios/";

        //act
        var result = url.webApi();

        //assert
        expect(expected).toBe(result);
    });

    it("url with id", function () {
        //arrangement
        var id = 9;
        var expected = "api/Servicios/" + id;

        //act
        var result = url.webApi(id);

        //assert
        expect(expected).toBe(result);
    });
});

