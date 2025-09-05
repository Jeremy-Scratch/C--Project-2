using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Text.Json;
public static class TaskOption
{
    public static int getIndexInput(List<Task>? tareas)
    {
        int indexInput;
        //TryParse para eliminar la entrada de elementos no deseados
        while (!int.TryParse(Console.ReadLine(), out indexInput) || !tareas!.Any(tar => tar.ID == indexInput)  )
        {
            Console.WriteLine("Entrada invalida");
        }        
        return tareas!.FindIndex(tar => tar.ID == indexInput);        
    }
    public static int getOption()
    {
        int op;
        while (!int.TryParse(Console.ReadLine(), out op))

        {
            Console.WriteLine("Entrada invalida");
        }
        return op;
    }
    public static List<Task>? Cargar()
    {
        string jsonC = File.ReadAllText("json.Json");
        List<Task>? Tareas = new List<Task>();
        Tareas = JsonSerializer.Deserialize<List<Task>>(jsonC);
        return Tareas;
    }
    public static void Save(List<Task>? tareas)
    { 
        //Pedimos al usuario INPUT para añadir a la nueva tarea
        Console.WriteLine("Ingrese La descripcion de la tarea...");
        //creamos el nuevo objeto y a su vez registramos el INPUT
        var descriptionGet = Console.ReadLine();
        var newId = tareas!.Count + 1;
        Task newTask = new Task
        {
            Descripcion = descriptionGet,
            ID = newId,            
        };
        //Agregamos la nueva tarea a la lista de objetos
        tareas?.Add(newTask);
        //Serealizamos la lista de objetos a jsonstring y guardamos en el text.json
        string jsonSave = JsonSerializer.Serialize(tareas);
        File.WriteAllText("json.Json", jsonSave);
        //Mostramos que los cambios fueron realizados exitosamente
        Console.WriteLine("Tarea agregada exitosamente");

        foreach (var tarea in tareas!)
        {
            Console.WriteLine($"ID:{tarea.ID}  Descripcion: {tarea.Descripcion}, {tarea.CreatedAt}");
        }
        Menu.ShowMenu(tareas);

    }
    public static void Update(List<Task>? tareas)
    {       
        // pedir al usuario INPUT del index a modificar
        Console.WriteLine("Que tarea desea modificar? ingrese el 'ID'...");
        int indexIp = getIndexInput(tareas);        
        // PEDIR NUEVO INPUT PARA SU MODIFICACION(NUEVO OBJETO)
        Console.WriteLine("Ingrese nueva Descripcion ...");
        var descriptionGet = Console.ReadLine();
        Task UpdateTarea = new Task
        {
            ID = indexIp+ 1,
            Descripcion = descriptionGet,
            UpdatedAt = DateTime.Now,
        };
        // USAMOS lista[index] = item PARA AGREGAR LOS COMBIOS AL MISMO INDEX QUE USAMOS ANTERIORMENTE 
        tareas![indexIp] = UpdateTarea;
        // Serealizamos la lista de objetos a jsonstring y guardamos
        string jsonSave = JsonSerializer.Serialize(tareas);
        File.WriteAllText("json.Json", jsonSave);
        // MOSTRAMOS persona ha sido Modificada Exitosamente
        Console.WriteLine("Tarea actualizada exitosamente");

        foreach (var tarea in tareas)
        {
            Console.WriteLine($"ID:{tarea.ID}  Descripcion: {tarea.Descripcion}, {tarea.CreatedAt}, {tarea.Estado}, {tarea.UpdatedAt}");
        }
        Menu.ShowMenu(tareas);

    }
    public static void Delete(List<Task>? tareas)
    {   
        // Pedir al usuario INPUT del Index a eliminar / guardar en variable
        Console.WriteLine("Que Tarea desea eliminar? ingrese el 'ID'...");
        //TryParse para eliminar la entrada de elementos no deseados
        int indexIp = getIndexInput(tareas);        
        // Lugo usamos RemoveAt persons.RemoveAt(index)
        tareas!.RemoveAt(indexIp);
        // Serealizamos la lista de objetos a jsonstring y guardamos en el text.json
        string jsonSave = JsonSerializer.Serialize(tareas);
        File.WriteAllText("json.Json", jsonSave);
        // MOSTRAMOS persona eliminada exitosamente
        Console.WriteLine("Tarea Eliminada exitosamente");
        foreach (var tarea in tareas)
        {
            Console.WriteLine($"ID:{tarea.ID}  Descripcion: {tarea.Descripcion}, {tarea.CreatedAt}");
        }
        Menu.ShowMenu(tareas);
    }
    public static void ListShow(List<Task>? tareas)
    {
        Console.WriteLine("{0,-8} {1,-20} {2,-21} {3,-1}", "ID", "Descripcion", "Creada:", "Estado");
        Console.WriteLine(new string('-', 80));
        foreach (var tarea in tareas!)
        {
            Console.WriteLine("{0,-8} {1,-20} {2,-15} {3,-20} ", $"{tarea.ID}", $"{tarea.Descripcion}", $"{tarea.CreatedAt}", $" Estado: {tarea.Estado}");
        }
        Menu.ShowMenu(tareas); 
    }
}