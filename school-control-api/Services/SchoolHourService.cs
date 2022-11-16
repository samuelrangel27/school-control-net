using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Models.SchoolHours;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Services
{
    public class SchoolHourService : ISchoolHourService
    {
        public Result<List<ISchoolHour>> ValidateHours(IEnumerable<ISchoolHour> hours, int maxHours)
        {
            var errors = new List<string>();
            int totalHours = hours.Sum(x => x.EndTime - x.StartTime);
            if(totalHours > maxHours)
                errors.Add($"Amount of hours exceeded max value {maxHours}");
            var overlappedDays = hours.GroupBy(x => x.Day).Where(x => x.Count() > 1).Select(x => x.Key);
            if(overlappedDays.Count() > 0){
                foreach(var d in overlappedDays){
                    errors.Add($"Overlapped hours for day {d}");
                }
            }
            if(errors.Any())
                return Result<List<ISchoolHour>>.Fail(MsgConstants.VALIDATION_ERRORS, errors);
            else
                return Result<List<ISchoolHour>>.Ok(MsgConstants.SUCCESS,hours.ToList());
        }

		public Result<List<ISchoolHour>> ValidateOverlappingSchedules(IEnumerable<ISchoolHour> s1, IEnumerable<ISchoolHour> s2)
		{
            var overlapped = s1.Join(s2, 
                x => x,
                x => x,
                (x,y) => x).ToList();

            if(overlapped.Any())
            {
                var errors = overlapped.Select(x => $"Overlapping school hour at {x.Day} between {x.StartTime} and {x.EndTime}").ToArray();
                return Result<List<ISchoolHour>>.Fail(MsgConstants.VALIDATION_ERRORS, errors, data: overlapped );
            }
			else
                return Result<List<ISchoolHour>>.Ok(MsgConstants.SUCCESS);
		}
	}
}