using Mariala.Entities;

namespace Mariala.Areas.Admin.ViewModels
{
    public class EmployeeCreateVM
    {
        public string Name { get; set; } = null!;
        public IFormFile Photo { get; set; } = null!;
        public int ProfessionId { get; set; }
        public IEnumerable<Profession> Professions { get; set; } = new List<Profession>();
        public string? TwitterUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
    }
}
