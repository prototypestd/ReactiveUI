new Vue({
    el: '#reactApp',
    data: {
        username: 'haikalizz',
        curTime: '',
        notifications: [],
        curPage: '',
        notiCount: notificationManager.notiCount,
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
        open() {
            const h = this.$createElement;

            this.$notify({
                title: 'Title',
                message: h('p', { style: 'color: red' }, 'This is a reminder')
            });
        },
    }
})