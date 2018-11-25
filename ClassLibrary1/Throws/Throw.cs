using System;

namespace Juggling.Throws
{
    public abstract class Throw
    {
        public Enum Type { get; set; }
        public abstract string ToLatex();
        public abstract string ToHtml();
    }
}