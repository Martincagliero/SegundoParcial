using AccesoDatos.Models;
using AccesoDatos.Repositories;

// 1. Instanciamos el repositorio.
IGenericRepository<Artista> artistaRepository = new GenericRepository<Artista>();
CancionRepository cancionRepository = new CancionRepository();

bool continuar = true;

while (continuar)
{
    Console.WriteLine("=================================================");
    Console.WriteLine("\tPlataforma musical");
    Console.WriteLine("=================================================");
    Console.WriteLine();
    Console.WriteLine("1. Alta Artista");
    Console.WriteLine("2. Alta Cancion");
    Console.WriteLine("3. Ver Canciones");
    Console.WriteLine("4. Mostrar canciones más largas");
    Console.WriteLine("5. Cantidad total de canciones");
    Console.WriteLine("6. Mostrar canciones ordenadas alfabéticamente por título");
    Console.WriteLine("7. Verificar si existen canciones registradas");
    Console.WriteLine("8. Visualizar artistas registrados.");
    Console.WriteLine("0. Salir");
    Console.WriteLine();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();
    Console.Clear();

    switch (opcion)
    {
        case "1":
            AltaArtista();
            break;
        case "2":
            AltaCancion();
            break;
        case "3":
            VerCanciones();
            break;

        case "4":
            MostrarCancionesMasLargas();
            break;
        case "5":
            CantidadTotalCanciones();
            break;
        case "6":
            CancionesOrdenadasXTitulo();
            break;
        case "7":
            VerificarExistenCanciones();
            break;
        case "8":
            VisualizarArtistas();
            break;



        case "0":
            Console.WriteLine("¡Cerrando el sistema de Artistas!");
            continuar = false;
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            PresioneParaContinuar();
            break;
    }
}

void AltaArtista()
{
    Console.Write("Ingrese el nombre del Artista: ");
    string nombre = Console.ReadLine();



    var nuevoArtista = new Artista
    {
        Nombre = nombre,
    
    };

    artistaRepository.Agregar(nuevoArtista);
    Console.WriteLine("Artista agregado exitosamente.");
    PresioneParaContinuar();
}
void AltaCancion()
{
    Console.Write("Ingrese el id del artista: ");
    int ArtistaId = int.Parse(Console.ReadLine());


    Console.Write("Ingrese el Titulo de la cancion: ");
    string titulo = Console.ReadLine();
    Console.Write("Ingrese la duracion de la cancion (en minutos) : ");
    int duracion = int.Parse(Console.ReadLine());


    var nuevaCancion = new Cancion
    {
        Titulo = titulo,
        ArtistaId = ArtistaId,
        Duracion = duracion,
    };

    cancionRepository.Agregar(nuevaCancion);
    Console.WriteLine("Cancion agregada exitosamente.");
    PresioneParaContinuar();
}



void VerCanciones()
{
    MostrarListaCanciones(cancionRepository);
    PresioneParaContinuar();

}

void MostrarListaCanciones(IGenericRepository<Cancion> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL EN BASE DE DATOS ---");
    var Canciones = repository.ObtenerTodos();

    if (!Canciones.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var c in Canciones)
        {
            Console.WriteLine($"ID: {c.Id} | Titulo: {c.Titulo} | Duracion: {c.Duracion} ");
        }
    }
    Console.WriteLine("---------------------------------------");
    Console.WriteLine();
}



void MostrarCancionesMasLargas()
{
    List<Cancion> canciones = cancionRepository.CancionesMasLargas();

    foreach (var cancion in canciones)
    {
        Console.WriteLine($"Título: {cancion.Titulo} | Duro : {cancion.Duracion} minutos ");
       
      
    }
}
void CantidadTotalCanciones()
{
    var total = cancionRepository.CantidadTotalCanciones();
    Console.WriteLine(total);
}

void CancionesOrdenadasXTitulo()
{
    List<Cancion> canciones = cancionRepository.CancionesOrdenadasXTitulo();

    foreach(var c in canciones)
    {
        Console.WriteLine($"ID: {c.Id} | Titulo: {c.Titulo} ");
    }
}



void VerificarExistenCanciones()
{
    var existen = cancionRepository.VerificarExistenCanciones();

    if(existen)
    {
        Console.WriteLine("Existen canciones registradas");
    }
    else
    {
        Console.WriteLine("No existen canciones registradas");
    }
}


void VisualizarArtistas()
{
    MostrarListaArtistas(artistaRepository);
    PresioneParaContinuar();
}

void MostrarListaArtistas(IGenericRepository<Artista> repository)
{
    Console.WriteLine("--- LISTADO ACTUAL EN BASE DE DATOS ---");
    var Artistas = repository.ObtenerTodos();

    if (!Artistas.Any())
    {
        Console.WriteLine("[La tabla está vacía]");
    }
    else
    {
        foreach (var u in Artistas)
        {
            Console.WriteLine($"ID: {u.Id} | Nombre: {u.Nombre} ");
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
