
function submitRegistrationForm() {
    if ($("#cv-upload-input").val()!="") {
        $("#cvForm").submit();
    }
    else {
        alert("Please upload cv");
        e.preventDefault();
         return false;
    }
}
