namespace Person.DTOs
{
    // O que o usuário envia (Input)
    public record PersonRequest(string Name);

    // O que a API devolve (Output) - Note que não devolvemos o 'IsDeleted'
    public record PersonResponse(Guid Id, string Name);
}