$(document).ready(function () {

    //var loginButton = $('.login100-form-btn');
    ////var user = ReadCookie();
    //var user = getUserNameFromCookie();
    ////consol.log(user);
    //var text = $('.intro').find('p').prepend("<b style=\"font-size: 16px;\">ברוכים הבאים " + user + "! </b> <br>");

    //loginButton.on('click', function (event) {
    //    removeCookies();
    //    var username = $('.form-control').find('#inputEmail').val();
    //    console.log('welcome: ' + username + ' !');
    //    setCookie('username', username, 1);
    //});


    //var loginButton = $('.login100-form-btn');
    var loginButton = $('.login100-form-btn');
    var user = getUserNameFromCookie();
    var text = $('.intro').find('p').prepend("<b style=\"font-size: 16px;\">ברוכים הבאים " + user + "! </b> <br>");

    '1'
    loginButton.on('click', function (event) {

        var user = ($('#username').val());
        var pass = ($('#password').val());
        //  console.log(user, password);
        console.log('clicked..');
        if (user && pass) {
            var auth = {
                username: user,
                password: pass
            }
            var stringJson = JSON.stringify(auth);
            console.log(auth);
            console.log(stringJson);

            $.ajax({
                url: "UserLogin",
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                dataType: "json",
                data: JSON.stringify({ username: "user", password: "pass" }),
                success: window.location.replace("http://localhost:55264/"),
                error: window.location.replace("http://localhost:55264/UserPanel/UserLogin/");
            });



            //$.post("UserLogin", JSON.stringify[{ user: stringJson }], function (result) {
            //    if (result === "true") {
            //        console.log("hellow user")
            //        window.location.replace("http://localhost:55264/");
            //    } else {
            //        alert("invalid input !");
            //        window.location.replace("http://localhost:55264/UserPanel/UserLogin/");
            //    }
            //});
        }
    });



    //    loginButton.on('click', function (event) {
    //    var user = ($('#username').val());
    //    var pass = ($('#password').val());
    //    console.log('clicked..');
    //    if (user && pass) {
    //        var auth = {
    //            username: user,
    //            password: pass
    //        }
    //        var stringJson = JSON.stringify(auth);
    //        console.log(auth);
    //        $.post("AuthUser", { user: stringJson }, function (result) {
    //            if (result === "true") {
    //                window.location.replace("http://localhost:55264/UserPanel/UserLogin");
    //            } else {
    //                alert("invalid input !");
    //                window.location.replace("http://localhost:55264/");
    //            }
    //        });
    //    }
    //})


    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setDate(d.getDate() + exdays);
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    function getUserNameFromCookie() {
        var name = "Email";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            ;
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }

    function removeCookies() {
        var res = document.cookie;
        var multiple = res.split(";");
        for (var i = 0; i < multiple.length; i++) {
            var key = multiple[i].split("=");
            document.cookie = key[0] + " =; expires = Thu, 01 Jan 1970 00:00:00 UTC";
        }
    }


    // **************************



});