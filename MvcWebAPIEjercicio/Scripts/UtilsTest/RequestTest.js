test("Get url without id", 1, function () {
    //arrange
    var builder = new utils.Url();
    var url = builder.webApi();

    var request = new utils.Request({
        ajax: $.ajax,


    });
    expect(1);

    //act
    

    //assert
    equal(url, expectedUrl, "url without id");
});