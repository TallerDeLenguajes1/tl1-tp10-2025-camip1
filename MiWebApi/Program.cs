using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;
using EspacioNoticias;

List<NewsItem> datos = await GetNewsAsync();

Console.WriteLine("------------Ultimas Noticias mundiales------------");

foreach (var noticias in datos)
{
    Console.WriteLine($"Autor: {noticias.author}");
    Console.WriteLine($"Titulo: {noticias.title}");
    Console.WriteLine($"Descripcion: {noticias.description}");
    Console.WriteLine($"Categoria: {noticias.category}");
    Console.WriteLine($"Pais: {noticias.country}");
    Console.WriteLine($"Fecha de publicacion: {noticias.published_at}");
    Console.WriteLine("------------------------------------------");
}

string ruta = Directory.GetCurrentDirectory();

using (StreamWriter sw = new StreamWriter(ruta + @"\MiWebApi\News.json"))
{
    string jsonString = JsonSerializer.Serialize(datos, new JsonSerializerOptions { WriteIndented = true });
    sw.WriteLine(jsonString);
}

static async Task<List<NewsItem>> GetNewsAsync()
{    
    HttpClient client = new HttpClient();
    string url = "http://api.mediastack.com/v1/news?access_key=6d2d7f4c0c24d8b6e7d5ad24c4fa5d77";

    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();
    News listNoticias = JsonSerializer.Deserialize<News>(responseBody);
    List<NewsItem> datos = listNoticias.data;
    return datos;
}
