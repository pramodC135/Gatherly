using Gatherly.App.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

/*app.Use( async (context, next) => 
{
    try
    {
        await next(context);
    }
    catch
    {
        context.Response.StatusCode = 500;
    }
});*/

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
