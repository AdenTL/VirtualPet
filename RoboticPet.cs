using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_csharp_virtual_pet
{
    public class RoboticPet : Pet
    {
        public int Battery;
        public int Armor;

        public RoboticPet(string Name, string species) : base(Name, species)
        {
            this.Name = Name;
            Species = species;
            Battery = 100;
            Armor = 100;
        }
        public RoboticPet()
        {
            Battery = 100;
            Armor = 100;
        }
        public void RepairArmor()
        {
            Armor += 30;
        }

        public void RechargeBattery()
        {
            Battery += 30;
        }
    }
}
  
