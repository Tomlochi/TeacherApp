﻿$(function () {
    $('.navbar-toggle-sidebar').click(function () {
        $('.navbar-nav').toggleClass('slide-in');
        $('.side-body').toggleClass('body-slide-in');
        $('#search').removeClass('in').addClass('collapse').slideUp(200);
    });

    $('#search-trigger').click(function () {
        $('.navbar-nav').removeClass('slide-in');
        $('.side-body').removeClass('body-slide-in');
        $('.search-input').focus();
    });
});

$(document).ready(function () {
    $('#UserLogin').on('click', function (event) {
        $.post(
            "AdminPanelLogin",
            { username: $('#inputEmail').val(), password: $('#inputPassword').val() },
            function (result) {
                if (result) {
                    console.log("hello " + $('#inputEmail').val());
                    window.location.replace("http://localhost:55264/AdminPanel/Dashboard");
                }
                else {
                    alert("Invalid Username/Password!");
                    window.location.replace("http://localhost:55264/AdminPanel/AdminPanelLogin/");
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