export default {
    Info(message = ""){
        var x = document.getElementById("snackbar");
        var y = document.getElementById("toast-content");
        var z = document.getElementById("toast-close");
        y.innerHTML = message
        x.style.backgroundColor = "aliceblue"
        z.style.backgroundColor = "aliceblue"
        x.style.color = "black"
        z.style.color = "black"
        // Add the "show" class to DIV
        x.className = "show";
      
        // After 3 seconds, remove the show class from DIV
        setTimeout(function(){ x.className = x.className.replace("show", ""); }, 10000);
    },
    Error(message = ""){
        var x = document.getElementById("snackbar");
        var y = document.getElementById("toast-content");
        var z = document.getElementById("toast-close");
        y.innerHTML = message
        x.style.backgroundColor = "red"
        x.style.color = "white"
        z.style.backgroundColor = "red"
        z.style.color = "white"
        // Add the "show" class to DIV
        x.className = "show";
      
        // After 3 seconds, remove the show class from DIV
        setTimeout(function(){ x.className = x.className.replace("show", ""); }, 10000);
    },
    Success(message = ""){
        var x = document.getElementById("snackbar");
        var y = document.getElementById("toast-content");
        var z = document.getElementById("toast-close");
        x.innerHTML = message
        x.style.backgroundColor = "green"
        z.style.backgroundColor = "green"
        x.style.color = "white"
        z.style.color = "white"
        // Add the "show" class to DIV
        x.className = "show";
      
        // After 3 seconds, remove the show class from DIV
        setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);
    },
    Warning(message = ""){
        var x = document.getElementById("snackbar");
        var y = document.getElementById("toast-content");
        var z = document.getElementById("toast-close");
        x.innerHTML = message
        x.style.backgroundColor = "yellow"
        z.style.backgroundColor = "yellow"
        x.style.color = "black"
        z.style.color = "black"
        // Add the "show" class to DIV
        x.className = "show";
      
        // After 3 seconds, remove the show class from DIV
        setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);
    }


}