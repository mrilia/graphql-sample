using GraphQL;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Simple.GraphQL.Backend.Contracts;
using Simple.GraphQL.Backend.GraphQL.GraphQLSchema;
using Simple.GraphQL.Backend.Models.Context;
using Simple.GraphQL.Backend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
builder.Services.AddSingleton<DataLoaderDocumentListener>();

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<ISchema, AppSchema>(services => new AppSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(options =>
                    options.ConfigureExecution((opt, next) =>
                    {
                        opt.EnableMetrics = true;
                        return next(opt);
                    })
                    .AddSystemTextJson()
                    .AddDataLoader()
                );

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policyBuilder =>
        {
            policyBuilder.WithOrigins("*")
                   .AllowAnyHeader();
        });
});

//builder.Services.AddControllers();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "SimpleGraphQL", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleGraphQL v1"));
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseCors();

//app.UseAuthorization();

//app.MapControllers();

app.UseGraphQL();
app.UseGraphQLPlayground();

app.Run();
