using AutoMapper;
using Conduit.Db;
using Conduit.Db.Interfaces;
using Conduit.Db.Repositories;
using Conduit.Web.Interfaces;
using Conduit.Web.Services;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IFavouriteArticleService, FavouriteArticleService>();
builder.Services.AddTransient<IFollowService, FollowService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddDbContext<ConduitCoreDbContext>
    (options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ConduitDbContextConnection"]));


builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins", policy =>
{
    policy.WithOrigins("https://localhost:7248/").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


app.UseCookiePolicy();

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

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