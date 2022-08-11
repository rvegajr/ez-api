var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null)
    .AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(null));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddODataApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddOdataSwaggerSupport();

builder.Services.AddDbContext<EzDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EzConnectionString"), x => x.UseNetTopologySuite());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
