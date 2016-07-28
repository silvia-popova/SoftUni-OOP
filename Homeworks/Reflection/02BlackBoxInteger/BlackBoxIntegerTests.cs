namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main(string[] args)
        {
            var type = typeof(BlackBoxInt);
            var ctor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            var blackBox = ctor[0].Invoke(new object[] {0});

            string line = Console.ReadLine(); 

            while (line != "END")
            {
                string[] tokens = line.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var metodName = tokens[0];
                var integer = int.Parse(tokens[1]);

                var metod = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                            .FirstOrDefault(m => m.Name == metodName);
                metod.Invoke(blackBox, new object[] { integer });

                var field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .FirstOrDefault(m => m.Name == "innerValue");

                Console.WriteLine(field.GetValue(blackBox));

                line = Console.ReadLine();
            }
        }
    }
}
