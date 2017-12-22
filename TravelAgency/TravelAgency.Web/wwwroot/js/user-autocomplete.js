function prepare(users) {
    var options = {
        data: users.split(';')
    };

    $("#owner").easyAutocomplete(options);
}