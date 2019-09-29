var attempt = 3; // Variable to count number of attempts.


// Below function Executes on click of login button.
function validate() {
    var username = document.getElementById("admin").value;
    var password = document.getElementById("password").value;
    if (username == "root" && password == "test") {
        alert("Login successfully");
        window.location = "success.html"; // Redirecting to other page.
        return false;
    } else {
        attempt--; // Decrementing by one.
        alert("You have left " + attempt + " attempt;");
        // Disabling fields after 3 attempts.
        if (attempt == 0) {
            document.getElementById("admin").disabled = true;
            document.getElementById("password").disabled = true;
            return false;
        }
    }
}
