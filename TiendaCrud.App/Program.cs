using TiendaCrud.App.Entities;
using TiendaCrud.App.Services;

var service = new ProductService();

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n===== CRUD PRODUCTOS =====");
    Console.WriteLine("1. Crear producto");
    Console.WriteLine("2. Listar productos(MOSTRAR TODOS LOS PRODUCTOS)");
    Console.WriteLine("3. Buscar producto");
    Console.WriteLine("4. Actualizar producto");
    Console.WriteLine("5. Eliminar producto");
    Console.WriteLine("6. Salir");

    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    try
    {
        switch (opcion)
        {
            case "1":

                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine()!;

                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine()!;

                Console.Write("Precio: ");
                decimal precio = decimal.Parse(Console.ReadLine()!);

                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine()!);

                service.Create(new Product
                {
                    Id = id,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio,
                    Cantidad = cantidad
                });

                Console.WriteLine("Producto agregado.");
                break;

            case "2":

                var products = service.GetAll();

                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Id} - {p.Nombre} - ${p.Precio} - Stock: {p.Cantidad}");
                }

                break;

            case "3":

                Console.Write("Ingrese ID: ");
                int searchId = int.Parse(Console.ReadLine()!);

                var product = service.GetById(searchId);

                Console.WriteLine($"{product.Nombre} - {product.Descripcion}");
                break;

            case "4":

                Console.Write("ID del producto: ");
                int updateId = int.Parse(Console.ReadLine()!);

                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine()!;

                Console.Write("Nueva descripción: ");
                string nuevaDescripcion = Console.ReadLine()!;

                Console.Write("Nuevo precio: ");
                decimal nuevoPrecio = decimal.Parse(Console.ReadLine()!);

                Console.Write("Nueva cantidad: ");
                int nuevaCantidad = int.Parse(Console.ReadLine()!);

                service.Update(new Product
                {
                    Id = updateId,
                    Nombre = nuevoNombre,
                    Descripcion = nuevaDescripcion,
                    Precio = nuevoPrecio,
                    Cantidad = nuevaCantidad
                });

                Console.WriteLine("Producto actualizado.");
                break;

            case "5":

                Console.Write("ID a eliminar: ");
                int deleteId = int.Parse(Console.ReadLine()!);

                service.Delete(deleteId);

                Console.WriteLine("Producto eliminado.");
                break;

            case "6":

                salir = true;
                break;

            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
