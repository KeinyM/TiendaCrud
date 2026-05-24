using System;
using System.Collections.Generic;
using System.Text;
using TiendaCrud.App.Entities;
using TiendaCrud.App.Services;


namespace TiendaCrud.Tests
{
    public class ProductServiceTests
    {
        //CREATE

        [Fact]
        public void Create_ShouldAddProduct_WhenProductIsValid()
        {
            // Arrange
            var service = new ProductService();

            var product = new Product
            {
                Id = 1,
                Nombre = "Mouse",
                Descripcion = "Mouse Gamer",
                Precio = 100,
                Cantidad = 5
            };

            // Act
            service.Create(product);

            // Assert
            Assert.Single(service.GetAll());
        }

        [Fact]
        public void Create_ShouldThrowException_WhenIdAlreadyExists()
        {
            // Arrange
            var service = new ProductService();

            var product = new Product
            {
                Id = 1,
                Nombre = "Mouse",
                Descripcion = "Mouse Gamer",
                Precio = 100,
                Cantidad = 5
            };

            service.Create(product);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                service.Create(product);
            });
        }
        //------------------------------------------------------------------------------------------
        // READ
        

        [Fact]
        public void GetById_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var service = new ProductService();

            var product = new Product
            {
                Id = 1,
                Nombre = "Teclado",
                Descripcion = "Teclado Mecánico",
                Precio = 200,
                Cantidad = 3
            };

            service.Create(product);

            // Act
            var result = service.GetById(1);

            // Assert
            Assert.Equal("Teclado", result.Nombre);
        }

        [Fact]
        public void GetById_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Arrange
            var service = new ProductService();

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                service.GetById(99);
            });
        }

        // -------------------------------------------------------------------------------------
        // UPDATE
        

        [Fact]
        public void Update_ShouldModifyProduct_WhenProductExists()
        {
            // Arrange
            var service = new ProductService();

            var product = new Product
            {
                Id = 1,
                Nombre = "Monitor",
                Descripcion = "24 pulgadas",
                Precio = 500,
                Cantidad = 2
            };

            service.Create(product);

            var updatedProduct = new Product
            {
                Id = 1,
                Nombre = "Monitor Gamer",
                Descripcion = "27 pulgadas",
                Precio = 700,
                Cantidad = 4
            };

            // Act
            service.Update(updatedProduct);

            var result = service.GetById(1);

            // Assert
            Assert.Equal("Monitor Gamer", result.Nombre);
        }

        [Fact]
        public void Update_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Arrange
            var service = new ProductService();

            var product = new Product
            {
                Id = 99,
                Nombre = "No existe",
                Descripcion = "Error",
                Precio = 0,
                Cantidad = 0
            };

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                service.Update(product);
            });
        }

        // --------------------------------------------------------------------------------------
        // DELETE
       

        [Fact]
        public void Delete_ShouldRemoveProduct_WhenProductExists()
        {
            // Arrange
            var service = new ProductService();

            var product = new Product
            {
                Id = 1,
                Nombre = "Laptop",
                Descripcion = "Gaming",
                Precio = 3000,
                Cantidad = 1
            };

            service.Create(product);

            // Act
            service.Delete(1);

            // Assert
            Assert.Empty(service.GetAll());
        }

        [Fact]
        public void Delete_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Arrange
            var service = new ProductService();

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                service.Delete(99);
            });
        }
    }
}
