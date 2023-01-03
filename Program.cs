
using Microsoft.EntityFrameworkCore;
using miniprojektreddit.Model;
using miniprojektreddit.Service;
using Thread = miniprojektreddit.Model.Thread;

var builder = WebApplication.CreateBuilder(args);

// Sætter CORS så API'en kan bruges fra andre domæner
var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});


// Tilføj DbContext factory som service.
builder.Services.AddDbContext<RedditContext>(options => options.UseSqlite("Data Source=bin/RedditProjekt.db"));

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
    context.Response.ContentType = "application/json; charset=utf-8"; await next(context);
});

//Henter alle threads i en liste til forsiden hvor forfatter også vises
//Tidkompleksistet: Big O -> O(n) - linære tid - afhænger af elementer i arrayet 
app.MapGet("/api/threads", (DataService service) =>
{
    return service.GetThreads();
});

//Henter en bestemt tråd via id og viser tilhørende kommentar og user
//Tidkompleksistet: Big O -> O(1) - konstant tid - tager en operation og hente via id 
app.MapGet("/api/thread/{id}", (DataService service, int id) =>
{
    return service.GetThread(id);
});

//Henter alle kommentar der tilhører en bestemt tråd via dennes id
//Tidkompleksistet: Big O -> O(n) - linære tid - afhænger af elementer i arrayet 
app.MapGet("/api/comments/{id}", (DataService service, int id) =>
{
    return service.GetComments(id);
});

//Henter alle users
//Tidkompleksistet: Big O -> O(n) - linære tid - afhænger af elementer i arrayet
app.MapGet("/api/users", (DataService service) =>
{
    return service.GetUsers();
});

//Henter en user på id
//Tidkompleksistet: Big O -> O(1) - konstant tid - tager en operation og hente via id 
app.MapGet("/api/user/{id}", (DataService service, int id) =>
{
    return service.GetUser(id);
});

//Opretter en ny tråd med titel, user id, text og dato
//Tidkompleksistet: Big O -> O(1) - konstant tid - tager kun en operation uanset størrelsen
app.MapPost("/api/thread", (DataService service, Thread thread) =>
{
    string result = service.CreateThread(thread.Title, (int)thread.User.UserId, thread.Text, thread.Date); return new { message = result };
});

// Opretter en ny kommentar, som hører til en bestemt tråd
//Tidkompleksistet: Big O -> O(1) - konstant tid - tager kun en operation uanset størrelsen
app.MapPost("/api/thread/comment", (DataService service, Comment comment) =>
{
    string result = service.CreateComment(comment.Text, (int)comment.User.UserId, comment.Date, (int)comment.Thread.ThreadId);
    return new { message = result };
});


// PUT /api/post/{postId}/vote - Opdaterer en tråds antal stemmer
//Tidkompleksistet: Big O -> O(1) - konstant tid - tager kun en operation uanset størrelsen
app.MapPut("/api/threads/{threadId}/vote", (DataService service, Vote vote, int threadId) =>
{
    string results = service.AddVoteThread(threadId, vote.Votes);
    return new { message = results };
});

// PUT /api/posts/comments/{commentId}/vote - Opdaterer en kommentars antal stemmer
//Tidkompleksistet: Big O -> O(1) - konstant tid - tager kun en operation uanset størrelsen
app.MapPut("/api/threads/comments/{commentId}/vote", (DataService service, Vote vote, int commentId) =>
{
    string results = service.AddVoteComment(commentId, vote.Votes);
    return new { message = results };
});

app.Run();

