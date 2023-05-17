using HenPenApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

public class BreedConverter : ValueConverter<Breed?, string?>
{
    public BreedConverter(ConverterMappingHints? mappingHints = null)
        : base(
            breed => ConvertToString(breed),
            str => ConvertToBreed(str),
            mappingHints)
    {
    }

    private static string? ConvertToString(Breed? breed)
    {
        if (breed != null)
        {
            string jsonString = JsonSerializer.Serialize(breed);
            return jsonString;
        }

        return null;
    }

    private static Breed? ConvertToBreed(string? str)
    {
        if (str != null)
        {
            try
            {
                Breed? breed = JsonSerializer.Deserialize<Breed?>(str);
                return breed;
            }
            catch (JsonException ex)
            {
                // Handle the exception here
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
                return null;
            }
        }

        return null;
    }
}
