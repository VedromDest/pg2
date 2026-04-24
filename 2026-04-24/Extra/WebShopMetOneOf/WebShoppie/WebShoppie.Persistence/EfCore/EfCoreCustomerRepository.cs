using Microsoft.EntityFrameworkCore;
using WebShoppie.DataModel;
using WebShoppie.Domain.Model;
using WebShoppie.Persistence.Exceptions;
using WebShoppie.Persistence.Interfaces;
using WebShoppie.Persistence.Mapping;

namespace WebShoppie.Persistence.EFCore;

public class EfCoreCustomerRepository(WebShoppieDbContext dbContext) : ICustomerRepository
{
    public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customerModelToCreate)
    {
        
        var entity = customerModelToCreate.AsEntity();
        dbContext.Customers.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.AsModel();
    }

    public async Task<CustomerModel?> GetCustomerByIdAsync(int id)
    {
        var entity = await dbContext.Customers.FindAsync((long)id);
        return entity?.AsModel();
    }

    public async Task<List<CustomerModel>> GetAllCustomersAsync()
    {
        return await dbContext.Customers.Select(c => c.AsModel()).ToListAsync();
    }

    public async Task UpdateCustomerAsync(CustomerModel customerModelToUpdate)
    {
        var existingEntity = await dbContext.Customers.FindAsync((long)customerModelToUpdate.CustomerId!);
        if(existingEntity is null)
            throw new OmgCustomerDoesNotExistInDbException($"Customer with Id {customerModelToUpdate.CustomerId} does not exist!");
        
        var toUpdate = customerModelToUpdate.AsEntity();
        // SetValues() - kopieert alle waarden van object naar bestaande entity die al getracked wordt
        // Update() - kopieert alle waarden van object naar entity die nog niet getracked wordt
        // entity.prop = dto.prop - zet manueel waarden op een entity die al getracked wordt, geen expliciet Update() of SetValues() nodig
        // --> In alle gevallen SaveChanges() nodig.
        dbContext.Entry(existingEntity).CurrentValues.SetValues(toUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var entity = await dbContext.Customers.FindAsync((long)id);
        if (entity != null)
        {
            dbContext.Customers.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}