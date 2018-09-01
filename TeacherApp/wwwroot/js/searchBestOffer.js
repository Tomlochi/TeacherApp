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
                    console.log("Prepering results for presentation");
                    if (response == null) {
                        console.log("No matching courses were found");
                        // add code
                    }
                    window.location.replace("http://localhost:55264/UserPanel/SearchBestOffer");
                    var trHTML = '';
                    $.each(response, function (i, elm) {
                        trHTML +=
                            '<tr><td>'
                            + elm.teacher
                            + '</td><td>'
                            + elm.rating
                            + '</td><td>'
                            + elm.price
                            + '</td><td>';
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
