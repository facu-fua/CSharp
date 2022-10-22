using _1er_entrega_proyecto_final.Modelos;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {

        //Creo los objetos

        //Switch para pseudo-front
        string letra = "";
        Console.WriteLine("Seleccione una de las siguientes opciones:");
        Console.WriteLine("A)");
        Console.WriteLine("B)");
        Console.WriteLine("C)");
        Console.WriteLine("E)");
        Console.WriteLine("D)");
        Console.WriteLine("F) Salir");



        while(letra!="f")
        {
            switch (letra)
            {
                case "a":
                    Console.WriteLine("Hola A");

                    break;

                case "b":
                    Console.WriteLine("Hola B");

                    break;

                case "c":
                    Console.WriteLine("Hola C");

                    break;

                case "d":
                    Console.WriteLine("Hola D");

                    break;

                case "e":
                    Console.WriteLine("Hola E");

                    break;

                default:
                    Console.WriteLine("Error: Ingrese una de las opciones presentadas");
                    break;
            }
        }
        
    }
}
