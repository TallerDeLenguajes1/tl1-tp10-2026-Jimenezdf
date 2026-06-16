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


List <Tarea> TareasPendientes = Tareas.Where(p => p.Completed == false).ToList();
List <Tarea> TareasCompletas = Tareas.Where(p => p.Completed == true).ToList();

/*Console.WriteLine("--Tareas Pendientes--");
foreach (var pend in TareasPendientes)
{
    Console.WriteLine("User id: " + pend.UserId + " Tarea #" + pend.Id + ": " + pend.Title + " (Completada: " + pend.Completed + ")");
}

Console.WriteLine("--Tareas completadas--");
foreach (var comp in TareasCompletas)
{
    Console.WriteLine("User id: " + comp.UserId + " Tarea #" + comp.Id + ": " + comp.Title + " (Completada: " + comp.Completed + ")");
}
*/

Console.WriteLine("---- SERIALIZAR ----");
string JsonList = JsonSerializer.Serialize(Tareas, opciones);
Console.WriteLine(JsonList);


File.WriteAllText("tareas.json", JsonList);