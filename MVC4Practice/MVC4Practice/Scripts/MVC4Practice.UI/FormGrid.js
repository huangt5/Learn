
defineNamespace(window, "MVC4Practice.UI");

MVC4Practice.UI.FormGrid = function() {
    this.init = function () {
        // privide label tip
        $(".formGrid .control").children().focus(function (event) {
            var label = $(this).parent().prev().html();
            MVC4Practice.console.log("Please input " + label);
        });

        // initial date picker
        $(".formGrid .control.date").children().datepicker({
            dateFormat: "yy-mm-dd"
        },
        $.datepicker.regional['zh-CN']);

    };
};

// Ensure DOM is loaded.
$(function() {
    // Initiate form grid in current page.
    new MVC4Practice.UI.FormGrid().init();
});

