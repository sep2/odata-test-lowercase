using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataTest;

var builder = WebApplication.CreateBuilder(args);

var mvcBuilder = builder.Services.AddControllers();
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EnableLowerCamelCase();

modelBuilder.EntitySet<Event>("Events");
modelBuilder.EntitySet<Activity>("Activities");

mvcBuilder.AddOData(options =>
    options
        .EnableQueryFeatures(100)
        .AddRouteComponents("api/odata", modelBuilder.GetEdmModel())
);

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.UseODataRouteDebug("$odata");
app.UseODataBatching();
app.UseODataQueryRequest();

app.Run();
