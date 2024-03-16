using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_demo.DAL
{
    public class ProductsRepository
    {
        private readonly VendingMachineContext _machineContext;

        public ProductsRepository(VendingMachineContext machineContext)
        {
            _machineContext = machineContext;
        }

        public async  Task<IEnumerable<Product>> SearchProductsAsync(decimal? minPrice, decimal? maxPrice, string manufacturer, string productType, int pageNumber, int pageSize) 
        {
            IQueryable<Product> query = _machineContext.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductType);

            if (minPrice.HasValue)
            {
                query = query.Where(x => x.Price > minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(x => x.Price < maxPrice);
            }

            if(!string.IsNullOrEmpty(manufacturer)) 
            {
                query = query.Where(x => x.Manufacturer.Name == manufacturer);
            }

            if (!string.IsNullOrEmpty(productType))
            {
                query = query.Where(x => x.ProductType.Name == productType);
            }

            query = query.OrderBy(x => x.Price);

            query = query.Skip(pageSize * pageNumber).Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
