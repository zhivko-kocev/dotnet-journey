namespace dotnet_journey.Models;

public record Person(string FirstName, string LastName, int Age, string City)
{
    public override string ToString()
    {
        return $"{FirstName} {LastName} {Age} years old, from {City}";
    }
}