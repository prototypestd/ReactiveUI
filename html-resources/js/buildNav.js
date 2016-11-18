$(document).ready(function () {
    var nav = document.getElementById('navigation');
    var text;

    for (i = 0; i < navigationCommands.navItems.length; i++) {

        text += "<li>";
        text += "<a href='" + navigationCommands.navItems[i] + ".html' class='active'>";
        text += "<i class='fa fa-dashboard icon'> <b class='bg-danger'></b> </i>";
        text += "<span>" + navigationCommands.navItems[i] + "</span>";
        text += "</a>";
        text += "</li>";

    }

    nav.innerHTML += text;
});