using Microsoft.EntityFrameworkCore;
using ContactAPI.Database;
using ContactsAPI.Functionality;
using ContactsAPI.Implementation;
using FluentValidation.AspNetCore;
using ContactsAPI.Models.FluentModelValidation;
using FluentValidation;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Server.IIS;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container. (ContactOperation , ContactDbCOntext)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Now i don't need to create obj of ContactDbContext class Explicit 
//.NET Core provides unity container to create an object of ContactDbContext Class
builder.Services.AddValidatorsFromAssemblyContaining<Validator>();
builder.Services.AddDbContext<ContactsDbContext>(t=> t.UseSqlServer(builder.Configuration.GetConnectionString("myconnection")));
//need to apply per call Architecture 
builder.Services.AddTransient<IContactsOperations, ContactsOperation>();   //strongly recommendation use Reflection 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IValidator<Contacts>, Validator>();      //IValidator generic 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();   
app.Run();

