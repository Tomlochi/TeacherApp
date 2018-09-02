$(document).ready(function () {

    $('#UserLogin').on('click', function (event) {
        $.post(
            "AdminPanelLogin",
            { username: $('#inputEmail').val(), password: $('#inputPassword').val() },
            function (result) {
                if (result) {
                    setCookie('userEmail', $('#inputEmail').val(), 1);
                    setCookie('userPassword', $('#inputPassword').val(), 1);
                    setCookie('userID', result, 1);
                    setCookie('IsAdmin', 'true', 1);
                    window.location.replace("http://localhost:55264/AdminPanel/Dashboard");
                }
                else {
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

