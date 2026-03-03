namespace Person.Routes.Models;

public class PersonModel
{
    public PersonModel(string name)
    {
        
        Name = name;
        IsDeleted = false;
    }

    public int Id { get; private set; } 
    public string Name { get; private set; }
    public bool IsDeleted { get; private set; }

    public void ChangeName(string name) => Name = name;
    public void SetDeleted(bool status) => IsDeleted = status;
}