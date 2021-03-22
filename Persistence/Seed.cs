using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.BatchStatus.Any())
            {
                var batchStatus = new List<BatchStatus>() {
                    
                    new BatchStatus() {
                        Status = "InProcess",
                        IsActive = true
                    },
                    new BatchStatus() {
                        Status = "Complete",
                        IsActive = true
                    },
                    new BatchStatus() {
                        Status = "InComplete",
                        IsActive = true
                    },
                    new BatchStatus() {
                        Status = "Abort",
                        IsActive = true
                    }
                };
                await context.BatchStatus.AddRangeAsync(batchStatus);
                await context.SaveChangesAsync();
            }
            if (!context.BusinessUnities.Any())
            {
                var businessUnities = new List<BusinessUnit>() {
                    new BusinessUnit() {
                        BusinessUnitName = "Demo0 BU",
                        IsActive = true
                    },
                    new BusinessUnit() {
                        BusinessUnitName = "Demo1 BU",
                        IsActive = true
                    },
                    new BusinessUnit() {
                        BusinessUnitName = "Demo2 BU",
                        IsActive = true
                    }
                };
                await context.BusinessUnities.AddRangeAsync(businessUnities);
                await context.SaveChangesAsync();
            }
        }
    }
}