using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;
using EspacioTareas;

HttpClient client = new HttpClient();
var url = "https://jsonplaceholder.typicode.com/todos/";

HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> listTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

Console.WriteLine("---------------Tareas---------------\n");

List<Tarea> listPendientes = new List<Tarea>();
List<Tarea> listRealizadas = new List<Tarea>();

foreach (var tarea in listTarea)
{
    if (tarea.completed)
    {
        listRealizadas.Add(tarea);
    }
    else
    {
        listPendientes.Add(tarea);
    }
}

MostrarListas(listPendientes);
MostrarListas(listRealizadas);

//Serializar nuevamente
string MiArchivo = "c:/taller-de-lenguajes/tl1-tp10-2025-camip1/Tareas/tareas.json";

string[] lineas = new string[listTarea.Count+2];
lineas[0] = "[";
int i = 1;

foreach (var tarea in listTarea)
{
    string jsonString = JsonSerializer.Serialize(tarea);
    if (i != listTarea.Count)
    {
        lineas[i] = jsonString + ",";
    }
    else
    {
        lineas[i] = jsonString;
    }
    i++;
    //Console.WriteLine(jsonString);
}

lineas[listTarea.Count+1] = "]";

File.WriteAllLines(MiArchivo, lineas);
Console.WriteLine($"Reporte guardado en {MiArchivo}");


static void MostrarListas(List<Tarea> lista)
{
    foreach (var tareas in lista)
    {
        tareas.MostrarDatos();
    }
}