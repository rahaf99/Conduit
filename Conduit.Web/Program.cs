using AutoMapper;
using Conduit.Db;
using Conduit.Db.AuthenticationAndRefresh.Authentication;
using Conduit.Db.AuthenticationAndRefresh.RefreshTokenGenerator;
using Conduit.Db.Entities;
using Conduit.Db.Repositories.Articles;
using Conduit.Db.Repositories.Comments;
using Conduit.Db.Repositories.FavouriteArticles;
using Conduit.Db.Repositories.Follows;
using Conduit.Db.Repositories.Users;
using Conduit.Web.JWT;
using Conduit.Web.JWT.Authentication;
using Conduit.Web.JWT.RefreshTokenGenerator;
using Conduit.Web.Models;
using Conduit.Web.Services.Articles;
using Conduit.Web.Services.Comments;
using Conduit.Web.Services.FavouriteArticles;
using Conduit.Web.Services.Follows;
using Conduit.Web.Services.Users;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IMapper, Mapper>();
builder.Services.AddTransient<IArticleRepository, ArticleRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddTransient<IFavouriteArticleRepository, FavouriteArticleRepository>();
builder.Services.AddTransient<IFollowRepository, FollowRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddTransient<IRefreshTokenGeneratorRepository, RefreshTokenGeneratorRepository>();

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IFavouriteArticleService, FavouriteArticleService>();
builder.Services.AddTransient<IFollowService, FollowService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IRefreshTokenGeneratorService, RefreshTokenGeneratorService>();


builder.Services.AddDbContext<ConduitCoreDbContext>
    (options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ConduitDbContextConnection"]));


builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins", policy =>
{
    policy.WithOrigins("https://localhost:7248/").AllowAnyMethod().AllowAnyHeader();
}));



var _jwtSetting = builder.Configuration.GetSection("JWTSetting");
builder.Services.Configure<JWTSetting>(_jwtSetting);
var authkey = builder.Configuration.GetValue<string>("JWTSetting:securityKey");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = true;
    o.SaveToken = true;
    
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,        
    };
});



builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("ConduitOpenAPISpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Conduit API",
        Version = "1"
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();



app.UseCookiePolicy();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(setupAction =>
{
    setupAction.SwaggerEndpoint("/swagger/ConduitOpenAPISpecification/swagger.json", "Conduit API");
});

app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

//app.UseRouting();
app.MapRazorPages();

app.Run();