// See https://aka.ms/new-console-template for more information
using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text;
using EspacioUsuario;

var listUsuarios = await GetUsuariosAsync();

Console.WriteLine("Primeros 5 usuarios:\n");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Usuario {i + 1}\nNombre: {listUsuarios[i].name} | Correo electronico: {listUsuarios[i].email}");
    Console.WriteLine($"Domicilio: {listUsuarios[i].address.street}, {listUsuarios[i].address.suite}, {listUsuarios[i].address.city}, {listUsuarios[i].address.zipcode}\n");
}

static async Task<List<Usuario>> GetUsuariosAsync()
{
    HttpClient client = new HttpClient();
    string url = "https://jsonplaceholder.typicode.com/users";

    //envio la solicitud GET
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode(); //verifico si la solicitud fue exitosa

    //leo y deserealizo la respuesta
    string responseBody = await response.Content.ReadAsStringAsync();
    List<Usuario> listUsuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody);
    return listUsuarios;
}