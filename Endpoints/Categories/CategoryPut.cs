using Iwant.Domain.Products;
using Iwant.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Iwant.Endpoints.Categories;

public class CategoryPut
{
    
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods =>  new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, CategoryRequest request, ApplicationDbContext context)
    {
        var category = context.Category.Where(c => c.Id == id).FirstOrDefault();

        if (category == null)
            return Results.NotFound();
        
        category.editInfo(request.Name, request.Active);

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());
        context.SaveChanges();

        return Results.Ok();
    }
}