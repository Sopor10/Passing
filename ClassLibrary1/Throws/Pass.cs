namespace Juggling.Throws
{
    public class Pass : Throw
    {
        public Juggler.Juggler To { get; set; }
        public override string ToLatex()
        {
            return $"${Type.ToString()}_{To.Name}$";
        }
        public override string ToHtml()
        {
            return $"{Type.ToString()}<sub>{To.Name}</sub>";
        }
    }
}