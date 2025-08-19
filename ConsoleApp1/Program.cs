using System;
using System.IO;

using System.Text.Json;
using System.Collections.Generic;
namespace MiPrimeraApp
{

    class TaskTracker
    {

        static void Main(string[] args)
        {
            // Escribe una línea de texto en la consola.
            Console.WriteLine("{0,-20} {1,-5}","","BIENVENIDO A TU ORGANIZADOR DE TAREAS!");
            Console.WriteLine("\n");

            TaskOption task1 = new TaskOption("","" );

            List<TaskOption> tasksList = new List<TaskOption>();
                       

            
           
            
            foreach (var task in tasksList)
            {
                Console.WriteLine("{0,-20} {1,-30} {2,-10} {3,-20}", "ID", "Descripcion", "Creada:", "Estado");
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("{0,-10} {1,-8}", $"{task1.Id}", $"{task}", $"{task1.CreatedAt} creada en,", " actualizada en ", $"{task1.Estado}");
            }


             

            
             
             Console.ReadLine();

        }
    }
}
