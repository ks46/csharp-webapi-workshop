using workshop.wwwapi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.MapGet("/hello/{name}", (string name, int age) => {
//    return age > 40 ? $"hello {name}" : $"hello {name}.. you are an elder";
//});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigureCarApi();

app.Run();
