using MediatR;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using school_control_net.Commands.Classes;
using school_control_net.DbContexts;
using school_control_net.Entities;
using school_control_net.Services;
using school_control_net.Services.Interfaces;
using school_control_net.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(optx =>
    {
        optx.AddRouteComponents("odata", GetEdmModel(),
            services => services.AddSingleton<ODataResourceSerializer, OmitNullResourceSerializer>());
    })
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateClassCommand).Assembly);
builder.Services.AddDbContext<SchoolDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection")));

builder.Services.AddScoped<IClassesService,ClassesService>();
builder.Services.AddScoped<ITeacherService,TeacherService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<ISchoolCycleService,SchoolCycleService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ISchoolHourService,SchoolHourService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EnableLowerCamelCase();

    builder.EntitySet<Classes>("Classes")
        .EntityType.Count().Filter().OrderBy().Expand().Select().Page(100, 100);
    builder.EntitySet<Teacher>("Teacher")
        .EntityType.Count().Filter().OrderBy().Expand().Select().Page(100, 100);
    builder.EntitySet<Student>("Student")
        .EntityType.Count().Filter().OrderBy().Expand().Select().Page(100, 100);
    builder.EntitySet<SchoolCycle>("SchoolCycle")
        .EntityType.Count().Filter().OrderBy().Expand().Select().Page(100, 100);
    builder.EntitySet<Course>("Course")
        .EntityType.Count().Filter().OrderBy().Expand().Select().Page(100, 100);

    return builder.GetEdmModel();
}