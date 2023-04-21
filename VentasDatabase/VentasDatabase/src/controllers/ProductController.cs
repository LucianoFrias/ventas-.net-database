using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasDatabase.src.entities;
using VentasDatabase.src.repositories;

namespace VentasDatabase.src.controllers
{
    internal class ProductController
    {
        public ProductRepository ProductRepository { get; set; }
        public ProductController(ProductRepository productRepository) 
        { ProductRepository = productRepository; }

        public List<Product> getAllProducts()
        {
            return ProductRepository.getAllProducts();
        }

        public List<Product> getProductsByCategory(string categoryName)
        {
            return ProductRepository.getProductsByCategory(categoryName);
        }

        public List<Product> getProductsByName(string name)
        { 
            return ProductRepository.getProductsByName(name);
        }

        public Product getProductById(int id) 
        { 
            return ProductRepository.getProductById(id);
        }

        public void addProduct(Product product)
        {
            ProductRepository.addProduct(product);
        }

        public void updateProduct(Product product) 
        {
            ProductRepository.updateProduct(product);
        }

        public void deleteProductById(int id)
        { 
            ProductRepository.deleteProductById(id);
        }
    }
}
