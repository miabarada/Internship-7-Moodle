using Application.Admin.DeletelUser;
using Application.Admin.GetUserById;
using Application.Authorization.LoginUser;
using Application.Authorization.RegisterUser;
using Application.PrivateMessages.GetChat;
using Application.PrivateMessages.GetUserChats;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Actions;
using Presentation.Views;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); 

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<LoginUserRequestHandler>();
builder.Services.AddScoped<RegisterUserRequestHandler>();
builder.Services.AddScoped<GetUserByIdRequestHandler>();
builder.Services.AddScoped<DeleteUserRequestHandler>();
builder.Services.AddScoped<GetChatRequestHandler>();
builder.Services.AddScoped<GetUserChatsRequestHandler>();

builder.Services.AddScoped<UserActions>(); 
builder.Services.AddScoped<MainMenu>(); 

var host = builder.Build(); 
using (var scope = host.Services.CreateScope()) 
{ 
    var mainMenu = scope.ServiceProvider.GetRequiredService<MainMenu>(); 
    await mainMenu.RunAsync(); 
}
