using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter the URL: "); //Input the URL
        string url = Console.ReadLine();

        if(string.IsNullOrEmpty(url)) //If URL is empty 
        {
            Console.WriteLine("You have not entered URL");
        }
        else
        {
            Console.WriteLine("Your content is downloading");
            string content = await DownloadContentAsync(url); //Store content in String

            string filename = "A.txt";
            await WriteContentAsync(filename, content);
            Console.WriteLine("Work Done");
        }
    }

    static async Task<string> DownloadContentAsync(string url) //Downloading content using HTTP client
    {
        using (var client = new HttpClient())
        {
            HttpResponseMessage res = await client.GetAsync(url);
            return await res.Content.ReadAsStringAsync();
        }
    }
    static async Task WriteContentAsync(string filename, string content) //Writing the content
    {
        using (var writer = new StreamWriter(filename)) // Using StreamWriter to write in file
        {
            await writer.WriteAsync(content);
        }
    }
}