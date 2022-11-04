using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.SchoolCycles;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Services
{
    public class SchoolCycleService : ISchoolCycleService
    {
        private readonly SchoolDbContext context;

        public SchoolCycleService(SchoolDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<SchoolCycle>> add(CreateCycleCommand cycle)
        {
            var existingCycle = context.SchoolCycles
                .FirstOrDefault(x => x.Status == SchoolCycleStatus.New);
            if(existingCycle != null)
                return Result<SchoolCycle>.Fail("There is already a cycle with status New");

            if(cycle.EndDate < cycle.StartDate)
                return Result<SchoolCycle>.Fail("End date must be greater than start date");

            if(cycle.EndDate.Month - cycle.StartDate.Month < 5)
                return Result<SchoolCycle>.Fail("The duration of the cycle must be at least 5 months");

            var sameYearCycles = context.SchoolCycles
                .Where(x => x.StartDate.Year == cycle.StartDate.Year)
                .ToArray();
            
            if(sameYearCycles.Length == 2)
                return Result<SchoolCycle>.Fail("There can only be 2 cycles every year");

            if(sameYearCycles.FirstOrDefault()?.EndDate < cycle.StartDate)
                return Result<SchoolCycle>.Fail("Start date must be greater than previous cycle's end date");

            var newCycle = new SchoolCycle
            {
                Description = cycle.Description,
                StartDate = cycle.StartDate,
                EndDate = cycle.EndDate,
                Status = SchoolCycleStatus.New
            };
            await context.SchoolCycles.AddAsync(newCycle);
            await context.SaveChangesAsync();
            return Result<SchoolCycle>.Ok(MsgConstants.SUCCESS,newCycle);
        }
    }
}