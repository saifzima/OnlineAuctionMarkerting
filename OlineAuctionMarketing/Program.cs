using EasyLearn.GateWays.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OlineAuctionMarketing.Context;
using OlineAuctionMarketing.Inplementation.Repository;
using OlineAuctionMarketing.Inplementation.Service;
using OlineAuctionMarketing.Interface.IRepository;
using OlineAuctionMarketing.Interface.IService;

namespace OlineAuctionMarketing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();
			string configuration = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql( configuration, ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));			
			builder.Services.AddScoped<IAuctioneerService, AuctioneerService>();
			builder.Services.AddScoped<IAuctioneerRepository, AuctioneerRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IAuctionBidderRepository, AuctionBidderRepository>();
			builder.Services.AddScoped<IBidderRepository, BidderRepository>();
			builder.Services.AddScoped<IBidderService, BidderService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
			builder.Services.AddScoped<IAuctionService, AuctionService>();
			builder.Services.AddScoped<IBidsRepository, BidsRepository>();
			builder.Services.AddScoped<IBidsService, BidsService >();
			builder.Services.AddScoped<ISendInBlueEmailService, SendInBlueEmailService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
			//builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
    {
        config.LoginPath = "/Home/Login";
        config.LogoutPath = "/Home/Login";
        config.Cookie.Name = "Auction";
    });
            builder.Services.AddAuthorization();


            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}"); 
			 app.Run();
		}
	}
}