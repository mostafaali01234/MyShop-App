using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddTransient<IAccountTypesService, AccountTypesService>();
//builder.Services.AddTransient<ICartsService, CartsService>();
//builder.Services.AddTransient<ICartItemsService, CartItemsService>();
//builder.Services.AddTransient<ICategoriesService, CategoriesService>();
//builder.Services.AddTransient<ICitiesService, CitiesService>();
//builder.Services.AddTransient<IOrdersService, OrdersService>();
//builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
//builder.Services.AddTransient<IOrderTransactionsService, OrderTransactionsService>();
//builder.Services.AddTransient<IProductsService, ProductsService>();
//builder.Services.AddTransient<IProductReviewsService, ProductReviewsService>();
//builder.Services.AddTransient<IStatesService, StatesService>();
//builder.Services.AddTransient<IUsersService, UsersService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TestApi",
        Description = "My First Api",
        TermsOfService = new Uri("https://www.google.com"),
        Contact = new OpenApiContact
        {
            Name = "Mostafa",
            Email = "Mostafa@me.com",
            Url = new Uri("https://www.google.com")
        },
        License = new OpenApiLicense
        {
            Name = "My License",
            Url = new Uri("https://www.google.com")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT key"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
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

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
