using CustomerControl.Data;
using CustomerControl.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerControl.Routes;

public static class CostumerRoutes  
{
    public static void CostumerRoutesConstructor(this WebApplication app)
    {
        var route = app.MapGroup("costumer");

        route.MapPost("", 
            async (CostumerRequest req, CostumerContext context) =>
        {
            var person = new CostumerModel(req.name, req.address, req.nugget);
            await context.AddAsync(person);
            await context.SaveChangesAsync();
        });
        route.MapGet("", async (CostumerContext context) =>
        {
            var people = await context.Peolpe.ToListAsync();
            return Results.Ok(people);
        });

        route.MapPut("{id:guid}", 
            async (Guid id, CostumerRequest req, CostumerContext context) =>
        {
            var person = await context.Peolpe.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
                return Results.NotFound();
            person.ChangePerson(req.name, req.address, req.phone);
            await context.SaveChangesAsync();
            
            return Results.Ok(person);
        });
        route.MapDelete("{id:guid}",
            async (Guid id, CostumerContext context) =>
            {
                var person = await context.Peolpe.FirstOrDefaultAsync(person => person.Id == id);
                
                if (person == null)
                    return Results.NotFound();
                
                //person.SetInactive();
                context.Remove(person);
                await context.SaveChangesAsync();
                return Results.Ok(person);
            });
    }
}