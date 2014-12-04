test("Get url without id", 1, function () {
    //arrange
    var expectedUrl = "api/Servicios/";
    expect(1);

    //act
    var builder = new utils.Url();
    var url = builder.webApi();

    //assert
    equal(url, expectedUrl, "url without id");
});

test("Get url with id", 2, function () {
    //arrange
    var id = 3;
    var expectedUrl = "api/Servicios/"+id;
    expect(1);//numero de asserts.

    //act
    var builder = new utils.Url();
    var url = builder.webApi(id);

    //assert
    equal(url, expectedUrl, "url with id");
});