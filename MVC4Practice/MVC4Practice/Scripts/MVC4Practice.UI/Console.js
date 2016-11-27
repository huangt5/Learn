//var MVC4Practice = MVC4Practice || {};
//MVC4Practice.UI = MVC4Practice.UI || {};
defineNamespace(window, "MVC4Practice.UI");

// Console classes
MVC4Practice.UI.Console = function () {
    // private field
    var statusBar = $("#statusBar");
    var displayCount = 0;

    // public method
    this.log = function (msg) {
        statusBar.hide();
        statusBar.html(msg);
        statusBar.slideDown();
        displayCount++;

        setTimeout(clearMsgDelegate, 3000);
    };

    // private method
    function clearMsgDelegate() {
        MVC4Practice.console.clear();
    }

    // public method
    this.clear = function () {
        displayCount--;
        // have to refer to global singleton instance. setTimeout is invoked by window object.
        if (displayCount == 0) {
            statusBar.slideUp();
        }
    };
};
