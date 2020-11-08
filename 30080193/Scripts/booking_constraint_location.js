// booking conflict constraint
$("#booking_loc").on('change', function () {
    var booking_date = document.getElementById("booking_date").value;
    var booking_time = document.getElementById("booking_time").value;
    var booking_hours = document.getElementById("booking_hours").value;
    var booking_loc = document.getElementById("booking_loc").value;
    var booking_end_time = "00:00";
    var endhr;
    if ((booking_time.length < 10) && (booking_time.length > 6)) { // if time is xx:xx AM or PM, get time only
        if (booking_time.substring(booking_time.length - 2, booking_time.length) == "AM") {
            booking_time = booking_time.substring(0, booking_time.length - 3);
        } else {
            if (parseInt(booking_time.substring(0, 2)) == 12) //if its 12:00 PM
            {
                booking_time = booking_time.substring(0, booking_time.length - 3);
            }
            else {
                var hr = parseInt(booking_time.substring(0, 1)) + 12;
                booking_time = hr + booking_time.substring(1, booking_time.length - 3);
            }
        }
        endhr = parseInt(booking_time.substring(0, 2)) + parseInt(booking_hours);
        booking_end_time = endhr + booking_time.substring(booking_time.length - 3, booking_time.length);
    }
    else if (booking_time.length > 10) { // if time is xxxx/xx/xx xx:xx
        booking_time = booking_time.substring(booking_time.length - 5, booking_time.length);
        endhr = parseInt(booking_time.substring(0, 2)) + parseInt(booking_hours);
        booking_end_time = endhr + booking_time.substring(booking_time.length - 3, booking_time.length);
    }
    var is_conflict = false;
    // get date, starttime end time and locaiton from index.cshtml
    var dt = localStorage.getItem("dt").split(",").map(function (item) {
        return item.trim();
    });
    var start = localStorage.getItem("start").split(",").map(function (item) {
        return item.trim();
    });
    var end = localStorage.getItem("end").split(",").map(function (item) {
        return item.trim();
    });
    var loc = localStorage.getItem("loc").split(",").map(function (item) {
        return item.trim();
    });
    var i;
    for (i = 0; i < start.length; i++) {
        var clock = start[i];
        var clock_end_time = end[i];
        var location = loc[i];
        // first check if the location is the same
        if (location == booking_loc) {
            // then check date : year month and day
            if ((dt[i].substring(0, 4) == booking_date.substring(0, 4)) && (dt[i].substring(5, 7) == booking_date.substring(5, 7)) && (dt[i].substring(8, 10) == booking_date.substring(8, 10))) {
                // case 1: two events happen at the same time
                if (booking_time == clock) {
                    is_conflict = true;
                    break;
                }
                // case 2: this event happens first, then followed by other's but conflict
                if ((booking_time < clock) && (booking_end_time > clock)) {
                    is_conflict = true;
                    break;
                }
                // case 3: this event happens later
                if ((clock < booking_time) && (clock_end_time > booking_time)) {
                    is_conflict = true;
                    break;
                }
            }
        }
    }

    if (is_conflict) {
        alert("Time conflict! Please go check the calendar!");
        document.getElementById("booking_date").value = "";
        document.getElementById("booking_time").value = "";
    }
});
