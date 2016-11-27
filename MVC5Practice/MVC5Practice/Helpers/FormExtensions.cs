using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC5Practice.Helpers {
    public static class FormExtensions {
        public static MvcHtmlString FormTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> exp, string widgetClass = null) {
            var label = htmlHelper.LabelFor(exp, new {@class = "col-md-2 control-label"});
            var txt = htmlHelper.TextBoxFor(exp, new {@class = "form-control " + widgetClass});
            var val = htmlHelper.ValidationMessageFor(exp);
            var div = new TagBuilder("div");
            div.AddCssClass("col-md-3");
            div.InnerHtml = txt.ToHtmlString();
            div.InnerHtml += val.ToHtmlString();
            return MvcHtmlString.Create(label + div.ToString());
        }

        public static MvcHtmlString ItemsTableFor<TModel>(this HtmlHelper<TModel> htmlHelper, string tableId, string dataSourceName, object[] dataSource, ColumnDefinition[] colmns) {
            // thead
            StringBuilder sbHeaders = new StringBuilder();
            foreach (var col in colmns) {
                sbHeaders.AppendFormat("<th>{0}</th>", col.Title);
            }
            // delete column
            sbHeaders.Append("<th>&nbsp;</th>");

            // template row
            var sbTemplateRow = new StringBuilder();
            sbTemplateRow.Append("<tr style=\"display:none\">");
            foreach (var col in colmns) {
                sbTemplateRow.Append("<td>");
                GenerateItemsTableCell(col, sbTemplateRow, dataSourceName, "tmp", null);
                sbTemplateRow.Append("</td>");
            }
            // delete cell
            sbTemplateRow.Append("<td>");
            sbTemplateRow.AppendFormat("<input type=\"hidden\" name=\"{0}.Index\" />", dataSourceName);
            sbTemplateRow.AppendFormat("<button type=\"button\" class=\"close\" aria-hidden=\"true\">&times;</button>");
            sbTemplateRow.Append("</td>");
            sbTemplateRow.Append("</tr>");

            // Data rows
            StringBuilder sbDataRows = new StringBuilder();
            for (int i = 0; i < dataSource.Length; i++) {
                object obj = dataSource[i];
                sbDataRows.Append("<tr>");
                foreach (var col in colmns) {
                    sbDataRows.Append("<td>");
                    GenerateItemsTableCell(col, sbDataRows, dataSourceName, i.ToString(), obj.Property(col.Property));
                    sbDataRows.Append("</td>");
                }
                // delete cell
                sbDataRows.Append("<td>");
                sbDataRows.AppendFormat("<input type=\"hidden\" name=\"{0}.Index\" value=\"{1}\" />", dataSourceName, i);
                sbDataRows.AppendFormat("<button type=\"button\" class=\"close\" aria-hidden=\"true\">&times;</button>");
                sbDataRows.Append("</td>");
                sbDataRows.Append("</tr>");
            }

            // Foot cells
            var sbFoot = new StringBuilder();
            foreach (var col in colmns) {
                if (string.IsNullOrEmpty(col.SummaryMethod)) {
                    sbFoot.Append("<td>&nbsp;</td>");
                } else {
                    sbFoot.AppendFormat("<td class=\"summary-{0}\">&nbsp;</td>", col.SummaryMethod);
                }
            }
            // delete cell
            sbFoot.Append("<td>&nbsp;</td>");

            string table = string.Format(@"
                <table class=""table table-hover table-items"" id=""{4}"">
                    <thead>
                        <tr>
                            {0}
                        {1}
                        </tr>
                    </thead>
                    <tbody>
                        {2}
                    </tbody>
                    <tfoot>
                        <tr>
                            {3}
                        </tr>
                    </tfoot>
                </table>", sbHeaders, sbTemplateRow, sbDataRows, sbFoot, tableId);

            return MvcHtmlString.Create(table.ToString());
        }

        public static object Property(this object obj, string propertyName) {
            return obj.GetType().GetProperty(propertyName).GetValue(obj);
        }

        private static void GenerateItemsTableCell(ColumnDefinition col, StringBuilder sb, string dataSourceName, string indexer, object value) {
            if (col.Readonly) {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString())) {
                    sb.Append("&nbsp;");
                } else {
                    sb.Append(value);
                }
            } else {
                var txt = new TagBuilder("input");
                txt.MergeAttribute("type", "text");
                txt.MergeAttribute("name", string.Format("{0}[{1}].{2}", dataSourceName, indexer, col.Property));
                txt.MergeAttribute("class", "form-control " + col.ExtraClass);
                txt.MergeAttribute("value", value==null?"":value.ToString());
                sb.Append(txt);
            }
        }
    }

    public class ColumnDefinition {
        public ColumnDefinition(string title, string property) {
            Title = title;
            Property = property;
        }

        public string SummaryMethod { get; set; }
        public bool Readonly { get; set; }
        public string Title { get; set; }
        public string Property { get; set; }
        public string ExtraClass { get; set; }
    }
}