namespace areyesram
{
    public class LowerTransformer : ITransformer
    {
        public string Transform(string text)
        {
            return text.ToLower();
        }
    }
}
