namespace Person.DTOs
{
    public record PersonRequest(string Name);

    public record PersonResponse(int Id, string Name);
}