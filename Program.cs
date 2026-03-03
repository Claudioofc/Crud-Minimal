using Person.Extensions;
using Person.Routes;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DE SERVIÇOS (DI) ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSecurity();       // Configuração do Swagger com Cadeado
builder.Services.AddJwtSecurity(builder.Configuration); // Configuração de Auth
builder.Services.AddDatabase();              // Injeção do PersonContext (Scoped)

var app = builder.Build();

// --- 2. PIPELINE DE REQUISIÇÃO (MIDDLEWARES) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

// --- 3. MAPEAMENTO DE ROTAS ---
app.AuthRoutes();   // Rota de Login (/login)
app.PersonRoutes(); // Rotas de CRUD (/person)

app.Run();