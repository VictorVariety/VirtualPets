namespace VirtualPets;

public class PetClass
{
    public static string[] Foods = new[] { "Banan", "Blåbær", "Kjøtt", "Melk" };
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Color { get; private set; }
    public string Type { get; private set; }
    public string FavoriteFood = favoriteFood();
    public List<PetClass> ListOfPets = new();

    public PetClass(string name, string color, string type)
    {
        Name = name;
        Color = color;
        Type = type;
    }
    public PetClass(string name, int age, string color, string type)
    {
        Name = name;
        Age = age;
        Color = color;
        Type = type;
    }
    
    static string favoriteFood()
    {
        //var random = new Random();
        var index = new Random().Next(0, Foods.Length);
        return Foods[index];
    }
}