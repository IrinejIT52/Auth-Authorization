using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projekat_praksa.Database;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.Http,
		Scheme = "Bearer"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference{ Type= ReferenceType.SecurityScheme, Id="bearerAuth"}
			},
			[]
		}
	});
});

builder.Services.AddAuthentication();


builder.Services.AddIdentityApiEndpoints<User>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<UserDbContext>()
	.AddDefaultTokenProviders(); 

builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.MapGroup("api/").MapIdentityApi<User>();  // dodavanje endpointa za log i reg

app.Run();