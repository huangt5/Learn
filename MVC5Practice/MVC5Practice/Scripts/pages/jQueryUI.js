$(function() {

    // basic auto complete
    //$.ajax({
    //    type: "POST",
    //    url: '/Test/GetProductNamesWithId',
    //    dataType: "json",
    //    success: function (data) {
    //        $("#ProductName").autocomplete({
    //            source: data,
    //        });
    //    }
    //});

    // auto complete with id
    $.ajax({
        type: "POST",
        url: '/Test/GetProductNamesWithId',
        dataType: "json",
        success: function(data) {
            var txt = $("#ProductName").autocomplete({
                minLength: 0,
                source: data,
                focus: function(event, ui) {
                    $("#ProductName").val(ui.item.label);
                    return false;
                },
                select: function(event, ui) {
                    $("#ProductName").val(ui.item.label);
                    return false;
                }
            }).data("ui-autocomplete")._renderItem = function(ul, item) {
                return $("<li>")
                    .append("<a>" + item.label + " <span style='font-size:8px'>" + item.desc + "</span></a>")
                    .appendTo(ul);
            };
        }
    });




});