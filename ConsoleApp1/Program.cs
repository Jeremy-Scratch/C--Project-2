using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Dynamic;

namespace MiPrimeraApp
{

   public class TaskTracker
    {

        static void Main(string[] args)
        {                 

            Console.WriteLine("{0,-20} {1,-5}","","BIENVENIDO A TU ORGANIZADOR DE TAREAS!");
            Console.WriteLine("\n");
            DateTime hora = DateTime.Now;

            TaskOption task1 = new TaskOption();

            

            Console.WriteLine("\nElija una tarea a realizar...\n\n 1. Agregar nueva tarea.\n 2. Actualizar tarea.\n 3. Eliminar tarea.\n 4. Marcar como completada / en progreso.\n 5. Mostrar todas las tareas.\n 6. Mostrar las tareas completadas.\n 7. Mostrar las tareas incompletas\n" );

            int ope = task1.getOption();

            switch (ope)
            {
                case 1: task1.Agregar(0,"","En Proceso",hora); break;
                case 2: /*LLAMAR METODO*/Console.WriteLine("ACTUALIZAR");break;
                case 3: /*LLAMAR METODO*/Console.WriteLine("ELIMINAR");break;
                case 4: /*LLAMAR METODO*/Console.WriteLine("MARCAR");break;
                case 5: /*LLAMAR METODO*/Console.WriteLine("MOSTRAR ALL");break;
                case 6: /*LLAMAR METODO*/Console.WriteLine("MOSTRAR COMPL");break;
                case 7: /*LLAMAR METODO*/Console.WriteLine("MOSTRAR IMCOM");break;
                
                default: Console.WriteLine("");break;
            }



           /* foreach (var task in tasksList)
            {
                Console.WriteLine("{0,-20} {1,-30} {2,-10} {3,-20}", "ID", "Descripcion", "Creada:", "Estado");
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("{0,-10} {1,-8}", $"{task1.Id}", $"{task}", $"{task1.CreatedAt} creada en,", " actualizada en ", $"{task1.Estado}");
            }*/


             

            
             
             Console.ReadLine();

        }
    }
}
