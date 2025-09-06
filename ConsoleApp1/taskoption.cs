using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
public static class TaskOption
{
    public static int getIndexInput(List<Task>? tareas)
    {
        int indexInput;
        //TryParse para eliminar la entrada de elementos no deseados
        while (!int.TryParse(Console.ReadLine(), out indexInput) || !tareas!.Any(tar => tar.ID == indexInput))
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
    public static void Save(List<Task>? tareas)
    {
        //Pedimos al usuario INPUT para añadir a la nueva tarea
        Console.WriteLine("Ingrese La descripcion de la tarea...");
        //creamos el nuevo objeto y a su vez registramos el INPUT
        var descriptionGet = Console.ReadLine();
        var newId = tareas!.Count + 1;
        Task newTask = new Task
        {
            Estado = EstadoTarea.En_Proceso,
            Descripcion = descriptionGet,
            ID = newId,
        };
        //Agregamos la nueva tarea a la lista de objetos
        tareas?.Add(newTask);
        //Serealizamos la lista de objetos a jsonstring y guardamos en el text.json
        var enumOptions = new JsonSerializerOptions
        {
            WriteIndented = true, // Organiza el Json File
            Converters = { new JsonStringEnumConverter() }
        };
        string jsonSave = JsonSerializer.Serialize(tareas, enumOptions);
        File.WriteAllText("json.Json", jsonSave);
        //Mostramos que los cambios fueron realizados exitosamente
        Console.WriteLine("\nTarea agregada exitosamente...\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey();        
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
        // USAMOS lista[index] = item PARA AGREGAR LOS COMBIOS AL MISMO INDEX QUE USAMOS ANTERIORMENTE 
        tareas![indexIp].Descripcion = descriptionGet;
        tareas![indexIp].UpdatedAt = DateTime.Now;
        // Serealizamos la lista de objetos a jsonstring y guardamos
        var enumOptions = new JsonSerializerOptions
        {
            WriteIndented = true, // Organiza el Json File
            Converters = { new JsonStringEnumConverter() }
        };
        string jsonSave = JsonSerializer.Serialize(tareas,enumOptions);
        File.WriteAllText("json.Json", jsonSave);
        // MOSTRAMOS persona ha sido Modificada Exitosamente
        Console.WriteLine("\nTarea actualizada exitosamente...\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
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
        var enumOptions = new JsonSerializerOptions
        {
            WriteIndented = true, // Organiza el Json File
            Converters = { new JsonStringEnumConverter() }
        };
        string jsonSave = JsonSerializer.Serialize(tareas, enumOptions);
        File.WriteAllText("json.Json", jsonSave);
        // MOSTRAMOS persona eliminada exitosamente
        Console.WriteLine("\nTarea eliminada exitosamente...\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
        Menu.ShowMenu(tareas);
    }
    public static void ListShow(List<Task>? tareas)
    {
        Console.WriteLine("{0,-8} {1,-20} {2,-27} {3,-20} {4,-10}", "ID", "Descripcion", "Creada:", "Estado", "Actualizada");
        Console.WriteLine(new string('-', 120));
        foreach (var tarea in tareas!)
        {
            Console.WriteLine("{0,-8} {1,-20} {2,-26} {3,-20} {4,-10} ", $"{tarea.ID}", $"{tarea.Descripcion}", $"{tarea.CreatedAt}", $" {tarea.Estado}", $" {tarea.UpdatedAt}");
        }
        Console.WriteLine("\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
        Menu.ShowMenu(tareas);
    }
    public static void MarkDown(List<Task>? tareas)
    {
        Console.WriteLine("Ingrese el 'ID' de la tarea para cambiar su estado.");
        int idMark = getIndexInput(tareas);
        Console.WriteLine("Seleccione el nuevo estado..\n 1. Completada - 2. Incompleta - 3. En proceso");
        int opEstado = getOption();
        switch (opEstado)
        {
            case 1:
                tareas![idMark].Estado = EstadoTarea.Completada;
                tareas![idMark].UpdatedAt = DateTime.Now; ; break;

            case 2:
                tareas![idMark].Estado = EstadoTarea.Incompleta;
                tareas![idMark].UpdatedAt = DateTime.Now; ; break;

            case 3:
                tareas![idMark].Estado = EstadoTarea.En_Proceso;
                tareas![idMark].UpdatedAt = DateTime.Now; ; break;

            default: Console.WriteLine("OPCION INVALIDA!"); break;
        }
        var enumOptions = new JsonSerializerOptions
        {
            WriteIndented = true, // Organiza el Json File
            Converters = { new JsonStringEnumConverter() }
        };
        string jsonSave = JsonSerializer.Serialize(tareas, enumOptions);
        File.WriteAllText("json.Json", jsonSave);
        Console.WriteLine("\nEstado Actualizado exitosamente...\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
        Menu.ShowMenu(tareas);
    }
    public static void ListComp(List<Task>? tareas)
    {
        Console.WriteLine("{0,-8} {1,-20} {2,-27} {3,-20} {4,-10}", "ID", "Descripcion", "Creada:", "Estado", "Actualizada");
        Console.WriteLine(new string('-', 120));
        foreach (var tarea in tareas!.Where(t => t.Estado == EstadoTarea.Completada))
        {
            Console.WriteLine("{0,-8} {1,-20} {2,-26} {3,-20} {4,-10} ", $"{tarea.ID}", $"{tarea.Descripcion}", $"{tarea.CreatedAt}", $" {tarea.Estado}", $" {tarea.UpdatedAt}");
        }
        Console.WriteLine("\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
        Menu.ShowMenu(tareas);

    }
    public static void ListInco(List<Task>? tareas)
    {
        Console.WriteLine("{0,-8} {1,-20} {2,-27} {3,-20} {4,-10}", "ID", "Descripcion", "Creada:", "Estado", "Actualizada");
        Console.WriteLine(new string('-', 120));
        foreach (var tarea in tareas!.Where(t => t.Estado == EstadoTarea.Incompleta))
        {
            Console.WriteLine("{0,-8} {1,-20} {2,-26} {3,-20} {4,-10} ", $"{tarea.ID}", $"{tarea.Descripcion}", $"{tarea.CreatedAt}", $" {tarea.Estado}", $" {tarea.UpdatedAt}");
        }
        Console.WriteLine("\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
        Menu.ShowMenu(tareas);

    }
    public static void ListPro(List<Task>? tareas)
    {
        Console.WriteLine("{0,-8} {1,-20} {2,-27} {3,-20} {4,-10}", "ID", "Descripcion", "Creada:", "Estado", "Actualizada");
        Console.WriteLine(new string('-', 120));
        foreach (var tarea in tareas!.Where(t=>t.Estado==EstadoTarea.En_Proceso))
        {
            Console.WriteLine("{0,-8} {1,-20} {2,-26} {3,-20} {4,-10} ", $"{tarea.ID}", $"{tarea.Descripcion}", $"{tarea.CreatedAt}", $" {tarea.Estado}", $" {tarea.UpdatedAt}");
        }
        Console.WriteLine("\nPresione cualquier tecla para volver al Menu...");
        Console.ReadKey(); 
        Menu.ShowMenu(tareas);

    }
}