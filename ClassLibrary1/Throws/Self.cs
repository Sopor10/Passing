namespace Juggling.Throws
{
    public class Self : Throw
    {
        public Juggler.Juggler Juggler { get; set; }
        public override string ToLatex()
        {
            return $"${Type.ToString()}$";
        }
        public override string ToHtml()
        {
            return $"{Type.ToString()}";
        }
    }
}