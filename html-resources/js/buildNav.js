$(document).ready(function () {
    var nav = document.getElementById('navigation');
    var text = '';
    var oldLength = navigationCommands.navItems.length;
    var hasDone = false;
    
    setInterval(function () {

        if (oldLength != navigationCommands.navItems.length && hasDone) {
            for (i = (oldLength+1); i < navigationCommands.navItems.length; i++) {

                text += "<li>";
                text += '<a href="#"  onclick="navigationCommands.showPage(\'' + navigationCommands.navItems[i] + '\');" class="active">';
                text += "<i class='fa fa-dashboard icon'> <b class='bg-danger'></b> </i>";
                text += "<span>" + navigationCommands.navItems[i] + "</span>";
                text += "</a>";
                text += "</li>";

            }

            nav.innerHTML += text;
        } else if (oldLength == navigationCommands.navItems.length && !hasDone) {
            for (i = 0; i < navigationCommands.navItems.length; i++) {

                text += "<li>";
                text += '<a href="#"  onclick="navigationCommands.showPage(\''+ navigationCommands.navItems[i]+'\');" class="active">';
                text += "<i class='fa fa-dashboard icon'> <b class='bg-danger'></b> </i>";
                text += "<span>" + navigationCommands.navItems[i] + "</span>";
                text += "</a>";
                text += "</li>";

            }

            nav.innerHTML += text;
            hasDone = true;
        } else {
            return;
        }

    }, 1000);

});