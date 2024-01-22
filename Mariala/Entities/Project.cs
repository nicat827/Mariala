using Mariala.Models.Base;

namespace Mariala.Entities
{
    public class Project:BaseNameableEntity
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
