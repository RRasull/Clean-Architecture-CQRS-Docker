using Clean_Architecture_CQRS_Docker.Application.CQRS.Handlers.CommandHandlers;
using Clean_Architecture_CQRS_Docker.Application.CQRS.Handlers.QueryHandlers;
using Clean_Architecture_CQRS_Docker.Infrastructure.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BloggingDatabase"));
});

builder.Services.AddTransient<GetAllProductQueryHandler>();
builder.Services.AddTransient<GetByIdProductQueryHandler>();
builder.Services.AddTransient<CreateProductCommandHandler>();
builder.Services.AddTransient<DeleteProductCommandHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();
