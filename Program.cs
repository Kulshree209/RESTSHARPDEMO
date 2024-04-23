using System;
using RestSharp;
using Newtonsoft.Json;

class Program {
  public static void Main (string[] args) {
    var client = new RestClient("https://simple-books-api.glitch.me/books");
    var request = new RestRequest(Method.GET);

    IRestResponse response = client.Execute(request);

    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        Console.WriteLine("Status Code: " + response.StatusCode);

        var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);

        foreach (var item in responseData)
        {
            Console.WriteLine($"Name: {item.name}, Type: {item.type}");
        }
    }
    else
    {
        Console.WriteLine("Failed to retrieve data. Status Code: " + response.StatusCode);
    }

    // Check status code
    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        Console.WriteLine("Status Code: " + response.StatusCode);

        // Deserialize response
        var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

        // Check properties
        if (responseData[0].name != null && responseData[0].type != null)
        {
            Console.WriteLine("Name: " + responseData[0].name);
            Console.WriteLine("Type: " + responseData[0].type);
        }
        else
        {
            Console.WriteLine("Response doesn't contain expected data.");
        }
    }
    else
    {
        Console.WriteLine("Failed to retrieve data. Status Code: " + response.StatusCode);
    }
    
  }
}