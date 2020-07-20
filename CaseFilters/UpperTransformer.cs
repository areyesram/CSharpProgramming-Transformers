namespace areyesram
{
    public class UpperTransformer : ITransformer
    {
        public string Transform(string text)
        {
            return text.ToUpper();
        }
    }
}
