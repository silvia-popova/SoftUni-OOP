using System.Linq;
using System.Reflection;

namespace InfernoInfinity.Core
{
    using System;
    using Contracts;
    using Exceptions;

    public class GameController : IGameController
    {
        private readonly IData data;
        private readonly IWeaponFactory weaponFactory;
        private readonly IGemFactory gemFactory;

        public GameController(IData data, IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.data = data;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public void ExecuteCommand(string input)
        {
            var commandArgs = input.Split(';');
            var command = commandArgs[0];

            switch (command)
            {
                case "Create":
                    var weapon = this.CreateWeapon(commandArgs);
                    this.data.AddWeapon(weapon);
                    break;
                case "Add":
                    weapon = this.data.FindWeaponByName(commandArgs[1]);
                    int index = int.Parse(commandArgs[2]);
                    IGem gem = this.CreateGem(commandArgs[3].Split());
                    weapon.AddGem(gem, index);
                    break;
                case "Remove":
                    weapon = this.data.FindWeaponByName(commandArgs[1]);
                    index = int.Parse(commandArgs[2]);
                    weapon.RemoveGem(index);
                    break;
                case "Print":
                    weapon = this.data.FindWeaponByName(commandArgs[1]);
                    GetWeaponInfo(weapon);
                    break;
                default:
                    throw new InvalidCommandexception("Unknown command!");
            }
        }

        private IGem CreateGem(string[] gemInfo)
        {
            var clarity = gemInfo[0];
            var type = gemInfo[1];

            return this.gemFactory.CreateGem(type, clarity);
        }

        private IWeapon CreateWeapon(string[] commandArgs)
        {
            var weaponInfo = commandArgs[1].Split();
            var rarity = weaponInfo[0];
            var type = weaponInfo[1];
            var name = commandArgs[2];

            return this.weaponFactory.CreateWeapon(name, type, rarity);
        }

        private static void GetWeaponInfo(IWeapon weapon)
        {
            weapon.CalculateStates();
            Console.WriteLine(weapon.ToString());
        }
    }
}
