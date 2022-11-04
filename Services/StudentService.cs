using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school_control_net.Commands.Students;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

namespace school_control_net.Services
{
      public class StudentService : IStudentService
      {
            private readonly SchoolDbContext dbContext;

            public StudentService(SchoolDbContext dbContext)
            {
                  this.dbContext = dbContext;
            }
            public async Task<Result<Student>> add(CreateStudentCommand student)
            {
                  var newStudent = new Student{
                        Name = student.Name,
                        Address = student.Address,
                        DateOfBirth = student.DateOfBirth
                  };
                  await dbContext.Students.AddAsync(newStudent);
                  await dbContext.SaveChangesAsync();
                  return Result<Student>.Ok(MsgConstants.SUCCESS, newStudent);
            }
      }
}