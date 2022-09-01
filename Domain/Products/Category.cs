using Flunt.Validations;

namespace  Iwant.Domain.Products;


public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createdBy, string editedBy)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name")
            .IsGreaterOrEqualsThan(name, 3, "Name")
            .IsNotNullOrEmpty(editedBy, "EditedBy")
            .IsNotNullOrEmpty(createdBy, "CreatedBy");
        AddNotifications(contract);

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
    }
}
