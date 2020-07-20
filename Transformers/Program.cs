using System;

namespace areyesram
{
    internal class Program
    {
        private static void Main()
        {
            var tests = new[]
            {
                new Test("upper", "This is a test. I hope it works fine."),
                new Test("lower", "This is a test. I hope it works fine."),
                new Test("trim", "   This is a test. I hope it works fine.   "),
                new Test("reverse", "This is a test. I hope it works fine.")
            };
            foreach (var o in tests)
            {
                var trans = Factory.GetTransformer(o.Transform);
                Console.WriteLine(trans.Transform(o.Text));
            }
        }

        internal class Test
        {
            public Test(string transform, string text)
            {
                Transform = transform;
                Text = text;
            }
            public string Text { get; set; }
            public string Transform { get; set; }
        }
    }
}
