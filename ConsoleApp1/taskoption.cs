using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MiPrimeraApp
{

   public class TaskOption
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TaskOption(int ID, string descripcion, string estado, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = ID;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        
            

        
    }

}