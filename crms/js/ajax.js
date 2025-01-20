function loadContent(page) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200){
            document.getElementById("content").innerHTML = this.responseText;
        } else {
            console.error('Hmmm.... Something is wrong here')
        }
    };
    xhttp.open("GET", `${ page }.html`, true);
    xhttp.send();
}