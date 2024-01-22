using Mariala.Models.Base;

namespace Mariala.Areas.Admin.ViewModels
{
    public class PaginationVM<T> where T : BaseEntity
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}
