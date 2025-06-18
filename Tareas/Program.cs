using System.Text.Json;
using EspacioTarea;

HttpClient client = new HttpClient();

string url = "https://jsonplaceholder.typicode.com/todos/";

HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();

List<Tarea> listaTareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

Console.WriteLine("-----------------------------------------------");
foreach (Tarea mostrar in listaTareas)
{
    if(mostrar.completed == false)
    {
        Console.WriteLine("Nombre: " + mostrar.title + "\nEstado :Pendiente");
    }    
}
Console.WriteLine("-----------------------------------------------");
foreach (Tarea mostrar in listaTareas)
{
    if(mostrar.completed == true)
    {
        Console.WriteLine("Nombre: " + mostrar.title + "\nEstado :Realizada");
    }
    
}
