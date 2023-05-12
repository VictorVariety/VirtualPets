namespace VirtualPets
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var listOfPets = new List<PetClass>
            {
                new PetClass("Barky", 5, "Black", "Dog"),
                new PetClass("Meow", 2, "White", "Cat")
            };

            while (true)
            {
                var usersChoice = MainMenu();
                if (usersChoice == 1)
                {
                    ChoosePetInSystem(listOfPets);
                }
                else if (usersChoice == 2)
                {
                    PetCreation(listOfPets);
                }
                else continue;
            }

        }

        private static int MainMenu()
        {
            Console.WriteLine("1- Choose between pets in the system");
            Console.WriteLine("2- Create your own pet.");
            var usersChoice = Convert.ToInt32(Console.ReadLine());
            return usersChoice;
        }

        private static void PetCreation(List<PetClass> listOfPets)
        {
            bool isNotCorrect;
            string[] petArray;
            do
            {
                Console.WriteLine("Type in the name, color and type of the pet and separate them with space.");
                var petInput = Console.ReadLine();
                petArray = petInput.Split(' ');
                isNotCorrect = ValidatePetCreation(petArray);
            } while (isNotCorrect);

            listOfPets.Add(new(petArray[0], petArray[1], petArray[2]));
        }

        private static bool ValidatePetCreation(string[] petArray)
        {
            bool isNotCorrect;
            if (petArray.Length != 3)
            {
                Console.WriteLine("Wrong input");
                isNotCorrect = true;
            }
            else
            {
                isNotCorrect = false;
            }

            return isNotCorrect;
        }

        private static void ChoosePetInSystem(List<PetClass> listOfPets)
        {
            foreach (var pet in listOfPets)
            {
                System.Console.WriteLine($"Name: {pet.Name} the {pet.Type}");
            }

            Console.WriteLine("Choose a pet by typing the name to see the details.");
            var usersInput = Console.ReadLine();
            var selectedPet = PetChoice(listOfPets, usersInput);
            if (selectedPet == null) return;

            Console.WriteLine(
                $"Name: {selectedPet.Name}, Age: {selectedPet.Age}, Color: {selectedPet.Color}, Type: {selectedPet.Type}");
            bool isNotFavoriteFood = true;
            while (isNotFavoriteFood)
            {
                bool isWrongFood = true;
                int foodChoice = 0;
                while (isWrongFood)
                {
                    Console.WriteLine("Feed the pet. Food options are-");
                    for (var index = 0; index < PetClass.Foods.Length; index++)
                    {
                        var food = PetClass.Foods[index];
                        Console.WriteLine($"{index + 1} - {food}");
                    }

                    foodChoice = Convert.ToInt32(Console.ReadLine());
                    if (foodChoice <= PetClass.Foods.Length) isWrongFood = false;
                    else
                    {
                        Console.WriteLine("Wrong input.");
                        isWrongFood = true;
                    }
                }

                isNotFavoriteFood = FoodReaction(foodChoice - 1, selectedPet);
            }
        }

        private static bool FoodReaction(int foodIndex, PetClass pet)
        {
            var food = PetClass.Foods[foodIndex];
            Console.WriteLine(pet.FavoriteFood == food ? "Yum yum, my favorite food!!" : "Thank you for the food, but not my favorite.");
            return food != pet.FavoriteFood;
        }

        private static PetClass PetChoice(List<PetClass> listOfPets, string usersInput)
        {
            PetClass petPick = null;
            listOfPets.ForEach(pet =>
            {
                if (pet.Name == usersInput)
                {
                    petPick = pet;
                }
                
            });
            if (petPick == null)
            { 
                Console.WriteLine("No pet by that name, try again");
            }
            return petPick;
        }
    }
}