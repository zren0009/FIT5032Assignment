var page = location.href;
if (page == "https://localhost:44331/")
{
    $("#layout").hide();
    setTimeout(function () {
        document.getElementById("loader_style").disabled = true;
        $("#loading").hide();
        $("#layout").show();
    }, 1000);
}