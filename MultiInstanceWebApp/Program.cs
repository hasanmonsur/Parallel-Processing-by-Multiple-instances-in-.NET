using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configure Redis connection
var redis = ConnectionMultiplexer.Connect(builder.Configuration["Redis:Configuration"]);
//var redis = ConnectionMultiplexer.Connect("redis:6379");
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://+:51"); // Change to a new port

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
