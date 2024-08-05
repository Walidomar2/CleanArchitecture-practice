using System.ComponentModel.DataAnnotations;

namespace CleanArchitecute.Core.Entities
{
    public class Car
    {
        int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
