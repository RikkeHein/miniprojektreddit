using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using miniprojektreddit.Model;
using miniprojektreddit.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.ConstrainedExecution;


var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføj DbContext factory som service.
builder.Services.AddDbContext<RedditContext>(options =>
    options.UseSqlite("Data Source=bin/RedditProjekt.db"));

// Tilføj DataService så den kan bruges i endpoints
builder.Services.AddScoped<DataService>();


var app = builder.Build();

// Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
  //  dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}


app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);


// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

app.MapGet("/api/threads", (DataService service) =>
{
    return service.GetThreads().Select(t => new
    {
        threadId = t.ThreadId,
        title = t.Title,
        author = new
        {
            t.Author.UserId,
            t.Author.Name

        },
        text = t.Text,
        date = t.Date,
        upvote = t.Upvote,
        downvote = t.Downvote
    });
});


app.MapGet("/api/thread/{id}", (DataService service, int id) =>
{
    return service.GetThreadWithComments(id);
});




app.Run();
