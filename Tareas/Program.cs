using System.Text.Json;



HttpClient client = new HttpClient();
var url = "https://jsonplaceholder.typicode.com/todos/";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> Tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

foreach(var prod in Tareas)
{
    Console.WriteLine("User id: " + prod.UserId + " Id: " + prod.Id + " Titulo: " + prod.Title + " Estado: " + prod.Completed);
}
