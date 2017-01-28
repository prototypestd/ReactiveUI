var notiCount = 5;

Vue.component('notification', {
    template: '<a href="#" class="media list-group-item"><span class="media-body block m-b-none">{{content}}<br><small class="text-muted"></small></span></a>',
    // data is technically a function, so Vue won't
    // complain, but we return the same object
    // reference for each component instance
    props: ['notiNum'],
    data: function () {
        return {
            content: notificationManager.notification[this.notiNum],
        }
    },
    mounted: function () {
        this.$nextTick(function () {
        })
    }
})