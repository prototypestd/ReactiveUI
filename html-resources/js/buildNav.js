$(document).ready(function () {
    var nav = document.getElementById('navigation');
    var text;
    var navItems = ["test", "test2", "test3"];
    
    for (i = 0; i < navItems.length; i++) {

        text += "<li>";
        text += "<a href='" + navItems[i] + ".html' class='active'>";
        text += "<i class='fa fa-dashboard icon'> <b class='bg-danger'></b> </i>";
        text += "<span>"+ navItems[i] +"</span>";
        text += "</a>";
        text += "</li>";

    }

    nav.innerHTML += text;
});