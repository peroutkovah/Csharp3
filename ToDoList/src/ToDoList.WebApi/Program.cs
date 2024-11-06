
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);
{
    //Configure DI
    //WebApi services
    builder.Services.AddControllers(); //pridalo ToDOItemsController
    builder.Services.AddSwaggerGen();


    //Persistence services

    builder.Services.AddDbContext<ToDoItemsContext>(); //pridalo toDOItemsCOntext
    builder.Services.AddScoped<IRepository<ToDoItem>, ToDoItemsRepository>(); //pridalo ToDOITemRepositories
}

var app = builder.Build();
{
    //Configure Middleware (HTTP request pipeline)
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoList API V1"));
}

app.Run();
