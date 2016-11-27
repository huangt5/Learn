
// Define root namespace
var MVC4Practice = MVC4Practice || {};

// test nested namespace
defineNamespace(window, "MVC4Practice.Test.Namespace.AutoNested");

// console singleton instance
MVC4Practice.console = new MVC4Practice.UI.Console();

// jqGrid defaults
$.jgrid = {
    defaults: {
        recordtext: "View {0} - {1} of {2}",
        emptyrecords: "No records to view",
        loadtext: "Loading...",
        pgtext: "Page {0} of {1}"
    },
};

// Global helper methods
String.format = function() {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }

    return s;
};
