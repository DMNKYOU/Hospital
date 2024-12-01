using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PMI.Hospital.Infrastructure;
using PMI.Hospital.Infrastructure.Mapper;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;
using PMI.Hospital.Infrastructure.Persistence.People.Mapper;
using PMI.Hospital.Middleware;
using PMI.Service.PersonalizationHub.Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

//values
const string DatabaseMigrationError = "An error occurred while migrating the database";

// Add services to the container.
builder.Services.AddPersistenceStorage(builder.Configuration);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new PeopleModelProfile());
    mc.AddProfile(new PeopleDtoProfile());
    mc.AddProfile(new PeopleProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Maternity Hospital", Version = "v1" }));
builder.Services.AddBusinessLayerDependencies();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, DatabaseMigrationError);
    }
}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
