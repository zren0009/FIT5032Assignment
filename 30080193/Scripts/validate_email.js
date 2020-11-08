var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

$("#booking_email").change(function () {
    if (!document.getElementById("booking_email").value.match(mailformat)) {
        document.getElementById("booking_email").value = "";
        alert("invalid email");
    }
});