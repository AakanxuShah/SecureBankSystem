$(document).ready(function () {
    var url = window.location;
    $('ul.nav a[href="' + url + '"]').parent().addClass('active');
    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('active');
});

function setKey()
{
    $.ajax({
        type: "POST",
        url: "Home.aspx/GetKey",
        data: {},
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Something went worng. Could not generate the key for decrypting data !");
        },
        success: function (result) {
            alert(result.d);
            window.localStorage.setItem("key", result.d);
        }
    });
}


function setPublicKey() {
    $.ajax({
        type: "POST",
        url: "Home.aspx/GetPublicKey",
        data: {},
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Something went wrong. Could not generate the key for encrypting data !");
        },
        success: function (result) {
            window.localStorage.setItem("publickey", result.d);
        }
    });
}