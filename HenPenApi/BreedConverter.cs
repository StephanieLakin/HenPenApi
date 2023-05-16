using System.Text.Json;
using HenPenApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HenPenApi
{
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
            // Convert the Breed object to a JSON representation
            // You can customize this logic based on your requirements
            return breed != null ? JsonSerializer.Serialize(breed) : null;
        }

        private static Breed? ConvertToBreed(string? str)
        {
            // Convert the JSON representation back to a Breed object
            return str != null ? JsonSerializer.Deserialize<Breed>(str) : null;
        }
    }
}
