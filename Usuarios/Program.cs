using EspacioUsuarios;
using System.IO;
using System.Text.Json;

// Crear una Instancia de HttpClient:
HttpClient client = new HttpClient();

// Enviar Solicitud GET: Se envía una solicitud GET a la URL especificada y se verifica que la
// respuesta sea exitosa.

string url="https://jsonplaceholder.typicode.com/users";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();

// Leer y Deserializar la Respuesta:
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuarios> listUsuarios = JsonSerializer.Deserialize<List<Usuarios>>(responseBody);

int contador=0; 

foreach (Usuarios usuario in listUsuarios)
{
    if (contador < 5)
    {
        Console.WriteLine($"Nombre: {usuario.name}");
        Console.WriteLine($"Correo electronico: {usuario.email}");
        Console.WriteLine($"Domicilio: {usuario.address.street}");
    }
    contador++;
}

string rutaArchivo = "../lista.csv";
using(StreamWriter writer = new StreamWriter(rutaArchivo, true)){
    writer.WriteLine("id, Nombre, Usuario, Correo Electronico, Ciudad, Numero telefonico");
        foreach(Usuarios elementos in listUsuarios)
    {
        int escribirId = elementos.id;
        string escribirNombre = elementos.name;
        string escribirApellido = elementos.username;
        string escribirCorreo = elementos.email;
        string escribirCiudad = elementos.address.city;
        string escribirCelular = elementos.phone;
        string escribirPagina= elementos.website;
        string escribirCompania = elementos.company.name;

        string linea = $"{escribirId},{escribirNombre}, {escribirApellido},{escribirCorreo}, {escribirCiudad}, {escribirCelular}, {escribirPagina}, {escribirCompania}";
        writer.WriteLine(linea);
    }

    Console.WriteLine("Archivo cargado");
}