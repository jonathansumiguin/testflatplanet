$(document).ready(function () {
    $("#btn-update-count").on("click", function () {
        var count = $("#h-count-value").text();

        if (parseInt(count) < 10) {
            app.updateCount();
        }
        else {
            $('#myModal').modal('show');
        }
    });

    app.getCount();
});


var app = {
    getCount: function () {
        $.ajax({
            url: '/api/counter/getcount',
            type: 'GET',
            success: function (data, textStatus, xhr) {
                var count = $("#h-count-value").text(data.count);
            }
        });
    },

    updateCount: function () {
        $.ajax({
            url: '/api/counter/updatecount',
            type: 'POST',
            success: function (data, textStatus, xhr) {
                if (data.isUpdated) {
                    app.getCount();
                }
            }
        });
    }
}

