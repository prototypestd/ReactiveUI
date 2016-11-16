$(document).ready(function () {
    var nav = document.getElementById('navigation');

    for (i = 0; i < navigationCommands.navItems; i++) {
        var entry = document.createElement('li');
        entry.appendChild(document.createTextNode(navigationCommands.navItems[i]));
        nav.appendChild(entry);
    }
});