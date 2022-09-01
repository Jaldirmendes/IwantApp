using Flunt.Validations;

namespace  Iwant.Domain.Products;


public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Category>()
                    .IsNotNullOrEmpty(Name, "Name")
                    .IsGreaterOrEqualsThan(Name, 3, "Name")
                    .IsNotNullOrEmpty(EditedBy, "EditedBy")
                    .IsNotNullOrEmpty(CreatedBy, "CreatedBy");
        AddNotifications(contract);
    }

    public void editInfo(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate();
    }
}
