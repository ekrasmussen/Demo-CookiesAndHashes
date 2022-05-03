using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/// <summary>
/// Add Authentication to the services, in the parameters we explain the authentication scheme we will use.
/// In this case we also use .AddCookie();, but you could also do something like .AddOAuth() if we wanted to use OAuth instead!
/// We can also add some options, which i do here for where login path is, but you can also specify the "Forbidden" page!
/// </summary>
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Home/Login";
    options.LogoutPath = "/Home/Logout";
    //options.AccessDeniedPath = "/MyOwnForbiddenPage";
});

//Dont forget to add MVC
builder.Services.AddMvc();

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

//..And then we also make sure that we add UseAuthentication to our middleware after adding the cookie Authentication
//KEEP IN MIND, The ordering of these methods are very sensitive, make sure you put them in the right places in relation to the default methods!
app.UseAuthentication();
app.UseAuthorization();

CookiePolicyOptions cpo = new CookiePolicyOptions
{
    //This defines the policy on how the cookie is used, SameSiteMode specifies the Cookie constraints
    //See https://docs.microsoft.com/en-us/dotnet/api/system.web.samesitemode?view=netframework-4.8

    MinimumSameSitePolicy = SameSiteMode.Lax,

    //Ill make the Cookie set to always be secure, CookieSecurePolicy is a enum
    //The different CookieSecurePolicy states can be found here https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.cookiesecurepolicy?view=aspnetcore-6.0
    Secure = CookieSecurePolicy.Always
};

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//Continue and have a look in the HomeController!
