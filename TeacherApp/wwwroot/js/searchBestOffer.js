$(document).ready(function () {
    console.log("document ready. loading js searchBestOffer..");
    // consider drop down list in view couses and maybe search by id
    $("#search").click(function () {
        console.log("Searching best offer for " + $("#searchParam").val() + " course");
        $.ajax(
            {
                type: "POST",
                url: "UserPanel/SearchBestOffer",
                //contentType: "application/json; charset=utf-8",
                data: { courseName: $("#searchParam").val() },
                //dataType: 'json',
                success: function (response) {
                    console.log("Prepering results for presentation")
                    //window.location.replace("http://localhost:55264/UserPanel/SearchBestOffer");
                    var trHTML = '';
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
    });
});
