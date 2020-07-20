namespace areyesram
{
    public class TrimTransformer : ITransformer
    {
        public string Transform(string text)
        {
            return text.Trim();
        }
    }
}
