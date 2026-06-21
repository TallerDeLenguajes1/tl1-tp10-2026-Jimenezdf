using System.Text.Json;

var opciones = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNameCaseInsensitive = true
};


HttpClient client =  new HttpClient();
var url = "https://jsonplaceholder.typicode.com/users/";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody, opciones);

Console.WriteLine("=== PRIMEROS CINCO USUARIOS ===");
List<Usuario> listaCinco = new List<Usuario>();
for(int i=0;i<5;i++)
{
    var u = usuarios[i];
    Console.WriteLine($"USUARIO {i+1}");
    Console.WriteLine($"Nombre: {u.Name} - Correo: {u.Email} - Domicilio: {u.Address.Street}, {u.Address.City}");

    listaCinco.Add(u);
}

string jsonList = JsonSerializer.Serialize(listaCinco, opciones);

File.WriteAllText("usuarios.json", jsonList);