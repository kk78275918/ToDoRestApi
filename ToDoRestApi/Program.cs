using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoRestApi.DataContext;
using ToDoRestApi.Repository;
using ToDoRestApi.ToDoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ToDoServices>();

// Add authentication (if needed)
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//	.AddJwtBearer(options =>
//	{
//		options.TokenValidationParameters = new TokenValidationParameters
//		{
//			ValidateIssuer = true,
//			ValidateAudience = true,
//			ValidateLifetime = true,
//			ValidateIssuerSigningKey = true,
//			// Add your token key here
//			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""))
//		};
//	});

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

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
