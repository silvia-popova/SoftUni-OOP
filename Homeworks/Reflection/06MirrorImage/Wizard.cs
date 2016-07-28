using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06MirrorImage
{
    public class Wizard
    {
        private int mirrorCounter;
        private List<Wizard> mirrirImages;
        private List<Wizard> wizards;

        public Wizard(int id, string name, int magicalpower, List<Wizard> wizards)
        {
            this.Id = id;
            this.Name = name;
            this.Magicalpower = magicalpower;
            this.mirrirImages = new List<Wizard>();
            this.wizards = wizards;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Magicalpower { get; set; }

        public void CastReflection()
        {
            Console.WriteLine($"{this.Name} {this.Id} casts Reflection");

            foreach (var image in this.mirrirImages)
            {
                image.CastReflection();
            }

            if (this.mirrirImages.Count == 0)
            {
                var firstImige = new Wizard(this.Id*2 + 1 , this.Name, this.Magicalpower/2, this.wizards); 
                this.wizards.Add(firstImige);
                this.mirrirImages.Add(firstImige);
                var secondImige = new Wizard(this.Id*2 + 2, this.Name, this.Magicalpower / 2, this.wizards);
                this.wizards.Add(secondImige);
                this.mirrirImages.Add(secondImige);
            }
        }

        public void CastFireball()
        {
            Console.WriteLine($"{this.Name} {this.Id} casts Fireball for {this.Magicalpower} damage");

            foreach (var image in this.mirrirImages)
            {
                image.CastFireball();
            }
        }
    }
}
