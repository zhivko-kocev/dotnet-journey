using dotnet_journey.Data;
using dotnet_journey.Models;

namespace dotnet_journey.Utils;

public class LinqPlayground
{
    public static void Run()
    {
        var people = SampleData.People;

        // ===== BASIC FILTERING & SELECTION =====

        Console.WriteLine("=== TASK: Find all people whose first name starts with 'S' ===");

        PrintResult(
            people
                .Where(p => p.FirstName.StartsWith('S'))
        );

        Console.WriteLine("=== TASK: Get only the first names of people from \"New York\" ===");

        PrintResult(
            people
                .Where(p => p.City == "New York")
                .Select(p => p.FirstName)
        );

        Console.WriteLine("=== TASK: Find people whose age is between 25 and 40 (inclusive) ===");

        PrintResult(
            people
                .Where(p => p.Age is >= 25 and <= 40)
        );

        Console.WriteLine("=== TASK: Get all unique cities (no duplicates) ===");

        PrintResult(
            people
                .Select(p => p.City)
                .Distinct()
        );

        Console.WriteLine("=== TASK: Find people whose last name contains \"son\" ===");
        ;

        PrintResult(
            people
                .Where(p => p.LastName.Contains("son"))
        );

        // ===== ORDERING & RANKING =====

        Console.WriteLine("=== TASK: Get the 3 oldest people ===");

        PrintResult(
            people
                .OrderByDescending(p => p.Age)
                .Take(3)
        );

        Console.WriteLine("=== TASK: Get the 5 youngest people, but skip the 2 youngest ===");

        PrintResult(
            people
                .OrderBy(p => p.Age)
                .Skip(2)
                .Take(5)
        );

        Console.WriteLine("=== TASK: Sort people by city, then by age within each city ===");

        PrintResult(
            people
                .OrderBy(p => p.City)
                .ThenBy(p => p.Age)
        );

        Console.WriteLine("=== TASK: Get every 3rd person when sorted by first name ===");

        PrintResult(
            people
                .OrderBy(p => p.FirstName)
                .Where((_, i) => i % 3 == 0)
        );

        // ===== AGGREGATION MASTERY =====

        Console.WriteLine("=== TASK: Calculate the average age of people from \"Brooklyn\" ===");
        PrintResult(
            people
                .Where(p => p.City == "Brooklyn")
                .Average(p => p.Age)
        );

        Console.WriteLine("=== TASK: Find the total number of characters in all first names combined ===");
        PrintResult(
            people
                .Select(p => p.FirstName.Length)
                .Sum()
        );

        Console.WriteLine("=== TASK: Get the age of the oldest person from each city ===");
        PrintResult(
            people
                .GroupBy(p => p.City)
                .Select(g => (g.Key, g.Max(p => p.Age)))
        );

        Console.WriteLine(
            "=== TASK: Count how many people are from each city, but only show cities with more than 1 person ===");
        PrintResult(
            people
                .GroupBy(p => p.City)
                .Where(g => g.Count() > 1)
                .ToDictionary(g => g.Key, g => g.Count())
        );

        Console.WriteLine("=== TASK: Find the median age (middle value when sorted) ===");
        PrintResult(
            people
                .OrderBy(p => p.Age)
                .Skip(people.Count % 2 == 0 ? people.Count / 2 - 1 : people.Count / 2)
                .Take(people.Count % 2 == 0 ? 2 : 1)
                .Select(p => (double)p.Age)
                .Average()
        );

        // ===== GROUPING CHALLENGES =====

        Console.WriteLine(
            "=== TASK: Group people by age ranges: \"Young\" (0-30), \"Middle\" (31-60), \"Senior\" (61-100), \"Ancient\" (100+) ===");

        PrintResult(
            people
                .GroupBy(p => p.Age switch
                {
                    <= 30 => "Young",
                    <= 60 => "Middle",
                    <= 100 => "Senior",
                    _ => "Ancient"
                })
                .ToDictionary(g => g.Key, g => string.Join(",\n", g.Select(p => $"{p.FirstName} {p.LastName}")))
        );

        Console.WriteLine("=== TASK: Group people by the first letter of their last name ===");

        PrintResult(
            people
                .GroupBy(p => p.FirstName[0])
                .ToDictionary(g => g.Key, g => string.Join(",\n", g.Select(p => $"{p.FirstName} {p.LastName}")))
        );

        // TODO: Find cities that have both people over 50 AND under 25
        // Use GroupBy(), Where(), and Any()
        Console.WriteLine("=== TASK: Find cities that have both people over 50 AND under 25 ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .Where(g => g.Any(p => p.Age > 50) && g.Any(p => p.Age < 25))
                .ToDictionary(g => g.Key, g => string.Join(",\n", g.Select(p => $"{p.FirstName} {p.LastName}")))
        );

        Console.WriteLine("=== TASK: Get the youngest person from each city ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .ToDictionary(
                    g => g.Key,
                    g => g.Aggregate((youngest, next) => next.Age < youngest.Age ? next : youngest))
        );

        // ===== ADVANCED PROJECTIONS =====

        Console.WriteLine(
            "=== TASK: Create a \"Person Card\" with formatted string: \"Tony Stark (48) from Malibu ===");

        PrintResult(
            people.Select(p => p.ToString())
        );


        Console.WriteLine("=== TASK: Create initials for each person (e.g., \"Tony Stark\" -> \"T.S.\") ===");

        PrintResult(
            people.Select(p => $"{p.FirstName[0]}.{p.LastName[0]}.")
        );

        Console.WriteLine("=== TASK: Calculate how many years until each person reaches 100 ===");

        PrintResult(
            people.Select(p => $"{p} - {Math.Max(0, 100 - p.Age)} left to 100")
        );

        Console.WriteLine(
            "=== TASK: Create a \"directory\" with people grouped by city, showing count and average age ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .ToDictionary(g => g.Key, g => new { Count = g.Count(), Average = g.Average(p => p.Age) })
        );


        // ===== QUANTIFIERS & EXISTENCE =====

        Console.WriteLine(
            "=== TASK: Check if ALL people are over 18 ===");

        PrintResult(
            people.All(p => p.Age >= 18)
        );

        Console.WriteLine(
            "=== TASK: Check if ANY person is exactly 42 years old ===");

        PrintResult(
            people.Any(p => p.Age == 42)
        );

        Console.WriteLine(
            "=== TASK: Find cities where NO ONE is under 30 ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .Where(g => g.All(p => p.Age >= 30))
                .ToDictionary(g => g.Key, g => string.Join(",\n", g.Select(p => $"{p.FirstName} {p.LastName}")))
        );

        // TODO: Check if there's at least one person from each: "New York", "Brooklyn", "Queens"
        // Use Any() with Contains()
        Console.WriteLine(
            "=== TASK: Check if there's at least one person from each: \"New York\", \"Brooklyn\", \"Queens\" ===");

        List<string> cityList = ["New York", "Brooklyn", "Queens"];
        PrintResult(
            cityList.All(city => people.Any(p => p.City == city))
        );

        // ===== SET OPERATIONS =====


        Console.WriteLine(
            "=== TASK: Find first names that appear more than once ===");

        PrintResult(
            people
                .GroupBy(p => p.FirstName)
                .Where(g => g.Count() > 1)
                .Select(p => p.Key)
        );

        Console.WriteLine(
            "=== TASK: Get all unique first letters of first names ===");

        PrintResult(
            people.Select(p => p.FirstName[0]).Distinct()
        );

        // TODO: Find people who share the same first name but have different last names
        // Use GroupBy() and Where() with Count()
        Console.WriteLine(
            "=== TASK: Find people who share the same first name but have different last names ===");

        PrintResult(
            people
                .GroupBy(p => p.FirstName)
                .Where(g => g.Count() > 1)
                .ToDictionary(g => g.Key, g => string.Join(",\n", g.Select(p => $"{p.FirstName} {p.LastName}")))
        );

        // ===== COMPLEX FILTERING =====

        // TODO: Find "power couples" - people from the same city with similar ages (within 5 years)
        // Use SelectMany() with Where() for cartesian product
        Console.WriteLine(
            "=== TASK: Find \"power couples\" - people from the same city with similar ages (within 5 years) ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .SelectMany(g => g.SelectMany(p1 => g
                        .Where(p2 => p1 != p2 && Math.Abs(p2.Age - p1.Age) < 5)
                        .Select(p2 => $"{p1} - {p2}")
                        .Distinct()
                    )
                )
        );

        Console.WriteLine("=== TASK: Find people whose first name length equals their age mod 10 ===");

        PrintResult(
            people.Where(p => p.FirstName.Length == p.Age % 10)
        );

        // TODO: Get people who are older than the average age of their city
        // Use Where() with GroupBy() and Average()
        Console.WriteLine("=== TASK: Get people who are older than the average age of their city ===");
        PrintResult(
            people
                .GroupBy(p => p.City)
                .SelectMany(g => g.Where(p => p.Age > g.Average(p1 => p1.Age)))
        );

        // ===== GURU-LEVEL CHALLENGES =====

        Console.WriteLine("=== TASK: Find the pair of people with the biggest age difference ===");

        PrintResult(
            people
                .SelectMany(
                    _ => people,
                    (p1, p2) => new { p1, p2, Diff = Math.Abs(p1.Age - p2.Age) }
                )
                .OrderByDescending(x => x.Diff)
                .First()
        );


        Console.WriteLine("=== TASK: Build a social network by city and age similarity (≤ 10 years) ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .SelectMany(group =>
                    group.SelectMany(p1 =>
                        group
                            .Where(p2 => p1 != p2 && Math.Abs(p1.Age - p2.Age) <= 10)
                            .Select(p2 => $"{p1} ↔ {p2}")
                    )
                )
                .Distinct()
        );


        Console.WriteLine("=== TASK: Census report per city ===");

        PrintResult(
            people
                .GroupBy(p => p.City)
                .Select(g => new
                {
                    City = g.Key,
                    Count = g.Count(),
                    AvgAge = g.Average(p => p.Age),
                    MinAge = g.Min(p => p.Age),
                    MaxAge = g.Max(p => p.Age),
                    MostCommonName = g
                        .GroupBy(p => p.FirstName)
                        .OrderByDescending(n => n.Count())
                        .First().Key
                })
                .Select(c =>
                    $"{c.City} - Count: {c.Count}, AvgAge: {c.AvgAge:F1}, Age Range: {c.MinAge}-{c.MaxAge}, Common Name: {c.MostCommonName}")
        );


        Console.WriteLine("=== TASK: Find loneliest and most social cities ===");

        var cityGroups = people.GroupBy(p => p.City).ToList();

        var loneliest = cityGroups.Where(g => g.Count() == 1).Select(g => g.Key);
        var mostSocial = cityGroups.OrderByDescending(g => g.Count()).First().Key;

        PrintResult(
            new[]
            {
                $"Loneliest cities: {string.Join(", ", loneliest)}",
                $"Most social city: {mostSocial}"
            }
        );


        Console.WriteLine("=== TASK: Birthday calendar - group by Age % 12 (Zodiac-like) ===");

        PrintResult(
            people
                .GroupBy(p => p.Age % 12)
                .ToDictionary(g => $"Zodiac {g.Key}", g => string.Join(", ", g.Select(p => p.FirstName)))
        );


        // ===== PERFORMANCE & OPTIMIZATION =====

        Console.WriteLine("=== TASK: Find the first person over 1000 years old ===");

        PrintResult(
            (dynamic)people.FirstOrDefault(p => p.Age > 1000)! ?? "No such person"
        );

        Console.WriteLine("=== TASK: Create city lookup table ===");

        var lookup = people.ToLookup(p => p.City);
        PrintResult(lookup.Select(g => $"{g.Key}: {g.Count()} people"));


        Console.WriteLine("=== TASK: Build dictionary of people by full name ===");

        var fullNameDict = people.ToDictionary(
            p => $"{p.FirstName} {p.LastName}",
            p => p
        );
        PrintResult(fullNameDict.Keys);


        // ===== REAL-WORLD SCENARIOS =====

        Console.WriteLine("=== TASK: Search for people with 'man' in first or last name ===");

        PrintResult(
            people.Where(p =>
                p.FirstName.Contains("man", StringComparison.OrdinalIgnoreCase) ||
                p.LastName.Contains("man", StringComparison.OrdinalIgnoreCase))
        );


        Console.WriteLine("=== TASK: Recommend 3 closest-in-age people for each person ===");

        PrintResult(
            people.Select(p =>
                    new
                    {
                        Person = p,
                        Recommendations = people
                            .Where(other => other != p)
                            .OrderBy(other => Math.Abs(p.Age - other.Age))
                            .Take(3)
                            .Select(r => $"{r.FirstName} ({r.Age})")
                    })
                .Select(x => $"{x.Person.FirstName}: {string.Join(", ", x.Recommendations)}")
        );


        Console.WriteLine("=== TASK: Report Summary ===");

        var total = people.Count;
        var avg = people.Average(p => p.Age);
        var cityDist = people
            .GroupBy(p => p.City)
            .Select(g => $"{g.Key} ({g.Count()})");

        PrintResult(
            new[]
            {
                $"Total People: {total}",
                $"Average Age: {avg:F1}",
                $"City Distribution: {string.Join(", ", cityDist)}"
            }
        );


        Console.WriteLine("=== TASK: Data validation - find people with invalid data ===");

        PrintResult(
            people.Where(p =>
                string.IsNullOrWhiteSpace(p.FirstName) ||
                string.IsNullOrWhiteSpace(p.LastName) ||
                p.Age < 0
            )
        );

        // ===== BONUS NINJA TECHNIQUES =====

        Console.WriteLine("=== TASK: All first names in one sentence ===");

        PrintResult(
            people
                .Select(p => p.FirstName)
                .Aggregate((acc, next) => $"{acc}, {next}")
        );


        Console.WriteLine("=== TASK: Get Adults (custom extension method) ===");

        PrintResult(
            people.GetAdults()
        );

        Console.WriteLine("=== TASK: People ranked by age ===");

        var ranked = people
            .OrderByDescending(p => p.Age)
            .Zip(Enumerable.Range(1, people.Count), (person, rank) => $"{rank}. {person}");

        PrintResult(ranked);


        Console.WriteLine("=== TASK: NY/Brooklyn people over 30, top 3 alphabetically ===");

        PrintResult(
            people
                .Where(p => (p.City == "New York" || p.City == "Brooklyn") && p.Age > 30)
                .OrderBy(p => p.FirstName)
                .Take(3)
                .Select(p => $"{p.FirstName} ({p.Age})")
        );
    }

    private static void PrintResult(dynamic result)
    {
        Console.WriteLine(string.Join("\n", result));
        Console.WriteLine();
    }
}