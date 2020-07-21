function myFunction() {
    var x = document.getElementById("myLinks");
    if (x.className === "links") {
        x.className += " responsive";
    } else {
        x.className = "links";
    }
}