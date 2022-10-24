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
using Thread = miniprojektreddit.Model.Thread;

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
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}


app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);


// Middlware der kører før hver request. Sætter ContentType for alle responses til "JSON".
app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

//Henter alle threads i en liste til forsiden hvor forfatter også vises
app.MapGet("/api/threads", (DataService service) =>
{
    return service.GetThreads().Select(t => new
    {
        threadId = t.ThreadId,
        title = t.Title,
        author = new
        {
            t.User.UserId,
            t.User.Name

        },
        text = t.Text,
        date = t.Date,
        upvote = t.Upvote,
        downvote = t.Downvote
    });
});

//Henter en bestemt tråd via id og viser tilhørende kommentar og user 
app.MapGet("/api/thread/{id}", (DataService service, int id) =>
{
    return service.GetThread(id);
});


//Henter alle kommentar der tilhører en bestemt tråd via dennes id
app.MapGet("/api/comments/{id}", (DataService service, int id) =>
{
    return service.GetComments(id);
}); 

//Opretter en ny tråd med titel, user id, text og dato 
app.MapPost("/api/thread", (DataService service, Thread thread) => 
{
    string result = service.CreateThread(thread.Title, (int)thread.User.UserId, thread.Text, thread.Date);
    return new { message = result };

});

// Opretter en ny kommentar, som hører til en bestemt tråd
app.MapPost("/api/thread/comment", (DataService service, Comment comment) =>
{
    string result = service.CreateComment(comment.Text, (int)comment.User.UserId, comment.Date, (int)comment.Thread.ThreadId);
    return new { message = result };
});



app.Run();