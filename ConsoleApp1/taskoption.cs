using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace MiPrimeraApp
{

    public class TaskOption
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TaskOption(int ID, string descripcion, string estado, DateTime createdAt/*, DateTime updatedAt*/)
        {
            this.Id = ID;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.CreatedAt = createdAt;
            //   this.UpdatedAt = updatedAt;
        }

        public TaskOption()
        {
            Descripcion = "";
            Estado = "";
        }
        List<TaskOption> tasksList = new List<TaskOption>();

        public int getOption()
        {
            int op;
            while (!int.TryParse(Console.ReadLine(), out op))

            {
                Console.WriteLine("Entrada invalida");
            }
            return op;

        }
        public void Agregar(int ID, string descripcion, string estado, DateTime createdAt)
        {
            while (true)
            {


                //ID++;
                descripcion = Console.ReadLine()!;
               // TaskOption newtask = new TaskOption {Id=ID, Descripcion = descripcion, Estado = estado, CreatedAt = createdAt };
              //  tasksList.Add(newtask);
                tasksList.Add(new TaskOption { Id = ID, Descripcion = descripcion, Estado = estado, CreatedAt = createdAt });


                foreach (var task in tasksList)
                {
                    // Console.WriteLine("{0,-15} {1,-20} {2,-15} {3,-20}", "ID", "Descripcion", "Creada:", "Estado");
                    // Console.WriteLine(new string('-', 80));
                    Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-20}", $"{ID}", $"{descripcion}", $"{createdAt}", $"{estado}");
                    //Console.WriteLine(task);

                }
            }

        }


        



    }

}