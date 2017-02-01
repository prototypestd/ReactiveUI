new Vue({
    el: '#reactApp',
    data: {
        username: 'haikalizz',
        curTime: '',
        notifications: [],
        curPage: '',
        notiCount: notificationManager.notiCount,

        lang_myApps: commonCommands.translateString("myApps"),
        lang_Settings: commonCommands.translateString("settings"),
        lang_Exit: commonCommands.translateString("exit"),
        lang_Profile: commonCommands.translateString("profile"),
        lang_Help: commonCommands.translateString("help"),
    },
    mounted: function () {
        this.$nextTick(function () {
            setInterval(function () {
                // Gets the date from backend and renders it
                this.curTime = commonCommands.currentDate;

                // Handles the inline navigation
                if (this.curPage == "" || this.curPage != navigationCommands.nextPage) {
                    document.getElementById('ctent').src = navigationCommands.nextPage;
                    this.curPage = navigationCommands.nextPage;
                }
            }.bind(this), 1000)
        })
    },
    methods: {
        exitApp() {
            this.$confirm('Are you sure you want to exit?', 'Warning', {
                confirmButtonText: 'Yes',
                cancelButtonText: 'No',
                type: 'warning'
            }).then(() => {
                commonCommands.exitApp();
            }).catch(() => {
                this.$message({
                    type: 'info',
                    message: 'Shutdown Cancelled'
                });
            });
        },
        open(message,title) {
            const h = this.$createElement;

            this.$notify({
                title: title,
                message: h('p', { style: 'color: red' }, message)
            });
        },
    }
})