using AutoMapper;
using LineService.Application.Contracts.Services;
using MediatR;

namespace LineService.Application.Features.User.Queries.GetScheduleByIdToken
{
    public class GetScheduleByIdTokenQueryHandler : IRequestHandler<GetScheduleByIdTokenQuery, GetScheduleByIdTokenQueryVm>
    {
        private readonly ILineServiceRepository _lineServiceRepository;
        private readonly IMapper _mapper;

        public GetScheduleByIdTokenQueryHandler(ILineServiceRepository lineServiceRepository, IMapper mapper)
        {
            _lineServiceRepository = lineServiceRepository ?? throw new ArgumentNullException(nameof(lineServiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetScheduleByIdTokenQueryVm> Handle(GetScheduleByIdTokenQuery request, CancellationToken cancellationToken)
        {

            ////// HeaderSchedule
            DateTime startDate = DateTime.Today;           
            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(-1);
            };

            List<workday> header = new List<workday>();

            startDate = startDate.AddDays(-1); // reset to day before monday
            for (int i = 0; i < 7; i++)
            {
                startDate = startDate.AddDays(1);
                header.Add(new workday { DayOfWeek = startDate.DayOfWeek.ToString(), Date = startDate.Day.ToString() });
            };

            ////// StaffSchedule
            var staff = await _lineServiceRepository.Get();            
            var workShift = _mapper.Map<List<shift>>(staff);

            var res = new GetScheduleByIdTokenQueryVm
            {
                HeaderSchedule = header,
                StaffSchedule = workShift
            };

            return res;
        }
    }
}

