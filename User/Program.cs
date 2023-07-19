using Users.Services;
using Users.Swagger;
using static Users.Protos.Token;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpcClient<TokenClient>(o =>
{
    o.Address = new Uri(builder.Configuration["GRPC_SERVER_ADDRESS"]);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

builder.Services.AddCustomAuthentication();

builder.Services.AddCustomApplicationServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndUI();
    app.UseDeveloperExceptionPage();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
