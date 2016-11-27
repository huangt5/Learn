// IIFE block to avoid naming conflicts from other code snip
(function () {
    // ajax test
    $("#btnGetSalesman").click(function (event) {
        $.ajax('/Sales/GetSalesman', {
            type: 'POST',
            dataType: 'json',
            success: function (resp) {
                var fullName = resp.firstName + " " + resp.lastName;
                MVC4Practice.console.log(fullName);
            },
            error: function (req, status, err) {
                console.log('something went wrong', status, err);
            }
        });
    });
    
    // Load local order details data into jqGrid
    $("#list").jqGrid({
        datatype: "local",
        height: "100%",
        width: 970,
        colNames: ['Product Id', 'Special Offer Id', 'Price', 'Qty'],
        colModel: [
            { name: 'ProductID'},
            { name: 'SpecialOfferID'},
            { name: 'UnitPrice', editable: true},
            { name: 'OrderQty', editable: true }
        ],
        multiselect: false,
        rowNum: 1000000,
        caption: "Sales Order Details",
        jsonReader: { repeatitems: false },
    });
    for (var i = 0; i <= detailsData.length; i++) {
        jQuery("#list").jqGrid('addRowData', i + 1, detailsData[i]);
        jQuery("#list").editRow(i + 1, true);
    }
    
    // Pre-submit codes
    $("form[action='/Sales/SaveSalesOrder']").submit(function() {
        try {
            // Change name attributes of input in jqGrid to match MVC model binding.
            var gridRows = $("tr[role='row'][editable='1']");
            gridRows.each(function (rowIndex) {
                var row = $(this);
                row.find("input").each(function () {
                    var input = $(this);
                    var originalName = input.attr("name");
                    input.attr("name", "SODetails[" + rowIndex + "]." + originalName);
                });
            });
        } catch (e) {
            alert(e);
            return false;
        } 
        return true;
    });

})();

