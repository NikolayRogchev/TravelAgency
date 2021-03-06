﻿var trip = {};

trip.signUp = function (tripId) {
    $.get({
        url: "http://localhost:51383/Trips/SignUp/" + tripId,
        success: function () {
            var count = Number($("#signed-users-count-" + tripId).text());
            $("#signed-users-count-" + tripId).text(++count);
            var cell = $("#btn-area-" + tripId);
            cell.empty();
            cell.append('<a class="btn btn-danger form-control" onclick="trip.removeSignUp(' + tripId + ')">Remove</a>');
            notifier.showSuccess("Signed Up!");
        },
        error: function () {
            notifier.showError("Error signing!");
        }
    })
}
trip.removeSignUp = function (tripId) {
    $.get({
        url: "http://localhost:51383/Trips/Remove/" + tripId,
        success: function () {
            var count = Number($("#signed-users-count-" + tripId).text());
            $("#signed-users-count-" + tripId).text(--count);
            var cell = $("#btn-area-" + tripId);
            cell.empty();
            cell.append('<a class="btn btn-success form-control" onclick="trip.signUp(' + tripId + ')">Sign Up</a>');
            notifier.showSuccess("Trip removed!");
        },
        error: function () {
            notifier.showError("Error removing trip!");
        }
    })
}
trip.delete = function (tripId) {
    $.get({
        url: "http://localhost:51383/Company/Trips/Delete/" + tripId,
        success: function () {
            $("#container-trip-" + tripId).remove();
            notifier.showSuccess("Trip deleted!");
        },
        error: function (response) {
            notifier.showError("Error deleting trip!");
        }
    })
}