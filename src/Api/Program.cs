using Api.Extensions;
using Api.Middlewere;
using Application.Features.Owners.Commands.CreateOwner;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplicationServices();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper();
builder.Services.ConfigureCors();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(CreateOwnerCommand).Assembly);
});

MongoDbConfigurator.Configure();
var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Origins");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();


