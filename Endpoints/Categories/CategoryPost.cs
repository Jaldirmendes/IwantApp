using Iwant.Domain.Products;
using Iwant.Infra.Data;

namespace Iwant.Endpoints.Categories;

public class CategoryPost
{
    
    public static string Template => "/categories";
    public static string[] Methods =>  new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(CategoryRequest request, ApplicationDbContext context)
    {
        var category = new Category(request.Name, "teste", "teste");

        if (!category.IsValid)
        {
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        }

        context.Category.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}