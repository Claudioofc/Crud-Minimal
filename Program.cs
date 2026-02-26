using Person.Data;
using Person.Routes;

var builder = WebApplication.CreateBuilder(args);

// Swagger/ OpenAPI
builder.Services.AddEndpointsApiExplorer(); // Explora endpoints da minimal API
builder.Services.AddSwaggerGen();           // Gera documentação Swagger
builder.Services.AddScoped<PersonContext>(); // Registra o contexto do Entity Framework para injeção de dependência

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // Gera o JSON do Swagger
    app.UseSwaggerUI();    // Exibe interface web do Swagger
}

app.PersonRoutes(); // Configura as rotas para "Person"


app.UseHttpsRedirection();

app.Run();
