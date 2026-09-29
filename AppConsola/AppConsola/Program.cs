using AccesoDatos.Models;
using AccesoDatos.Repositories;

// 1. Instanciamos el repositorio.
IGenericRepository<Usuario> usuarioRepository = new GenericRepository<Usuario>();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("\tGestión de Usuarios");
    Console.WriteLine("=================================================");
    Console.WriteLine();
    Console.WriteLine("1. Agregar usuario (Alta)");
    Console.WriteLine("2. Modificar usuario (Modificación)");
    Console.WriteLine("3. Eliminar usuario (Baja)");
    Console.WriteLine("4. Ver todos los usuarios");
    Console.WriteLine("5. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();
    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaUsuario();
            break;

        case "2":
            ModificarUsuario();
            break;

        case "3":
            BajaUsuario();
            break;

        case "4":
            VisualizarUsuarios();
            break;

        case "5":
            Console.WriteLine("¡Cerrando el sistema de usuarios!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            PresioneParaContinuar();
            break;
    }
}

void AltaUsuario()
{
    Console.Write("Ingrese el nombre del usuario: ");
    string name = Console.ReadLine();

    Console.Write("Ingrese el apellido del usuario: ");
    string lastName = Console.ReadLine();

    var nuevoUsuario = new Usuario
    {
        Name = name,
        LastName = lastName
    };

    usuarioRepository.Agregar(nuevoUsuario);
    Console.WriteLine("Usuario agregado exitosamente.");
    PresioneParaContinuar();
}

void ModificarUsuario()
{
    MostrarListaUsuarios(usuarioRepository);
    Console.Write("Ingrese el ID del usuario a modificar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var usuarioACambiar = usuarioRepository.ObtenerPorId(id);

        if (usuarioACambiar != null)
        {
            Console.Write($"Ingrese el nuevo nombre para '{usuarioACambiar.Name}': ");
            usuarioACambiar.Name = Console.ReadLine();

            Console.Write($"Ingrese el nuevo apellido para '{usuarioACambiar.LastName}': ");
            usuarioACambiar.LastName = Console.ReadLine();

            usuarioRepository.Modificar(usuarioACambiar);
            Console.WriteLine("Usuario actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró ningún usuario con ese ID.");
        }
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
    PresioneParaContinuar();
}

void BajaUsuario()
{
    MostrarListaUsuarios(usuarioRepository);
    Console.Write("Ingrese el ID del usuario a eliminar: ");

    if (int.TryParse(Console.ReadLine(), out int id))
    {
        usuarioRepository.Eliminar(id);
        Console.WriteLine("Proceso de eliminación finalizado.");
    }
    else
    {
        Console.WriteLine("ID inválido.");
    }
    PresioneParaContinuar();
}

void VisualizarUsuarios()
{
    MostrarListaUsuarios(usuarioRepository);
    PresioneParaContinuar();
}

void MostrarListaUsuarios(IGenericRepository<Usuario> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL EN BASE DE DATOS ---");
    var usuarios = repository.ObtenerTodos();

    if (!usuarios.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var u in usuarios)
        {
            Console.WriteLine($"ID: {u.Id} | Nombre: {u.Name} {u.LastName}");
        }
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
}

void PresioneParaContinuar()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}
