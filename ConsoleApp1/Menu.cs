
public static class Menu
{
    public static void ShowMenu(List<Task> tareas)
    {
        Console.WriteLine("{0,-20} {1,-5}", "", "BIENVENIDO A TU ORGANIZADOR DE TAREAS!");
        Console.WriteLine("\n");
        Console.WriteLine("\nElija una tarea a realizar...\n\n 1. Agregar nueva tarea.\n 2. Actualizar tarea.\n 3. Eliminar tarea.\n 4. Marcar como completada / en progreso.\n 5. Mostrar todas las tareas.\n 6. Mostrar las tareas completadas.\n 7. Mostrar las tareas incompletas\n 8.Salir\n");
        int ope = TaskOption.getOption();
        switch (ope)
        {
            case 1: TaskOption.Save(tareas); Console.WriteLine("AGREGAR"); break;
            case 2: TaskOption.Update(tareas); Console.WriteLine("ACTUALIZAR"); break;
            case 3: TaskOption.Delete(tareas); Console.WriteLine("ELIMINAR"); break;
            case 4: /*LLAMAR METODO*/Console.WriteLine("MARCAR"); break;
            case 5: TaskOption.ListShow(tareas); Console.WriteLine("MOSTRAR ALL"); break;
            case 6: /*LLAMAR METODO*/Console.WriteLine("MOSTRAR COMPL"); break;
            case 7: /*LLAMAR METODO*/Console.WriteLine("MOSTRAR IMCOM"); break;
            case 8: System.Environment.Exit(0); break;

            default:
                Console.Clear();
                Console.WriteLine("OPCION INVALIDA!");
                Menu.ShowMenu(tareas);
            break;
        }
    }
}