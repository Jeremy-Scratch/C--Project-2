public class Task
{
   public int ID { get; set; }
    public string? Descripcion { get; set; }
    public EstadoTarea Estado;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Task() //CONSTRUCTOR
    {
        CreatedAt = DateTime.Now;
        Estado = EstadoTarea.En_Proceso;
    }
}