using System.Text.Json.Serialization;
public class Task
{
    public int ID { get; set; }
    public string? Descripcion { get; set; }
    public EstadoTarea Estado { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Task() //CONSTRUCTOR
    {
        CreatedAt = DateTime.Now;
    }
}