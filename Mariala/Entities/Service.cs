using Mariala.Models.Base;

namespace Mariala.Entities
{
    public class Service:BaseNameableEntity
    {
        public string IconClass { get; set; } = null!;

        public string? Description { get; set; }
    }
}
