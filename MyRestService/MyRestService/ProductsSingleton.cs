using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestService
{
    public partial class ProductsSingleton
    {
        private static readonly ProductsSingleton _instance = new ProductsSingleton();

        private ProductsSingleton() { }

        public static ProductsSingleton Instance
        {
            get { return _instance; }
        }

        public List<Products> ProductList
        {
            get { return products; }
        }

        private List<Products> products = new List<Products>()
        {
            new Products() {ProductId = 1, Name = "prudct 1", CategoryName = "category 1", Price = 10},
            new Products() {ProductId = 2, Name = "prudct 2", CategoryName = "category 2", Price = 15},
            new Products() {ProductId = 3, Name = "prudct 3", CategoryName = "category 3", Price = 20},
            new Products() {ProductId = 4, Name = "prudct 4", CategoryName = "category 4", Price = 25}
        };
    }
}