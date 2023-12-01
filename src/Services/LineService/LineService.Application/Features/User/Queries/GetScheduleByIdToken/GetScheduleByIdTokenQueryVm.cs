using System;
namespace LineService.Application.Features.User.Queries.GetScheduleByIdToken
{
	public class GetScheduleByIdTokenQueryVm
	{
		public List<workday>? HeaderSchedule { get; set; }
		public List<shift>? StaffSchedule { get; set; }
    }

	public class workday
	{
		public string? DayOfWeek { get; set; }
		public string? Date { get; set; }
	}

    public class shift
    {
        public string? DisplayName { get; set; }
        public string? Name { get; set; }
        public string? PictureUrl { get; set; }
		public List<string>? WorkShift { get; set; } = new List<string>();
    }
}