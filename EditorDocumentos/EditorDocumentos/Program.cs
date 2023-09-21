using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EditorDocumentos
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Por favor, ingrese el nombre del archivo:");
            string nombreArchivo = Console.ReadLine();

            Console.WriteLine("Por favor, ingrese el contenido del archivo:");
            string contenido = Console.ReadLine();

            // Crear el archivo y escribir el contenido en él
            try
            {
                using (StreamWriter sw = File.CreateText(nombreArchivo))
                {
                    sw.WriteLine(contenido);
                }

                Console.WriteLine($"Archivo '{nombreArchivo}' creado y contenido escrito con éxito.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al crear o escribir en el archivo: " + e.Message);
            }

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("¿Qué desea hacer? (editar, mostrar o finalizar):");
                string opcion = Console.ReadLine().ToLower();

                switch (opcion)
                {
                    case "editar":
                        Console.WriteLine("Por favor, ingrese el texto adicional:");
                        string textoAdicional = Console.ReadLine();
                        try
                        {
                            using (StreamWriter sw = File.AppendText(nombreArchivo))
                            {
                                sw.WriteLine(textoAdicional);
                            }
                            Console.WriteLine("Texto agregado con éxito.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ocurrió un error al editar el archivo: " + e.Message);
                        }
                        break;
                    case "mostrar":
                        try
                        {
                            using (StreamReader sr = new StreamReader(nombreArchivo))
                            {
                                string linea;
                                Console.WriteLine($"Contenido del archivo '{nombreArchivo}':");
                                while ((linea = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(linea);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ocurrió un error al leer el archivo: " + e.Message);
                        }
                        break;
                    case "finalizar":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija editar, mostrar o finalizar.");
                        break;
                }
            }
        }
    }

}
