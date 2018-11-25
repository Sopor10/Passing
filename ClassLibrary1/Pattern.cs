using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Juggling
{
    public class Pattern
    {
        public List<Juggler.Juggler> Jugglers { get; set; }
        public List<Beat> Beats { get; set; }

        public string StringForColumns
        {
            get
            {
                var sb = new StringBuilder();
                for (uint i = 0; i <= NumberOfColumns; i++)
                    sb.Append("l");

                return sb.ToString();
            }
        }

        public int NumberOfColumns => Beats.Count + 1;

        public Uebergang Uebergang { get; set; }

        public Pattern()
        {
            Beats = new List<Beat>();
            Jugglers = new List<Juggler.Juggler>();
            Uebergang = new Uebergang();
        }

        public string ToHtmlTable()
        {
            var result = "<table style=\"width=500\">\n";
            foreach (var juggler in Jugglers)
            {
                var intermediatresult = String.Empty;

                foreach (var beat in Beats)
                {
                    intermediatresult = string.Concat(intermediatresult, " <th> ", beat.ToHtml(juggler) + "</th>\n");
                }

                result = string.Concat(result,"<tr>\n <th>", juggler.Name,"</th>\n", intermediatresult, " </tr>\n");
            }

            result = string.Concat(result, "</table>");
            return result;
        }

        public string ToLatexTable()
        {
            var result = CreateTableHead();
            foreach (var juggler in Jugglers)
            {
                var intermediatresult = String.Empty;

                foreach (var beat in Beats)
                {
                    intermediatresult = string.Concat(intermediatresult, " & ", beat.ToLatex(juggler));
                }

                result = string.Concat(result, juggler.Name, intermediatresult, " \\\\\n");
            }

            result = string.Concat(result, CreateTableEnd());
            return result;
        }

        private string CreateTableHead()
        {
            var result = new StringBuilder();
            result.Append("\\documentclass[11pt]{article}\n\\usepackage{amsmath}\n\\begin{document}\n" +
                          $"\\begin{{table}}[] \n\\begin{{tabular}}{{{StringForColumns}}}\n");
            CreateBeatsAbove(result);
            CreateRechtsLinks(result);

            return result.ToString();
        }

        private void CreateRechtsLinks(StringBuilder result)
        {
            for (var i = 0; i < Beats.Count; i++)
            {
                result.Append(i % 2 == 0 ? "& R  " : "& L ");
            }

            result.Append("\\\\\n");
        }

        private void CreateBeatsAbove(StringBuilder result)
        {
            for (var i = 0; i < Beats.Count; i++)
            {

                result.Append(i % 2 == 0 ? $"& {(i + 1)/2+1} ": " & ");
            }

            result.Append("\\\\\n");
        }

        private string CreateTableEnd()
        {
            var result = "\\end{tabular}\n\\end{table}\n" + "\\end{document}";
            return result;
        }
    }
}