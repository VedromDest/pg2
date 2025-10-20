using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Singleton - Wordt gemaakt en gebruikt zolang de app runt.
builder.Services.AddSingleton<MijnGuidWrapperSingleton>();
// Scoped - Wordt gemaakt en gebruikt zolang het request loopt.
builder.Services.AddScoped<MijnGuidWrapperScoped>();
// Transient - Wordt gemaakt en gebruikt voor elke injectie.
builder.Services.AddTransient<MijnGuidWrapperTransient>();

var app = builder.Build();

app.MapGet("/", (
        // Injectie singleton 
        [FromServices] MijnGuidWrapperSingleton singleton,
        // Injectie van 2 scoped objecten
        [FromServices] MijnGuidWrapperScoped scoped1,
        [FromServices] MijnGuidWrapperScoped scoped2,
        // Injectie van 2 transient objecten
        [FromServices] MijnGuidWrapperTransient transient1,
        [FromServices] MijnGuidWrapperTransient transient2
    ) => new
{
    // Waarde zal in elke response dezelfde zijn zolang app runt
    singleton = singleton.Guid,
    // Waarde zal verschillend zijn in elke response, maar gelijk voor de 2 injecties in deze request
    scoped1 = scoped1.Guid,
    scoped2 = scoped2.Guid,
    // Waarde zal verschillend zijn voor elke injectie
    transient1 = transient1.Guid,
    transient2 = transient2.Guid
});

app.Run();

// Een zeer eenvoudige set klassen die zullen dienen als injectie types.
public class MijnGuidWrapper
{
    public Guid Guid { get; } = Guid.NewGuid();
}

public class MijnGuidWrapperSingleton : MijnGuidWrapper; 
public class MijnGuidWrapperScoped : MijnGuidWrapper;
public class MijnGuidWrapperTransient: MijnGuidWrapper;