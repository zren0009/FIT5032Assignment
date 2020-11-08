$(document).ready(function () {
    var bookings = [];
    $(".booking").each(function () {
        var location = $(".location", this).text().trim();
        var time = $(".time", this).text().trim();
        var clock = $(".clock", this).text().trim();
        var hour = $(".hours", this).text().trim();
        var booking = {
            "title": location + " " + clock + " " + hour + "h",
            "start": time
        };
        bookings.push(booking);
    });
    $("#calendar").fullCalendar({
        locale: 'au',
        events: bookings,
        dayClick: function (date, allDay, jsEvent, view) {
            var d = new Date(date);
            var tomorrow = new Date();
            tomorrow.setDate(tomorrow.getDate() + 1)
            if (tomorrow < d) { //make the date before tomorrow not clickable
                var m = moment(d).format("YYYY-MM-DD");
                m = encodeURIComponent(m);
                var uri = "/Bookings/Create?date=" + m;
                $(location).attr('href', uri);
            }
            
        }
    });
});