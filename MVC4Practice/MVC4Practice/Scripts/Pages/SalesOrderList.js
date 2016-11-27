// IIFE block to avoid naming conflicts from other code snip
(function () {
    // defaults
    //$("#txtFrom").val(new Date().getFullYear() + '-01-01');
    //$("#txtTo").val(new Date().getFullYear()+'-12-31');

    // construct empty grid
    $("#list").jqGrid({
        url: "/Sales/GetSalesOrderList",
        datatype: "local",
        mtype: "POST",
        height: "100%",
        width: 970,
        colNames: ['Id', 'Order Date', 'Is Online', 'Action'],
        colModel: [
            { name: 'id', index: 'id', width: 60, sorttype: "int" },
            { name: 'orderDate', index: 'orderDate', width: 90, sorttype: "date" },
            { name: 'isOnline', index: 'isOnline', width: 50, sorttype: "bool" },
            { name: 'id', formatter:formatEditLink}
        ],
        multiselect: false,
        rowNum: 1000000,
        caption: "Sales Order List",
        jsonReader: { repeatitems: false },
        gridComplete: function() {
            MVC4Practice.console.log($("#list").jqGrid('getRowData').length+" records are loaded.");
        }
    });

    function formatEditLink(cellvalue, options, rowObject) {
        return String.format("<a href='/Sales/Edit/{0}' target='_blank'>Edit</a>", cellvalue);
    }

    // Query button click event handler
    $("#btnQuery").click(function (event) {
        // clear jqGrid
        $("#list").clearGridData();
        // refresh jqGrid
        $("#list").setGridParam({
            datatype: "json",
            postData: {
                date1: $("#txtFrom").val(),
                date2: $("#txtTo").val()
            }
        });
        
        $("#list").trigger("reloadGrid");
    });
})();