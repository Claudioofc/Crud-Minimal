using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Routes.Models;

namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var route = app.MapGroup("person");

            route.MapPost("",
                async (PersonRequest req, PersonContext context) =>
            {
                var person = new PersonModel(req.Name);
                await context.AddAsync(person);
                await context.SaveChangesAsync();
            });

            route.MapGet(pattern: "", async (PersonContext context) =>
            {
                var people = await context.People
                                          .Where(x => !x.IsDeleted)
                                          .ToListAsync();
                return Results.Ok(people);
            });

            route.MapPut(pattern: "{id:guid}",
                async (Guid id, PersonRequest req, PersonContext context) =>
            {
                var person = await context.People.FindAsync(id);
                if (person is null)
                    return Results.NotFound();

                person.ChangeName(req.Name);
                await context.SaveChangesAsync();

                return Results.Ok(person);

            });

            // ADICIONADO DELETE PARA MARCAR COMO EXCLUIDO, EM VEZ DE REMOVER DO BANCO
            route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
            {
                var person = await context.People.FindAsync(id);

                if (person is null || person.IsDeleted)
                    return Results.NotFound();

                person.IsDeleted = true;

                await context.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
