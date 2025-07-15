using dotnet_journey.Models;

namespace dotnet_journey.Data;

public class SampleData
{
    public static List<Person> People => new()
    {
        // Original Avengers & Core Heroes
        new Person("Tony", "Stark", 48, "Malibu"),
        new Person("Bruce", "Banner", 49, "Dayton"),
        new Person("Steve", "Rogers", 100, "Brooklyn"),
        new Person("Natasha", "Romanoff", 39, "Stalingrad"),
        new Person("Peter", "Parker", 21, "Queens"),
        new Person("Wanda", "Maximoff", 29, "Sokovia"),
        new Person("Stephen", "Strange", 42, "New York"),
        new Person("Carol", "Danvers", 38, "Boston"),
        new Person("Scott", "Lang", 40, "San Francisco"),
        new Person("Hope", "van Dyne", 36, "San Francisco"),
        new Person("T'Challa", "Udaku", 40, "Wakanda"),
        new Person("Sam", "Wilson", 38, "Washington"),
        new Person("Bucky", "Barnes", 102, "Brooklyn"),
        new Person("Clint", "Barton", 45, "Iowa"),
        new Person("Nick", "Fury", 65, "Unknown"),
        new Person("Loki", "Laufeyson", 1050, "Asgard"),
        new Person("Thor", "Odinson", 1500, "Asgard"),
        new Person("Gamora", "Zen Whoberi", 29, "Space"),
        new Person("Rocket", "Raccoon", 8, "Space"),
        new Person("Groot", "Groot", 5, "Space"),
        new Person("Shuri", "Udaku", 21, "Wakanda"),
        new Person("Pepper", "Potts", 47, "Malibu"),
        new Person("Jane", "Foster", 41, "New Mexico"),

        // X-Men
        new Person("Charles", "Xavier", 60, "Westchester"),
        new Person("Logan", "Howlett", 200, "Canada"),
        new Person("Ororo", "Munroe", 35, "Kenya"),
        new Person("Jean", "Grey", 32, "Annandale-on-Hudson"),
        new Person("Scott", "Summers", 35, "Anchorage"),
        new Person("Kurt", "Wagner", 40, "Germany"),
        new Person("Kitty", "Pryde", 28, "Chicago"),
        new Person("Bobby", "Drake", 30, "Boston"),
        new Person("Remy", "LeBeau", 35, "New Orleans"),
        new Person("Rogue", "D'Ancanto", 32, "Mississippi"),
        new Person("Erik", "Lehnsherr", 70, "Germany"),
        new Person("Hank", "McCoy", 45, "Illinois"),
        new Person("Warren", "Worthington III", 32, "Centerport"),

        // Fantastic Four
        new Person("Reed", "Richards", 45, "New York"),
        new Person("Sue", "Storm", 35, "New York"),
        new Person("Johnny", "Storm", 28, "New York"),
        new Person("Ben", "Grimm", 42, "New York"),
        new Person("Victor", "Von Doom", 40, "Latveria"),

        // Guardians of the Galaxy
        new Person("Peter", "Quill", 38, "Missouri"),
        new Person("Drax", "Destroyer", 50, "Space"),
        new Person("Nebula", "Luphomoid", 35, "Space"),
        new Person("Mantis", "Celestial", 25, "Space"),
        new Person("Yondu", "Udonta", 60, "Space"),

        // Street Level Heroes
        new Person("Matt", "Murdock", 35, "Hell's Kitchen"),
        new Person("Jessica", "Jones", 33, "Hell's Kitchen"),
        new Person("Luke", "Cage", 35, "Harlem"),
        new Person("Danny", "Rand", 30, "New York"),
        new Person("Frank", "Castle", 45, "New York"),
        new Person("Wade", "Wilson", 40, "Canada"),
        new Person("Miles", "Morales", 17, "Brooklyn"),
        new Person("Gwen", "Stacy", 19, "Queens"),

        // Villains
        new Person("Thanos", "Titan", 1000, "Titan"),
        new Person("Ultron", "AI", 1, "Sokovia"),
        new Person("Hela", "Odinsdottir", 5000, "Asgard"),
        new Person("Ego", "Celestial", 1000000, "Space"),
        new Person("Ronan", "Accuser", 500, "Hala"),
        new Person("Red", "Skull", 90, "Germany"),
        new Person("Killmonger", "Stevens", 32, "Oakland"),
        new Person("Zemo", "Baron", 45, "Sokovia"),
        new Person("Kaecilius", "Sorcerer", 50, "Kamar-Taj"),
        new Person("Mysterio", "Beck", 40, "New York"),
        new Person("Vulture", "Toomes", 55, "Queens"),
        new Person("Green", "Goblin", 52, "New York"),
        new Person("Wilson", "Fisk", 48, "Hell's Kitchen"),

        // Supporting Characters
        new Person("May", "Parker", 55, "Queens"),
        new Person("Happy", "Hogan", 50, "New York"),
        new Person("Rhodey", "Rhodes", 50, "Washington"),
        new Person("Maria", "Hill", 45, "Chicago"),
        new Person("Phil", "Coulson", 55, "Wisconsin"),
        new Person("Darcy", "Lewis", 28, "Culver University"),
        new Person("Selvig", "Erik", 60, "Norway"),
        new Person("Okoye", "General", 40, "Wakanda"),
        new Person("Ramonda", "Queen", 65, "Wakanda"),
        new Person("Nakia", "Warrior", 35, "Wakanda"),
        new Person("Valkyrie", "Scrapper", 1500, "Asgard"),
        new Person("Heimdall", "Gatekeeper", 5000, "Asgard"),
        new Person("Frigga", "Queen", 5000, "Asgard"),
        new Person("Odin", "Allfather", 5000, "Asgard"),

        // Cosmic Characters
        new Person("Adam", "Warlock", 30, "Space"),
        new Person("Nova", "Rider", 25, "Space"),
        new Person("Silver", "Surfer", 1000, "Space"),
        new Person("Galactus", "Devourer", 1000000, "Space"),
        new Person("Dormammu", "Ruler", 1000000, "Dark Dimension"),

        // Newer Heroes
        new Person("Kamala", "Khan", 17, "Jersey City"),
        new Person("Kate", "Bishop", 22, "New York"),
        new Person("Yelena", "Belova", 28, "Russia"),
        new Person("John", "Walker", 35, "Custer's Grove"),
        new Person("Layla", "El-Faouly", 30, "Egypt"),
        new Person("Marc", "Spector", 40, "Chicago"),
        new Person("Jennifer", "Walters", 35, "Los Angeles"),
        new Person("Amadeus", "Cho", 19, "Tucson")
    };
}

public static class PersonExtensions
{
    public static IEnumerable<Person> GetAdults(this List<Person> people) =>
        people.Where(p => p.Age >= 18);
}