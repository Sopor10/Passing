using System;

namespace Juggling.Throws
{
    public class Manipulation : Throw
    {
        public Juggler.Juggler From { get; set; }
        public Juggler.Juggler To { get; set; }

        public override string ToHtml()
        {
            var type = Type == null ? "-" : Type.ToString();
            var fromString = (From != null) ? "<sup>" + From.Name + "</sup>" : string.Empty;
            var toString = (To != null) ? "<sub>" + To.Name + "</sub>" : string.Empty;
            return "" + type + fromString + toString+ "";
        }


        public override string ToLatex()
        {
            var type = Type == null ? "-" : Type.ToString();
            var fromString = (From != null) ? "^{" + From.Name + "}" : string.Empty;
            var toString = (To != null) ? "_{" + To.Name + "}" : string.Empty;
            return "$" + type + fromString + toString+ "$";
        }
    }
}