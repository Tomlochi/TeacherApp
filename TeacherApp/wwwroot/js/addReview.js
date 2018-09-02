$(document).ready(
    function () {
        console.log("document ready. loading js addReview..");
        // consider drop down list in view couses and maybe search by id
        if ($("#rating").val() === null) {
            alert("Please rate the teacher before submitting a review.")
            return
        }
        if ($("#reviewContent").val() === null || $("reviewContent").val() === "" ) {
            alert("Please add review content before submitting the review.")
            return
        }
        $("#publish").click(function () {
            console.log("Submit...");
            var teacherID
            try {
                teacherID = parseInt(location.pathname.split("/").slice(-1)[0]);
            } catch (err) {
                console.log("could not parse teacher id from path")
                alert("Something went wrong")
            }
            
            $.ajax(
                {
                    type: "POST",
                    url: "/Teachers/AddReview",
                    data: {
                        teacherID: teacherID,
                        text: $("#reviewContent").val(),
                        rating: parseInt($("#rating").val())
                    },
                    success: function (response) {
                        console.log("Submited review successfuly. Reloading page.");
                        location.reload();
                    },
                    error: function (res, status, err) {
                        console.log('Was unable to submit the review', status, err);
                        alert('Was unable to submit the review.\n' + res.responseJSON.message);
                    }
                },
            )
        });
    }
)