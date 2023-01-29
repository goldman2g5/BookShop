using Microsoft.EntityFrameworkCore;
using KebabPiercingApi.Data;
using KebabPiercingApi.Models;

namespace BookShop.Server.EndPoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Book", async (ApiContext db) =>
        {
            return await db.Book.ToListAsync();
        })
        .WithName("GetAllBooks")
        .Produces<List<Book>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Book/{id}", async (int Id, ApiContext db) =>
        {
            return await db.Book.FindAsync(Id)
                is Book model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetBookById")
        .Produces<Book>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Book/{id}", async (int Id, Book book, ApiContext db) =>
        {
            var foundModel = await db.Book.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(book);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateBook")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Book/", async (Book book, ApiContext db) =>
        {
            db.Book.Add(book);
            await db.SaveChangesAsync();
            return Results.Created($"/Books/{book.Id}", book);
        })
        .WithName("CreateBook")
        .Produces<Book>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Book/{id}", async (int Id, ApiContext db) =>
        {
            if (await db.Book.FindAsync(Id) is Book book)
            {
                db.Book.Remove(book);
                await db.SaveChangesAsync();
                return Results.Ok(book);
            }

            return Results.NotFound();
        })
        .WithName("DeleteBook")
        .Produces<Book>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
