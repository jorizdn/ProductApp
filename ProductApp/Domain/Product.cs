using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductApp.Exceptions;

namespace ProductApp.Domain
{
    public class Product
    {
        public bool IsSold { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            Name = Name ??
                   throw new NameRequiredException();
        }

    }

    public class Products
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> Items => _products.Where(t => !t.IsSold);

        public void AddNew(Product product)
        {
            product = product ??
                      throw new ArgumentNullException();
            product.Validate();
            _products.Add(product);
        }

        public void Sold(Product product)
        {
            product.IsSold = true;
        }

    }
}
