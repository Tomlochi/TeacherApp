
$(document).ready(function () {
    $('#Dashbored').on('click', function (event) {
        var x = document.cookie
        var isadmin = getIsAdminFromCookie();
        console.log(isadmin);
        if (isadmin === 'true') {
            window.location.replace("http://localhost:55264/AdminPanel/Dashboard/");
        }
        else {
            window.location.replace("http://localhost:55264/UserPanel/UserDashboard/");
        }
    })

    function getIsAdminFromCookie() {
        var name = "IsAdmin=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
})
