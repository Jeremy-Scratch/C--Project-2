using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Dynamic;
//@Jeremy_Scratch
public enum EstadoTarea
    {
        Completada,
        En_Proceso,
        Incompleta
    }
public class TaskTracker
{
    static void Main(string[] args)
    {
        if (!File.Exists("json.Json"))
        { File.WriteAllText("json.Json", "[]"); }

        string jsonC = File.ReadAllText("json.Json");

        var enumOptions = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        List<Task>? tareas = JsonSerializer.Deserialize<List<Task>>(jsonC,enumOptions);
        Menu.ShowMenu(tareas!);
    }    
}
