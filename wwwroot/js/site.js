// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function clickFunc() {
    var userName = document.getElementById('name').value;
    if (userName == "admin") {
        localStorage.setItem("isAdmin", true);
    } else {
        localStorage.setItem("isAdmin", false);
    } 
} 

function setItemInIndexAdmibTable(adminId) {
    if (localStorage.getItem("isAdmin") == 'true') {
        var row = document.getElementById("myRow");
         
        var x = row.insertCell(0);
        x.innerHTML = '<td><a href="~/../../Admins/Delete/' +adminId+' class="btn btn-danger">Sil</a></td>'; 
        
    }
    
}

function deleteAllCookies() {
    var cookies = document.cookie.split(";");
    localStorage.setItem("isAdmin", false);
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        var eqPos = cookie.indexOf("=");
        var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}
 