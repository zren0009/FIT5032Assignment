// add date to time when submit because they are both of datetime format
// use two datetime to show and edit date and time separately
$("#btn_subbooking").click(function () {
    var booking_date = document.getElementById("booking_date").value;
    var booking_time = document.getElementById("booking_time").value;
    if ((booking_time.length < 10) && (booking_time.length > 6)) {
        if (booking_time.substring(booking_time.length - 2, booking_time.length) == "AM") {
            document.getElementById("booking_time").value = booking_date + " " + booking_time.substring(0, booking_time.length - 3);
        } else {
            var hr = parseInt(booking_time.substring(0, 1)) + 12;
            document.getElementById("booking_time").value = booking_date + " " + hr + ":" + booking_time.substring(2, booking_time.length - 2);
        }   
    }
    if (booking_time.length < 6) {
        alert("Please select a time!");
    }
});

