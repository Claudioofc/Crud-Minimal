namespace Person.Routes.Models
{
    public class PersonModel
    {
        public PersonModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsDeleted = false;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } // Flag do Soft Delete

        public void ChangeName(string name) => Name = name;

        // Método para facilitar a ativação/desativação
        public void SetDeleted(bool status) => IsDeleted = status;
    }
}