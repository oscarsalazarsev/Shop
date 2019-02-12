using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext context;
        private Random random;

        public SeedDB(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X");
                this.AddProduct("iPhone 8");
                this.AddProduct("iPhone SX");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string productName)
        {
            this.context.Products.Add(new Product
            {
                Name = productName,
                Price = this.random.Next(100),
                IsAvailable = true,
                Stock = this.random.Next(100),
            });
        }
    }
}
