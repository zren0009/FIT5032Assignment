
var input_email = document.getElementById("input_email");
var btn_email = document.getElementById("btn_email");
var to_email = document.getElementById("to_email");
var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

$(btn_email).click(function () {
    if (input_email.value.match(mailformat)) {
        to_email.value += input_email.value + ";";
        input_email.value = "";
    }
    else {
        alert("invalid email address");
        input_email.value = "";
    }
});
