using _1er_entrega_proyecto_final.Controles;
using _1er_entrega_proyecto_final.Modelos;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        //Switch para pseudo-front
        string letra="";

        while (letra!="F")
        {
            
            Console.WriteLine("\nSeleccione una de las siguientes opciones:");
            Console.WriteLine("A) Traer Usuario por nombre");
            Console.WriteLine("B) Traer Producto por usuario");
            Console.WriteLine("C) Traer Productos Vendidos por usuario");
            Console.WriteLine("D) Traer Ventas por usuario");
            Console.WriteLine("E) Iniciar Sesion");
            Console.WriteLine("F) Salir\n");

            letra = Console.ReadLine().ToUpper();
            string nombreUsuario;
            int idUsuario;
            string password;


            switch (letra)
            {
                case "A":
                    Console.WriteLine("\nIngrese el Nombre de usuario");
                    nombreUsuario = Console.ReadLine();
                    Usuario user = UsuarioController.TraerUsuario(nombreUsuario);
                    if (user.Id == 0)
                    {
                        Console.Write("\nUsuario no existe!\n");
                    }
                    else
                    {
                        Console.WriteLine("\n-------Usuario-------");
                        Console.WriteLine("Id: " + user.Id);
                        Console.WriteLine("Nombre: " + user.Nombre);
                        Console.WriteLine("Apelldio: " + user.Apellido);
                        Console.WriteLine("Nombre de Usuario: " + user.NombreUsuario);
                        Console.WriteLine("Contraseña: " + user.Password);
                        Console.WriteLine("Email: " + user.Mail + "\n");
                    }
                    break;

                case "B":
                    Console.WriteLine("\nIngrese el id del Usuario");
                    idUsuario = int.Parse(Console.ReadLine());
                    List<Producto> productos = ProductoController.TraerProducto(idUsuario);
                    if (productos.Count == 0)
                    {
                        Console.Write("\nEl Usuario no existe o no cargo productos al sistema\n");
                    }
                    else
                    {
                        Console.WriteLine("\n-------PRODUCTOS-------\n");
                        foreach (Producto producto in productos)
                        {
                            Console.WriteLine("Id: " + producto.Id);
                            Console.WriteLine("Descripcion: " + producto.Descripciones);
                            Console.WriteLine("Costo: " + producto.Costo);
                            Console.WriteLine("Precio de venta: " + producto.PrecioVenta);
                            Console.WriteLine("Stock: " + producto.Stock);
                            Console.WriteLine("Id del Usuario: " + producto.IdUsuario);
                            Console.WriteLine("-------------------------------------\n");
                        }

                    }
                    break;

                case "C":
                    Console.WriteLine("\nIngrese el id de Usuario:");
                    idUsuario = int.Parse(Console.ReadLine());
                    List<ProductoVenta> vendidos = ProductoVendidoController.TraerProductoVendido(idUsuario);
                    if (vendidos.Count == 0)
                    {
                        Console.WriteLine("\nUsuario no existe o no ha vendido productos\n");
                    }
                    else
                    {
                        Console.WriteLine("\n-------PRODUCTOS VENDIDOS DEL USUARIO -------\n");
                        foreach (ProductoVenta productoVenta in vendidos)
                        {
                            Console.WriteLine("Id: " + productoVenta.Id);
                            Console.WriteLine("Stock: " + productoVenta.Stock);
                            Console.WriteLine("IdProducto: " + productoVenta.IdProducto);
                            Console.WriteLine("IdVenta: " + productoVenta.IdVenta);
                            Console.WriteLine("-------------------------------------\n ");
                        }

                    }
                    break;

                case "D":
                    Console.WriteLine("\nIngrese el id del usuario:");
                    idUsuario = int.Parse(Console.ReadLine());
                    List<Venta> ventas = VentaController.Ventas(idUsuario);
                    if (ventas.Count == 0)
                    {
                        Console.WriteLine("\nEl Id de usuario no existe o no tiene ventas!\n");
                    }
                    else
                    {
                        Console.WriteLine("\n-------VENTAS-------\n");
                        foreach (Venta venta in ventas)
                        {
                            Console.WriteLine("Id: " + venta.Id);
                            Console.WriteLine("Comentarios: " + venta.Comentarios);
                            Console.WriteLine("IdUsuario: " + venta.IdUsuario);
                            Console.WriteLine("-------------------------------------\n");
                        }
                    }
                    break;

                case "E":
                    Console.WriteLine("\nIngrese el Nombre de usuario");
                    nombreUsuario = Console.ReadLine();
                    Console.WriteLine("\nIngrese la contraseña");
                    password = Console.ReadLine();
                    Usuario usuario = UsuarioController.Login(nombreUsuario, password);
                    if (usuario.Id != 0)
                    {
                        Console.WriteLine("\nLog in realizado con exito!\n");
                        Console.WriteLine("Id: " + usuario.Id);
                        Console.WriteLine("Nombre: " + usuario.Nombre);
                        Console.WriteLine("Apellido: " + usuario.Apellido);
                        Console.WriteLine("NombreUsuario: " + usuario.NombreUsuario);
                        Console.WriteLine("Password: " + usuario.Password);
                        Console.WriteLine("Email: " + usuario.Mail + "\n");
                    }
                    else
                    {
                        Console.WriteLine("\nUsuario no existe");
                        Console.WriteLine("Id: " + 0);
                        Console.WriteLine("Nombre:");
                        Console.WriteLine("Apellido:");
                        Console.WriteLine("NombreUsuario:");
                        Console.WriteLine("Password:");
                        Console.WriteLine("Email:\n");
                    }

                    break;

                case "F":
                    Console.WriteLine("\nHasta luego!");

                    break;

                default:
                    Console.WriteLine("\nError: Ingrese una de las opciones presentadas\n");
                    break;
            }
        }
        
    }
}
