using System.Linq;

namespace areyesram
{
    public class ReverseTransformer : ITransformer
    {
        public string Transform(string text)
        {
            return string.Join("", text.Reverse());
        }
    }
}
