$(document).ready(function () {
    // set btn name
    // set input name
    // set tbBody on html page
    // consider drop down list in view couses and maybe search by id
    $("#search").on('click',
        function (event) {
            console.log("clicked");
            console.log($("#searchParam").val());
            $.ajax(
                {
                    type: "POST",
                    url: "UserPanel/SearchBestOffer",
                    contentType: "application/json; charset=utf-8",
                    data: { courseName: $("#searchParam").val() },
                    dataType: 'json',
                    success: function (response) {
                        console.log("success")
                        $.each(response, function (i, elm) {
                            for (i = 0; i < resp.data.length; i++) {
                                trHTML +=
                                    '<tr><td>'
                                    + resp.elm[i].teaher
                                    + '</td><td>'
                                    + resp.elm[i].price
                                    + '</td><td>'
                            }
                        });
                        $('#results').append(trHTML);
                    },
                    error: function (req, status, err) {
                        console.log('something went wrong', status, err);
                    }
                },
            )
        }
    )
});
