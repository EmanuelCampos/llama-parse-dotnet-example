using RestSharp;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var options = new RestClientOptions("https://api.cloud.llamaindex.ai");
        var client = new RestClient(options);
        var request = new RestRequest("/api/parsing/upload", Method.Post);
        request.AddHeader("Authorization", "Bearer llx-QCCsRbxpdb7Ti6MVJNlkNfd4zbrIM0s2qQrTlSwAMJlso7yN");
        request.AlwaysMultipartFormData = true;
        request.AddFile("file", "./file.pdf");
        request.AddParameter("parsing_instruction", "translate in japanese");
        request.AddParameter("language", "ja");
        request.AddParameter("invalidate_cache", "true");
        request.AddParameter("gpt4o_mode", "true");
        request.AddParameter("page_separator", "\nhelloworld\n");
        request.AddParameter("fast_mode", "true");
        request.AddParameter("do_not_cache", "true");
        RestResponse response = await client.ExecuteAsync(request);
        Console.WriteLine(response.Content);
    }
}
