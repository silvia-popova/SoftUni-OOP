using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.GenericList
{
    class GenericListTes
    {
        static void Main(string[] args)
        {
            GenericList<string> customList = new GenericList<string>();

            while (true)
            {
                var commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Add":
                        string element = commandArgs[1];
                        customList.Add(element);
                        break;
                    case "Remove":
                        int index = int.Parse(commandArgs[1]);
                        customList.RemoveAt(index);
                        break;
                    case "Contains":
                        element = commandArgs[1];
                        Console.WriteLine(customList.Contains(element));
                        break;
                    case "Swap":
                        index = int.Parse(commandArgs[1]);
                        int secondIndex = int.Parse(commandArgs[2]);
                        customList.Swap(index, secondIndex);
                        break;
                    case "Greater":
                        element = commandArgs[1];
                        int count = customList.GreaterThan(element);
                        Console.WriteLine(count);
                        break;
                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "Print":

                        foreach (var VARIABLE in customList)
                        {
                            Console.WriteLine(VARIABLE);
                        }
                        //Console.WriteLine(customList.ToString());
                        break;
                    case "Sort":
                        ListSorter.Sort(customList);
                        break;
                    case "END":
                        return;
                }
            }
        }
    }
}
