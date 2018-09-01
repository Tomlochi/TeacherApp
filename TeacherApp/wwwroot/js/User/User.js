$(document).ready(function () {

    $('#UserLogin').on('click', function (event) {
            $.post(
                "UserLogin",
                { username: $('#inputEmail').val(), password: $('#inputPassword').val() },
                function (result)   
                {
                    if (result)
                    {
                        setCookie('userEmail', $('#inputEmail').val(), 1);
                        setCookie('userPassword', $('#inputPassword').val(), 1);
                        window.location.replace("http://localhost:55264/UserPanel/UserDashboard");
                    }
                    else
                    {
                        alert("Invalid Username/Password!");
                        window.location.replace("http://localhost:55264/UserPanel/UserLogin/");
                    }
                }
            );
        })
    });


    function setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setDate(d.getDate() + exdays);
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }


    function removeCookies() {
        var res = document.cookie;
        var multiple = res.split(";");
        for (var i = 0; i < multiple.length; i++) {
            var key = multiple[i].split("=");
            document.cookie = key[0] + " =; expires = Thu, 01 Jan 1970 00:00:00 UTC";
        }
    }

//$(function () {
//    $('.navbar-toggle-sidebar').click(function () {
//        $('.navbar-nav').toggleClass('slide-in');
//        $('.side-body').toggleClass('body-slide-in');
//        $('#search').removeClass('in').addClass('collapse').slideUp(200);
//    });

//    $('#search-trigger').click(function () {
//        $('.navbar-nav').removeClass('slide-in');
//        $('.side-body').removeClass('body-slide-in');
//        $('.search-input').focus();
//    });
//});