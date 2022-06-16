using template_csharp_virtual_pet;
// Your Program Code Here
Console.WriteLine("----Welcome to Virtual Pet!----");
Console.WriteLine("First, lets create a Pet.");
Console.WriteLine("Press enter to continue");
Console.ReadLine();

Console.Clear();
Console.WriteLine("What is the pet's name?");
string name = Console.ReadLine();

Console.WriteLine("Pet's species?");
string species = Console.ReadLine();

Console.WriteLine("Is this pet Robotic? (yes or no)");
string type = Console.ReadLine().ToLower();
Pet activePet;
List<Pet> pets = new List<Pet>();
if (type == "yes")
{
    activePet = new RoboticPet(name, species);
    pets.Add(activePet);
    Console.WriteLine($"A new robotic {species} named, {name} has been created!");
    Console.WriteLine("Since it is robotic, it will not lose health over time. But, it does have a battery that must be recharged!");
    Console.WriteLine("Press enter to continue");
    Console.ReadLine();
}
else if (type == "no")
{
    activePet = new Pet(name, species);
    pets.Add(activePet);
    Console.WriteLine($"A new {species} named, {name} has been created!");
    Console.WriteLine("This pet is organic, you must take care of it!");
    Console.WriteLine("Press enter to continue");
    Console.ReadLine();
}
else
{
    activePet = new Pet(name, species);
    Console.WriteLine("A default pet has been created.");
}
bool isRunning = true;
while (isRunning)
{
    Console.Clear();
    Console.WriteLine("----MAIN MENU----");
    Console.WriteLine("Select an option:");
    Console.WriteLine("0 - Exit Game" +
        "\n1 - Create new pet" +
        "\n2 - Check all pet statuses" +
        "\n3 - Interact with pet" +
        "\n4 - Go to shelter");
    int userSelection = Int32.Parse(Console.ReadLine());
    switch (userSelection)
    {
        case 0:
            isRunning = false;
            break;
        case 1:                                                                         // create new pet
            Console.Clear();
            Console.WriteLine("What is your pet's name?");
            name = Console.ReadLine();

            Console.WriteLine("Pet's species?");
            species = Console.ReadLine();

            Console.WriteLine("Is this pet Robotic? (yes or no)");
            type = Console.ReadLine().ToLower();
            if (type == "no")                                               //TODO: currently if a user creates new pet from main, organic pets are added twice.
            {
                activePet = new Pet(name, species);
                pets.Add(activePet);
            }
            if (type == "yes")
            {
                activePet = new RoboticPet(name, species);
                pets.Add(activePet);
            }

            Pet toAdd = new Pet(name, species);
            pets.Add(toAdd);

            if (activePet.GetType() == typeof(RoboticPet))
            {
                toAdd = new RoboticPet(name, species);
                Console.WriteLine($"A new robotic {species} named, {name} has been created!");
                Console.WriteLine("Since it is robotic, it will not lose health over time. But, it does have a battery that must be recharged!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else if (activePet.GetType() != typeof(RoboticPet))
            {
                toAdd = new Pet(name, species);
                Console.WriteLine($"A new {species} named, {name} has been created!");
                Console.WriteLine("This pet is organic, you must take care of it!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            else
            {
                toAdd = new Pet(name, species);
                Console.WriteLine("A default pet has been created.");
            }

            break;
        case 2:                                                              // display all pet statuses
            Console.Clear();
            for(int i = 0; i < pets.Count; i++)
                {
                if (activePet.GetType() == typeof(RoboticPet))
                {
                    Console.WriteLine($"{pets[i].Name}" +
                        $"\nHealth: {pets[i].Health}" +
                        $"\nBoredom: {pets[i].Boredom}" +
                        $"\nHunger: {pets[i].Hunger}" //+
                        //$"\nBattery: {pets[i].Battery}" +
                        //$"\nArmor: {pets[i].Armor}"
                        );
                }
                else
                {
                    Console.WriteLine($"{pets[i].Name}" +
                        $"\nHealth: {pets[i].Health}" +
                        $"\nBoredom: {pets[i].Boredom}" +
                        $"\nHunger: {pets[i].Hunger}");
                }
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            break;
        case 3:                                                         // interact with pet
            while (activePet.GetType() == typeof(RoboticPet))
            {
                Console.Clear();
                Console.WriteLine("What would you like to do with your pet?");
                Console.WriteLine($"1 - Take {activePet.Name} to Doctor" +
                    $"\n2 - Play with {activePet.Name}" +
                    $"\n3 - Feed {activePet.Name}" +
                    $"\n4 - Recharge {activePet.Name}'s battery" +
                    $"\n5 - Repair {activePet.Name}'s armor" +
                    $"\n6 - Go back to Main Menu");
                int _selection = Int32.Parse(Console.ReadLine());
                if (_selection == 1)
                {
                    activePet.SeeDoctor();
                    activePet.Tick();
                    Console.WriteLine($"{activePet.Name} has been taken to the doctor! Its health is now:{activePet.Health}" + "/100");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (_selection == 2)
                {
                    activePet.Play();
                    activePet.Tick();
                    Console.WriteLine($"{activePet.Name} enjoyed play time! Its boredom level is now: {activePet.Boredom}" + "/100");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (_selection == 3)
                {
                    activePet.Feed();
                    activePet.Tick();
                    Console.WriteLine($"{activePet.Name} had a good meal! Its hunger level is now: {activePet.Hunger}" + "/100");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (_selection == 4)
                {
                    RoboticPet temp = (RoboticPet)activePet;
                    temp.RechargeBattery();
                }
                else if (_selection == 5)
                {
                    RoboticPet temp = (RoboticPet)activePet;
                    temp.RepairArmor();
                }
            }
            while(activePet.GetType() != typeof(RoboticPet))
            {
                Console.Clear();
                Console.WriteLine("What would you like to do with your pet?");
                Console.WriteLine($"1 - Take {activePet.Name} to Doctor" +
                    $"\n2 - Play with {activePet.Name}" +
                    $"\n3 - Feed {activePet.Name}" +
                    $"\n4 - Back to Main Menu");
                int selection = Int32.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    activePet.SeeDoctor();
                    activePet.Tick();
                    Console.WriteLine($"{activePet.Name} has been taken to the doctor! Its health is now:{activePet.Health}" + "/100");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (selection == 2)
                {
                    activePet.Play();
                    activePet.Tick();
                    Console.WriteLine($"{activePet.Name} enjoyed play time! Its boredom level is now: {activePet.Boredom}" + "/100");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (selection == 3)
                {
                    activePet.Feed();
                    activePet.Tick();
                    Console.WriteLine($"{activePet.Name} had a good meal! Its hunger level is now: {activePet.Hunger}" + "/100");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                else if (selection == 4)
                {
                    Console.WriteLine("Returning to Main Menu.");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;
                }
            }

            if (activePet.Health <= 0)
            {
                pets.Remove(activePet);
                activePet = new Pet();
                Console.WriteLine("Your pet has died.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;
            }
                break;
        case 4:                                            // go to shelter
            Console.Clear();
            Console.WriteLine($"What would you like to do?" +
                $"\n0 - Back to Main Menu" +
                $"\n1 - View all pets in shelter" +
                $"\n2 - Feed all pets in shelter" +
                $"\n3 - Play with all pets in shelter" +
                $"\n4 - Heal all pets");
            int __selection = Int32.Parse(Console.ReadLine());
            if (__selection == 0)
            {
                break;
            }
            if (__selection == 1)
            {
                Console.WriteLine("----ALL PETS----");
                for (int i = 0; i < pets.Count; i++)
                {
                    Console.WriteLine(i + "." + ' ' + pets[i].Name + ' ' + pets[i].Species);
                }
                Console.WriteLine("Which pet do you want to choose?");
                int swapTo = Int32.Parse(Console.ReadLine());
                activePet = pets[swapTo];
                Console.WriteLine("You chose a new pet! It is now: " + activePet.Name);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if (__selection == 2)
            {
                foreach (Pet pet in pets)
                {
                    pet.Feed();
                    Console.WriteLine("All pets in the shelter have been fed!");
                }
            }
            if (__selection == 3)
            {
                foreach (Pet pet in pets)
                {
                    pet.Play();
                    Console.WriteLine("You played with all pets in the shelter!");
                }
            }
            if (__selection == 4)
            {
                foreach (Pet pet in pets)
                {
                    if (pet.GetType() == typeof(RoboticPet))
                    {
                        RoboticPet temp = (RoboticPet)pet;
                        temp.RepairArmor();
                        temp.RechargeBattery();
                    }
                    else
                    {
                        pet.SeeDoctor();
                    }
                }
                Console.WriteLine("Status for all pets have been replenished!");
            }
            break;
        default:
            break;
    }
}