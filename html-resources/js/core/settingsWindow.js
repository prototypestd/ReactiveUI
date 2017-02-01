new Vue({
    el: '#reactApp',
    data: {
        dialogVisible: false,
        activeName: 'first',
        reactiveVersion: commonCommands.reactiveVersion,
        cefVersion: commonCommands.cefVersion + '| Revision: ' + commonCommands.cefHash,
        newUsername: '',
    },
    methods: {
        handleClick(tab, event) {
            console.log(tab, event);
        },
        saveForm() {
            userManager.userName = this.newUsername;
            userManager.SaveSettings();
        }
    }
})