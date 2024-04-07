using BankApplication.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseControllerConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.UseSwaggerConfiguration();

builder.Services.UseAutoMapperConfiguration();

builder.Services.UseDbContextConfiguration(builder);

builder.Services.UseDepencyInjectionConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
