$(document).ready(function () {
    var nav = document.getElementById('navigation');
    var text;
    
    alert(navigationCommands.navItems);
    for (i = 0; i < navigationCommands.navItems.length; i++) {
        text += "<li>" + navigationCommands.navItems[i] + "</li>";
    }

    nav.innerHTML = text;
});