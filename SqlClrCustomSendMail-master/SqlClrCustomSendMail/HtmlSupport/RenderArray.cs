using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace SqlClrCustomSendMail
{
    internal static class RenderArray
    {
        public static string MakeTable(List<object[]> dt, string caption, string footer, string style, int maxColumn,
            int maxCounter, int counter, int lastCounter)
        {

            var html = new StringBuilder();
            var isCustomStyle = style.Contains("<style type");

            if (counter.Equals(0))
            {
                html.Append("<html><head><meta charset='utf-8'/>");
                html.Append(DetermineStyle.GetStyle(style));
                html.Append("</head><body>");
            }
            //???
            if (isCustomStyle == false)
            {
                var appendName = style.Equals(string.Empty) ? DetermineStyle.StBlue : style;
                html.Append($"<div class=\'datagrid{appendName}\'>");
                html.Append("<table>");
            }
            else
            {
                var styleName = DetermineStyle.DetermineStyleName(style);
                html.Append($"<table class=\'{styleName}\'>");
            }
            if (caption != null && caption.Trim() != "")
                html.Append($"<caption>{caption}</caption>");

            html.Append("<thead>");


            html.Append("<tr>");


            //Apply column headers
            for (var i1 = 0; i1 < maxColumn; i1++)
            {
                html.Append("<th>");
                html.Append(dt[0][i1]);
                html.Append("</th>");
            }
            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");



            //int i = 0;
            for (var i1 = 1; i1 < maxCounter; i1++)
            {
                html.Append("<tr>");

                for (var i2 = 0; i2 < maxColumn; i2++)
                {
                    html.Append("<td>");
                    if (dt[i1][i2].ToString().Trim().Contains("<"))
                    {
                        html.Append(dt[i1][i2].ToString().Replace("<", "&lt;").Replace(">", "&gt;"));
                    }
                    else
                    {
                        html.Append(dt[i1][i2]);
                    }

                    html.Append("</td>");

                }

                html.Append("</tr>");


            }
            html.Append("</tbody>");

            string customFooter = footer;
            if (footer == "#")
            {
                customFooter = $"Total records : {maxCounter}";
            }
            html.Append($"<tfoot><tr><td colspan=\'{maxColumn}\'>{customFooter}</td></tr></tfoot>");

            html.Append("</table>");

            if (isCustomStyle == false)
                html.Append("</div>");

            if (counter == lastCounter)
            {
                html.Append("</body>");
                html.Append("</html>");
            }

            var retvalu = html.ToString();
            // ReSharper disable once RedundantAssignment
            html = null;
            return retvalu;
        }
        public static string MakeTableRotateKeyValue(List<object[]> dt, string caption, string footer, string style,
            int maxColumn, int maxCounter, int counter, int lastCounter)
        {

            StringBuilder html = new StringBuilder();
            bool isCustomStyle = style.Contains("<style type");
            if (counter.Equals(0))
            {
                html.Append("<html><head><meta charset='utf-8'/>");
                html.Append(DetermineStyle.GetStyle(style));
                html.Append("</head><body>");
            }
            //???
            if (isCustomStyle == false)
            {
                string appendName = style.Equals(string.Empty) ? DetermineStyle.StBlue : style;
                html.Append($"<div class=\'datagrid{appendName}\'>");
                html.Append("<table>");
            }
            else
            {
                string styleName = DetermineStyle.DetermineStyleName(style);
                html.Append($"<table class=\'{styleName}\'>");
            }
            if (caption != null && caption.Trim() != "")
                html.Append($"<caption>{caption}</caption>");

            html.Append("<thead>");


            html.Append("<tr>");


            //Apply column headers - rotate mode with rco == -1
            html.Append("<th>");
            html.Append("Key");
            html.Append("</th>");
            int no = 0;
            for (var r1 = 1; r1 < maxCounter; r1++)
            {
                html.Append("<th>");
                if (no == 0)
                    html.Append("Value");
                else
                    html.Append("Value" + no.ToString().Trim());
                no++;
                html.Append("</th>");
            }

            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");



            //int i = 0;
            for (var i1 = 0; i1 < maxColumn; i1++)
            {
                html.Append("<tr>");
                html.Append("<td>");
                html.Append(dt[0][i1]);
                html.Append("</td>");

                for (var i2 = 1; i2 < maxCounter; i2++)
                {
                    html.Append("<td>");
                    if (dt[i2][i1].ToString().Trim().Contains("<"))
                    {
                        html.Append(dt[i2][i1].ToString().Replace("<", "&lt;").Replace(">", "&gt;"));
                    }
                    else
                    {
                        html.Append(dt[i2][i1]);
                    }
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</tbody>");

            string customFooter = footer;
            if (footer == "#")
            {
                customFooter = $"Total records : {maxCounter}";
            }
            html.Append($"<tfoot><tr><td colspan=\'{maxColumn}\'>{customFooter}</td></tr></tfoot>");

            html.Append("</table>");

            if (isCustomStyle == false)
                html.Append("</div>");

            if (counter == lastCounter)
            {
                html.Append("</body>");
                html.Append("</html>");
            }
            string retvalu = html.ToString();
            // ReSharper disable once RedundantAssignment
            html = null;
            return retvalu;
        }

        public static string MakeTableRotate(List<object[]> dt, string caption, string footer, string style,
            int maxColumn, int maxCounter, int pco, int counter, int lastCounter)
        {

            var html = new StringBuilder();
            var isCustomStyle = style.Contains("<style type");


            //????
            if (counter.Equals(0))
            {
                html.Append("<html><head><meta charset='utf-8'/>");
                html.Append(DetermineStyle.GetStyle(style));
                html.Append("</head><body>");
            }
            //???
            if (isCustomStyle == false)
            {
                string appendName = style.Equals(string.Empty) ? DetermineStyle.StBlue : style;
                html.Append($"<div class=\'datagrid{appendName}\'>");
                html.Append("<table>");
            }
            else
            {
                string styleName = DetermineStyle.DetermineStyleName(style);
                html.Append($"<table class=\'{styleName}\'>");
            }
            if (caption != null && caption.Trim() != "")
                html.Append($"<caption>{caption}</caption>");

            html.Append("<thead>");

            if (pco > maxColumn)
            {
                pco = 0;
            }


            html.Append("<tr>");


            for (int r1 = 0; r1 < maxCounter; r1++)
            {
                string newName = dt[r1][pco].ToString();
                html.Append("<th>");
                html.Append(newName);
                html.Append("</th>");
            }



            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>");



            //int i = 0;
            for (int i1 = 0; i1 < maxColumn; i1++)
            {

                if (i1 == pco)
                    continue;

                html.Append("<tr>");
                html.Append("<td>");
                html.Append(dt[0][i1]);
                html.Append("</td>");

                for (int i2 = 1; i2 < maxCounter; i2++)
                {
                    html.Append("<td>");
                    if (dt[i2][i1].ToString().Trim().Contains("<"))
                    {
                        html.Append(dt[i2][i1].ToString().Replace("<", "&lt;").Replace(">", "&gt;"));
                    }
                    else
                    {
                        html.Append(dt[i2][i1]);
                    }
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</tbody>");

            var customFooter = footer;
            if (footer == "#")
            {
                customFooter = $"Total records : {maxCounter}";
            }
            html.Append($"<tfoot><tr><td colspan=\'{maxColumn}\'>{customFooter}</td></tr></tfoot>");

            html.Append("</table>");

            if (isCustomStyle == false)
                html.Append("</div>");

            if (counter == lastCounter)
            {
                html.Append("</body>");
                html.Append("</html>");
            }

            var retvalu = html.ToString();
            // ReSharper disable once RedundantAssignment
            html = null;
            return retvalu;
        }
    }

}
