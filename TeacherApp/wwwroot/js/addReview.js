$(document).ready(
    function () {
        console.log("document ready. loading js addReview..");
        // consider drop down list in view couses and maybe search by id
        if ($("rating").val() === null) {
            alert("Please rate the teacher before submitting a review.")
            return
        }
        if ($("reviewContent").val() === null || $("reviewContent").val() === "" ) {
            alert("Please add review content before submitting the review.")
            return
        }
        $("#publish").click(function () {
            console.log("Searching best offer for " + $("#searchParam").val() + " course");
            $.ajax(
                {
                    type: "POST",
                    url: "Teacher/AddReview",
                    data: {
                        id: $("#teacherID").val(),
                        text: $("reviewContent").val(),
                        rating: ($("rating").val()
                    },
                    success: function (response) {
                        console.log("Submited review successfuly. Reloading page.");
                        location.reload();
                    },
                    error: function (req, status, err) {
                        console.log('Was unable to submit the review', status, err);
                        alert('Was unable to submit the review');
                    }
                },
            )
        });
    }
)