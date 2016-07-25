namespace InfernoInfinity
{
    using Core;
    using IO;

    class StartUp
    {
        static void Main()
        {
            var data = new Data();
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();

            var gameControler = new GameController(data, weaponFactory, gemFactory);

            var reader= new InputReader();
            var writer= new OutputWriter();

            var engine= new Engine(gameControler, reader, writer);
            engine.Run();
        }
    }
}
