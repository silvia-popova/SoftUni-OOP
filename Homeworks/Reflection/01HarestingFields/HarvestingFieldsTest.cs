namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            var type = typeof(HarvestingFields);

            string modifier = Console.ReadLine();

            while (modifier != "HARVEST")
            {
                switch (modifier)
                {
                    case"public":
                        var fields = type.GetFields();
                        PrintFields(fields);
                        break;
                    case "private":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(t => t.IsPrivate).ToArray(); ;
                        PrintFields(fields);
                        break;
                    case "protected":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(t => t.IsFamily).ToArray();
                        PrintFields(fields);
                        break;
                    case "all":
                        fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        PrintFields(fields);
                        break;
                }

                modifier = Console.ReadLine();
            }
        }

        private static void PrintFields(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                string modifier = GetModifier(field);
                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }

        private static string GetModifier(FieldInfo field)
        {
            if (field.IsPrivate)
                return "private";
            if (field.IsFamily)
                return "protected";
            if (field.IsPublic)
                return "public";
            throw new ArgumentException("Did not find access modifier", "fieldInfo");
        }
    }
}
