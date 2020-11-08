$("#booking_hours").change(function () {
    var booking_hours = parseFloat(document.getElementById("booking_hours").value);

    if (booking_hours < 1) {
        document.getElementById("booking_hours").value = 1;
    }
    else if (booking_hours > 2) {
        document.getElementById("booking_hours").value = 2;
        alert("You can only book up to 2 hours!");
    } else {
        document.getElementById("booking_hours").value = Math.round(booking_hours);
    }
    
});