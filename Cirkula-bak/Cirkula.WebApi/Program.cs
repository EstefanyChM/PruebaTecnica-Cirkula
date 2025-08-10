using Cirkula.Business;
using Cirkula.BusinessImpl;
using Cirkula.Mapper;
using Cirkula.Repository;
using Cirkula.RepositoryImpl;
using Cirkula.ServiceImpl;
using Cirkula.Services;
using Cirkula.WebApi.Middleware;
using DBCirkula.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<_DBCirkulaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBCirkula")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region para la inyección de dependencias para business y repository
builder.Services.AddScoped<StoreBusiness, StoreBusinessImpl>();
builder.Services.AddScoped<StoreRepository, StoreRepositoryImpl>();
builder.Services.AddScoped<UnitOfWork, UnitOfWorkImpl>();
#endregion 

builder.Services.AddTransient<FirebaseService, FirebaseServiceImpl>();

//AUTOMAPPER
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

string myPolicy = "policyApiCirkula";
// CONFIGURACION DEL CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("myPolicy", policy =>
	{
		policy
		.WithOrigins(builder.Configuration["Config:OriginCors"]!)
		//.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myPolicy");

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
