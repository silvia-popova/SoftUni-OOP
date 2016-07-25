using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobsGame.Core;
using BlobsGame.IO;
using BlobsGame.Models;
using BlobsGame.Models.Factories;

namespace BlobsGame
{
    class BlobsGameApplication
    {
        static void Main(string[] args)
        {
            var blobFactory = new BlobFactory();
            var attackFactory = new AttackFactory();
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var data = new BlobData();

            var engine = new Engine(blobFactory, attackFactory, data, reader, writer);
            engine.Run();
        }
    }
}
