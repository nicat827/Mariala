using Mariala.Models.Base;

namespace Mariala.Entities
{
    public class Employee:BaseNameableEntity
    {
        public string ImageUrl { get; set; } = null!;

        public int ProfessionId { get; set; }

        public Profession Profession { get; set; } = null!;

        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
    }
}
