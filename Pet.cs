using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_csharp_virtual_pet
{
    public class Pet
    {
        public string Name;
        public string Species;
        public int Hunger;
        public int Boredom;
        public int Health;

        public Pet(string name, string species)
        {
            Name = name;
            Species = species;
            Hunger = 0;        // Hunger = 0 is good. Hunger = 100 decreases health
            Boredom = 0;       // Boredom = 0 is good. Boredom = 100 increase Hunger
            Health = 100;
        }
        public Pet()
        {
            Hunger = 60;
            Boredom = 60;
            Health = 60;
        }
        public void Play()
        {
            Hunger += 10;
            Boredom -= 20;
            Health += 10;
        }
        public void Tick()
        {
            Health -= 5;
            Hunger += 5;
            Boredom += 5;
        }
        public void SeeDoctor()
        {
            Health += 30;
        }
        public void Feed()
        {
            Hunger -= 10;
        }
        public bool IsDead()
        {
            Console.WriteLine("Your pet has died!");
            return Health == 0;
        }
        public bool IsHungry()
        {
            Console.WriteLine("Your pet is hungry!");
            return Hunger >= 50;
        }
        public bool IsBored()
        {
            Console.WriteLine("Your pet is bored!");
            return Boredom >= 50;
        }
    }
}
   