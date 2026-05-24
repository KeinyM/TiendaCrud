using System;
using System.Collections.Generic;
using System.Text;
using TiendaCrud.App.Entities;

namespace TiendaCrud.App.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();

        // CREATE
        public void Create(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                throw new InvalidOperationException("El ID ya existe.");
            }

            _products.Add(product);
        }

        // READ ALL
        public List<Product> GetAll()
        {
            return _products;
        }

        //GET BY ID
        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            return product;
        }

        // UPDATE
        public void Update(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            product.Nombre = updatedProduct.Nombre;
            product.Descripcion = updatedProduct.Descripcion;
            product.Precio = updatedProduct.Precio;
            product.Cantidad = updatedProduct.Cantidad;
        }

        // DELETE
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException("Producto no encontrado.");
            }

            _products.Remove(product);
        }
    }
}
