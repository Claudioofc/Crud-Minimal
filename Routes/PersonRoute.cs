using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Routes.Models;
using Person.DTOs;

namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var route = app.MapGroup("person");

            // POST: Criar
            route.MapPost("", async (PersonRequest req, PersonContext context) =>
            {
                if (string.IsNullOrWhiteSpace(req.Name))
                    return Results.BadRequest("O nome é obrigatório.");

                var person = new PersonModel(req.Name);
                await context.AddAsync(person);
                await context.SaveChangesAsync();

                var response = new PersonResponse(person.Id, person.Name);
                return Results.Created($"/person/{person.Id}", response);
            }).RequireAuthorization();

            // GET: Listar Ativos
            route.MapGet("", async (PersonContext context) =>
            {
                var people = await context.People
                    .Where(x => !x.IsDeleted)
                    .Select(p => new PersonResponse(p.Id, p.Name))
                    .ToListAsync();

                return Results.Ok(people);
            }).RequireAuthorization();

            // PUT: Atualizar
            route.MapPut("{id:guid}", async (Guid id, PersonRequest req, PersonContext context) =>
            {
                var person = await context.People.FindAsync(id);

                if (person is null || person.IsDeleted)
                    return Results.NotFound();

                person.ChangeName(req.Name);
                await context.SaveChangesAsync();

                return Results.Ok(new PersonResponse(person.Id, person.Name));
            }).RequireAuthorization();

            // DELETE: Soft Delete
            route.MapDelete("{id:guid}", async (Guid id, PersonContext context) =>
            {
                var person = await context.People.FindAsync(id);

                if (person is null || person.IsDeleted)
                    return Results.NotFound();

                person.SetDeleted(true);
                await context.SaveChangesAsync();

                return Results.NoContent();
            }).RequireAuthorization();
        }
    }
}