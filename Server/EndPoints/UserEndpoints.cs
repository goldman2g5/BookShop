﻿using BookShop.Server.Models;
using KebabPiercingApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Server
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/User", async (ApiContext db) =>
            {
                return await db.User.ToListAsync();
            })
            .WithName("GetAllUsers")
            .Produces<List<User>>(StatusCodes.Status200OK);

            routes.MapGet("/api/User/{id}", async (int Id, ApiContext db) =>
            {
                return await db.User.FindAsync(Id)
                    is User model
                        ? Results.Ok(model)
                        : Results.NotFound();
            })
            .WithName("GetUserById")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapPut("/api/User/{id}", async (int Id, User user, ApiContext db) =>
            {
                var foundModel = await db.User.FindAsync(Id);

                if (foundModel is null)
                {
                    return Results.NotFound();
                }

                db.Update(user);

                await db.SaveChangesAsync();

                return Results.NoContent();
            })
            .WithName("UpdateUser")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status204NoContent);

            routes.MapPost("/api/User/", async (User user, ApiContext db) =>
            {
                db.User.Add(user);
                await db.SaveChangesAsync();
                return Results.Created($"/Users/{user.Id}", user);
            })
            .WithName("CreateUser")
            .Produces<User>(StatusCodes.Status201Created);


            routes.MapDelete("/api/User/{id}", async (int Id, ApiContext db) =>
            {
                if (await db.User.FindAsync(Id) is User user)
                {
                    db.User.Remove(user);
                    await db.SaveChangesAsync();
                    return Results.Ok(user);
                }

                return Results.NotFound();
            })
            .WithName("DeleteUser")
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
