using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage
{
    class StartUp
    {
        static void Main()
        {

            string lineReader = Console.ReadLine();
            string[] tokens = lineReader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int power = int.Parse(tokens[1]);

            List<Wizard> wizards = new List<Wizard>();
            var type = typeof(Wizard);
            var wizard = (Wizard)Activator.CreateInstance(type, 0, name, power, wizards);
            wizards.Add(wizard);

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] lineArgs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(lineArgs[0]);
                string spell = lineArgs[1];

                var currentWizzard = wizards.FirstOrDefault(w => w.Id == id);

                var metod = type.GetMethods().FirstOrDefault(m => m.Name.ToLower() == "cast" + spell.ToLower());
                metod.Invoke(currentWizzard, new object[0]);

                line = Console.ReadLine();
            }
        }
    }
}
