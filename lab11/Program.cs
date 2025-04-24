using System.Text.Json;

//https://dummyjson.com/products
using System.Text.Json;

var uri = "https://dummyjson.com";

var httpClient=new HttpClient();
httpClient.BaseAddress = new Uri(uri);
var response = await httpClient.GetAsync("/products");

if(response.IsSuccessStatusCode)
{
    var result = await response.Content.ReadAsStringAsync();

    var options = new JsonSerializerOptions
    {
        IgnoreReadOnlyProperties = true,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    var root = JsonSerializer.Deserialize<Root>(result, options);

    foreach (var product in root.Products)
    {
        Console.WriteLine(product.Title);
    }
}

var users = new List<User>();
users.Add(new User() { Name = "Name1" });

var json=JsonSerializer.Serialize(users);
Console.WriteLine(json);

Func<string, string> convert = delegate (string s)
{
    return s.ToUpper();
};

string name = "Dakota";
Console.WriteLine(convert(name));

Callback handler = DelegateMethod;
handler("Hello world");

static void DelegateMethod(string message)
{
    Console.WriteLine(message);
}

public delegate void Callback(string message);

public class User
{
    public string Name { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class Root
{
    public List<Product> Products { get; set; }
}