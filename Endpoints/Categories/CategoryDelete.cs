using Iwant.Domain.Products;
using Iwant.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Iwant.Endpoints.Categories;

public class CategoryDelete
{
    
    public static string Template => "/categories/{id}";
    public static string[] Methods =>  new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var category = context.Category.Where(c => c.Id == id).FirstOrDefault();
        context.Category.Remove(category);
        context.SaveChanges();
        return Results.Ok();
    }
}