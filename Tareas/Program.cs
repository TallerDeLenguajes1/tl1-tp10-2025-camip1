using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;
using EspacioTareas;

HttpClient client = new HttpClient(); //instancia Http
var url = "https://jsonplaceholder.typicode.com/todos/";

HttpResponseMessage response = await client.GetAsync(url); //envio de solicitud GET
response.EnsureSuccessStatusCode(); //verifico si la solicitud fue exitosa

//se lee y deserealiza la respuesta
string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> listTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

Console.WriteLine("---------------Tareas---------------\n");

foreach (Tarea tarea in listTarea)
{
    if (!tarea.completed)
    {
        Console.WriteLine($"\nTitulo: {tarea.title}");
        Console.WriteLine($"Estado: Pendiente");
    }
}
foreach (Tarea tarea in listTarea)
{
    if (tarea.completed)
    {
        Console.WriteLine($"\nTitulo: {tarea.title}");
        Console.WriteLine($"Estado: Completada");
    }
}

//Serializar nuevamente
string ruta = Directory.GetCurrentDirectory();
string MiArchivo = ruta + "/Tareas/tareas.json";

using (StreamWriter sw = new StreamWriter(MiArchivo))
{
    string jsonString = JsonSerializer.Serialize(listTarea, new JsonSerializerOptions { WriteIndented = true }); //formato de JSON
    sw.WriteLine(jsonString);
}

Console.WriteLine($"Reporte guardado en {MiArchivo}");
