var notifier = notifier || {};

(function () {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-center",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "2000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
})();

notifier.showInfo = function (message) {
    toastr.info(message);
}
notifier.showError = function (message) {
    toastr.error(message);
}
notifier.showSuccess = function (message) {
    toastr.success(message);
}
notifier.showWarning = function (message) {
    toastr.warning(message);
}