namespace InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Enums;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, string gemClarity)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == gemType);

            if (type == null)
            {
                throw new ArgumentException("Unknown gem type.");
            }

            Clarity clarity = (Clarity)Enum.Parse(typeof(Clarity), gemClarity);

            var gem = (IGem)Activator.CreateInstance(type, clarity);

            return gem;
        }
    }
}
