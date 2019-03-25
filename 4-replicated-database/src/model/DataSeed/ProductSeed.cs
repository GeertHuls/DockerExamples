using System;
using System.Collections.Generic;
using Store.Entities;

namespace Store.Model.DataSeed
{
    public static class ProductSeed
    {
        private static Random _Random = new Random();

        public static IEnumerable<Product> GetSeedData()
        {
            var products = new List<Product>();
            for (int i=1; i< 20; i++)
            {
                products.Add(GenerateProduct(i));
            }
            return products;
        }

        private static Product GenerateProduct(int id)
        {
            return new Product
            {
                Id = id,
                Name = Guid.NewGuid().ToString().Substring(0, 12),
                Price = Math.Round(_Random.NextDouble() * 1000 + _Random.NextDouble() * 100 + _Random.NextDouble(), 2),
                Stock = _Random.Next(20000)
            };
        }
    }
}
