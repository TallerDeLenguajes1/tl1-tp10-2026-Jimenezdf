using System.Text.Json;

var opciones = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNameCaseInsensitive = true
};

HttpClient client =  new HttpClient();
var url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();

FotoNasa fotoDelDia = JsonSerializer.Deserialize<FotoNasa>(responseBody,opciones);

Console.WriteLine("=== NASA: FOTO ASTRONÓMICA DEL DÍA ===");
Console.WriteLine($"Título: {fotoDelDia.Title}");
Console.WriteLine($"Fecha: {fotoDelDia.Date}");
Console.WriteLine($"Explicación:\n{fotoDelDia.Explanation}");
Console.WriteLine($"Enlace a la imagen: {fotoDelDia.Url}");
string jsonGuardar = JsonSerializer.Serialize(fotoDelDia, opciones);
File.WriteAllText("nasa_apod.json", jsonGuardar);
Console.WriteLine("\nArchivo 'nasa_apod.json' guardado con éxito.");
