$.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

// First control focus
$(".focus").each(function () {
    this.focus();
});

RegisterDatePickers();

function RegisterDatePickers() {
    // Exclude items table's template textbox
    $(":text.datepicker").not(".table-items :hidden").datepicker({
        dateFormat: "yy-mm-dd"
    });
}
