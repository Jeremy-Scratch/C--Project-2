using System;
using System.IO;
using System.Text.Json;
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

        var tareas = TaskOption.Cargar()??[];
        Menu.ShowMenu(tareas);
    }    
}
