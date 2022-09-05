using Activities.Models;

namespace Acitivity.ViewModels
{
    public class ActivityViewModel
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }

        public DateTime? ActivityDate { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public string? Description { get; set; }
        public int? Quota { get; set; }
        public string? Address { get; set; }

        public string? Isticked { get; set; }

        public int CityId { get; set; }


    }
}
