$(document).ready(function ()
{
    // set btn name
    // set input name
    // set tbBody on html page
    // consider drop down list in view couses and maybe search by id
    $("#btn-name").click(
        $.ajax(
            {
                type: "POST",
                url: "SearchBestOffer",
                data: { courseName: $("#course").val },
                dataType: 'json',
                success: function (response) {
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
                    $('#tBody').append(trHTML);
                },
                error: function (req, status, err) {
                    console.log('something went wrong', status, err);
                }
            },
            
        )
    )
}
)