using System;
using System.Collections.Generic;
using System.Linq;
using VegetableNinja.Contracts;
using VegetableNinja.Core;
using VegetableNinja.Models;

namespace VegetableNinja
{
    class Startup
    {
        static void Main(string[] args)
        {
            IInputReader consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();
            var players = new IPlayer[2];
            IList<IVegetable> vegetables = new List<IVegetable>();

            string name1 = Console.ReadLine();
            char symbol1 = name1[0];
            string name2 = Console.ReadLine();
            char symbol2 = name2[0];

            var dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            IUnitContainer matrix = new MatrixContainer(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    char s = input[j];

                    if (s == symbol1)
                    {
                        var player1 = new Player(i, j, name1);
                        matrix.Add(player1);
                        if (player1.Name == name1)
                        {
                            players[0] = player1;
                        }
                        else
                        {
                            players[1] = player1;
                        }
                    }
                    else if (s == symbol2)
                    {
                        var player = new Player(i, j, name2);
                        matrix.Add(player);
                        if (player.Name == name1)
                        {
                            players[0] = player;
                        }
                        else
                        {
                            players[1] = player;
                        }
                    }
                    else if (s == 'A')
                    {
                        var vegetable = new Asparagus(i, j);
                        matrix.Add(vegetable);
                        vegetables.Add(vegetable);
                    }
                    else if (s == 'B')
                    {
                        var vegetable = new Broccoli(i, j);
                        matrix.Add(vegetable);
                        vegetables.Add(vegetable);
                    }
                    else if (s == 'C')
                    {
                        var vegetable = new CherryBerry(i, j);
                        matrix.Add(vegetable);
                        vegetables.Add(vegetable);
                    }
                    else if (s == 'M')
                    {
                        var vegetable = new Mushroom(i, j);
                        matrix.Add(vegetable);
                        vegetables.Add(vegetable);
                    }
                    else if (s == 'R')
                    {
                        var vegetable = new Royal(i, j);
                        matrix.Add(vegetable);
                        vegetables.Add(vegetable);
                    }
                    else if (s == '-')
                    {
                        var blank = new BlankSpace(i, j);
                        matrix.Add(blank);
                    }
                    else if (s == '*')
                    {
                        var blank = new Melolemonmelon(i, j);
                        matrix.Add(blank);
                    }
                }
            }

            var engine = new Engine(matrix,
                consoleReader,
                consoleWriter, players, vegetables);

            engine.Start();
        }
    }
}
