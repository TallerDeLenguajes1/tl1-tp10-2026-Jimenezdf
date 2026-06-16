using System.Text.Json;

var opciones = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNameCaseInsensitive = true
};

HttpClient client = new HttpClient();
var url = "https://jsonplaceholder.typicode.com/todos/";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> Tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody, opciones);

foreach(var prod in Tareas)
{   
    Console.WriteLine("User id: " + prod.UserId + " Tarea #" + prod.Id + ": " + prod.Title + " (Completada: " + prod.Completed + ")");
}
