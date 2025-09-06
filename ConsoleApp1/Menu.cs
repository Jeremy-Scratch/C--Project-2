
public static class Menu
{
    public static void ShowMenu(List<Task>? tareas)
    {
        Console.WriteLine("\n");
        Console.WriteLine("{0,-20} {1,-5}", "", "BIENVENIDO A TU ORGANIZADOR DE TAREAS!\n\n\n");   
        Console.WriteLine("\nElija una tarea a realizar...\n\n 1. Agregar nueva tarea.\n 2. Actualizar tarea.\n 3. Eliminar tarea.\n 4. Marcar como completada / en progreso.\n 5. Mostrar todas las tareas.\n 6. Mostrar las tareas completadas.\n 7. Mostrar las tareas en proceso.\n 8. Mostrar las tareas incompletas\n 9. Salir...\n");
        int ope = TaskOption.getOption();
        switch (ope)
        {
            case 1: TaskOption.Save(tareas); break;
            case 2: TaskOption.Update(tareas); break;
            case 3: TaskOption.Delete(tareas); break;
            case 4: TaskOption.MarkDown(tareas); break;
            case 5: TaskOption.ListShow(tareas); break;
            case 6: TaskOption.ListComp(tareas); break;
            case 7: TaskOption.ListPro(tareas); break;
            case 8: TaskOption.ListInco(tareas); break;
            case 9: System.Environment.Exit(0); break;

            default:
                Console.Clear();
                Console.WriteLine("OPCION INVALIDA!");
                Menu.ShowMenu(tareas);
            break;
        }
    }
}