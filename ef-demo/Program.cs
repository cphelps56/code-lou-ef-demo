// See https://aka.ms/new-console-template for more information
using ef_demo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

void LogNumber(int number)
{
    Thread.Sleep(100);
    Console.WriteLine(number);
}

async Task LogNumberAsync(int number)
{
    await Task.Run(() =>
    {
        Console.WriteLine(number);
    });
}

var zeroToOneHundred = Enumerable.Range(0, 100);

//foreach (var number in zeroToOneHundred)
//{
//    LogNumber(number);
//}

var tasks = zeroToOneHundred.Select(x => LogNumberAsync(x));

await Task.WhenAll(tasks);



//var apiClient = new HttpClient();
//apiClient.BaseAddress = new Uri("https://pokeapi.co/api/");
//var response = await apiClient.GetAsync("v2/pokemon/ditto");
//var jsonResponse = await response.Content.ReadAsStringAsync();
//var pokemon = JsonSerializer.Deserialize<Pokemon>(jsonResponse);

//Console.WriteLine(pokemon.name);

//var manufacturers = JsonSerializer.Deserialize<IEnumerable<Manufacturer>>(jsonResponse, new JsonSerializerOptions
//{
//    PropertyNameCaseInsensitive = true
//});

//foreach(var manufacturer in manufacturers)
//    Console.WriteLine(manufacturer.Name);


//Console.WriteLine("Hello, World!");


//using var db = new VendingMachineContext();

//Console.WriteLine(db.DbPath);

//var dietCoke = db.Products
//    .Include(x=> x.Manufacturer)
//    .Include(x=> x.ProductType)
//    .FirstOrDefault(p => p.Name == "Diet Coke");


//Console.WriteLine(dietCoke.Manufacturer.Name);

//Console.ReadLine();

//Console.WriteLine("----Menu Options----");
//Console.WriteLine("Press 1 to List Available Products");
//Console.WriteLine("Press 2 to Add Products");

//var userInput = Console.ReadLine();

//if (userInput == "1")
//{
//    Console.WriteLine("Current products available for purchase: ");

//    if (db.Products.Any())
//    {
//        foreach (var item in db.Products)
//        {
//            Console.WriteLine($"{item.Id} - {item.Name}");
//        }
//    }
//    else
//    {
//        Console.WriteLine("There are no products available for purchase.");
//    }
//}
//if(userInput == "2")
//{
//    Console.WriteLine("Enter Product Type:");
//    foreach(var productType in db.ProductTypes)
//    {
//        Console.WriteLine($"Press {productType.Id} for {productType.Name}");
//    }
//    var productTypeInput = Console.ReadLine();


//    Console.WriteLine("Enter Manufacturer:");
//    foreach (var manufacturer in db.Manufacturers)
//    {
//        Console.WriteLine($"Press {manufacturer.Id} for {manufacturer.Name}");
//    }
//    var manufacturerInput = Console.ReadLine();

//    Console.WriteLine("Enter Product Name:");
//    var productName = Console.ReadLine();

//    Console.WriteLine("Enter Price:");
//    var price = Console.ReadLine();

//    var userProduct = new Product
//    {
//        ManufacturerId = int.Parse(manufacturerInput),
//        ProductTypeId = int.Parse(productTypeInput),
//        Name = productName,
//        Price = decimal.Parse(price)
//    };

//    db.Products.Add(userProduct);

//    db.SaveChanges();

//}