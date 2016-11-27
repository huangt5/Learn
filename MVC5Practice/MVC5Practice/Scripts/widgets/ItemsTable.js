
// Define ItemsTable class
function ItemsTable(table) {
    var tableObj = $(table);
    var _this = this;

    // Register delete line event handler
    tableObj.find(":button.close").each(function () {
        var btn = this;
        btn.onclick = DeleteLine;
    });

    // Current indexer
    var itemsIndex = tableObj.find("tbody tr").length;

    // Method to attach insert button for table
    this.attachInsertButton = function(button, onInsertClickedCallback) {
        // Insert new line to table
        $(button).click(function () {
            // clone template row
            var newRow = tableObj.find("thead tr").last().clone(true, true);
            // display new row
            newRow.css("display", "");
            newRow.appendTo(tableObj.children("tbody"));

            // Clear line content
            newRow.children("td").each(function () {
                var td = this;
                if (td.childElementCount > 0) {
                    // clear textbox
                    $(td).children(":text").each(function () {
                        this.value = "";
                    });
                } else {
                    // clear texts
                    td.innerText = "";
                }
            });

            // attach delete line handler
            newRow.find(":button.close").click(DeleteLine);

            // change indexer
            //newRow.find(":hidden").attr("name", "Samples.Index");
            var currentIndex = itemsIndex++;
            newRow.find(":hidden").val(currentIndex);
            // use non-sequencial index for all inputs
            newRow.find(":text").each(function () {
                var tempName = $(this).attr("name");
                $(this).attr("name", tempName.replace("tmp", currentIndex));
            });

            _this.RefreshSummary();

            // Insert button call back function
            if (onInsertClickedCallback) {
                onInsertClickedCallback();
            }
        });
    };


    // Delete line event handler
    function DeleteLine(arg) {
        var row = $(arg.target).closest("tr");
        row.remove();
        _this.RefreshSummary();
    };

    this.RefreshSummary = function () {
        // sum column
        tableObj.find("tfoot td.summary-sum").each(function() {
            var td = $(this);
            var index = td.index() + 1;
            var sum = 0;
            var textboxes = tableObj.find("tbody tr td:nth-child(" + index + ") :text");
            if (textboxes.length > 0) {
                textboxes.each(function() {
                    var value = parseFloat($(this).val());
                    if (!isNaN(value)) {
                        sum += value;
                    }
                });
            } else {
                // readonly column
                var cells = tableObj.find("tbody tr td:nth-child(" + index + ")");
                cells.each(function() {
                    var value = parseFloat(this.innerText);
                    if (!isNaN(value)) {
                        sum += value;
                    }
                });
            }
            td.text(sum);
        });
    };
}
