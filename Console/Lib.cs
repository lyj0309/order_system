using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib;

class Person
{
    public string Name { get; set; }
    public string Occupation { get; set; }

    public override string ToString()
    {
        return $"{Name}: {Occupation}";
    }
}

class Client
{

    public static async Task Request(string path, string method, object obj)
    {
        using var client = new HttpClient();

        StringContent d = null;

        HttpResponseMessage response = null;
        if (obj is not null)
        {
            var json = JsonConvert.SerializeObject(obj);
            d = new StringContent(json, Encoding.UTF8, "application/json");

        }
        var url = "http://10.2.155.201:12346/" + path;
        //Console.WriteLine($"url:{url}");
        switch (method)
        {
            case "GET":
                response = await client.GetAsync(url);
                break;
            case "POST":
                response = await client.PostAsync(url, d);

                break;
            case "DELETE":
                response = await client.DeleteAsync(url);
                break;
            case "PATCH":
                response = await client.PatchAsync(url, d);
                break;
        }
        if (response is null)
        {
            throw new Exception($"请求失败,{method},{url}");
        }
        //string result = response.Content.ReadAsStringAsync().Result;
        //Console.WriteLine(result);
        var resp = await response.Content.ReadAsStringAsync();

        var data = JsonConvert.DeserializeObject<ResponseModel<object>>(resp);
        if (!data.IsSuccess)
        {
            throw new Exception($"服务请求失败,{method},{url},{data.ErrorMessage}");
        }
        Console.WriteLine($"请求成功,{method},{url}");
        PrintObj(data.Data);
    }
    static void PrintObj(object obj)
    {
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
        {
            string name = descriptor.Name;
            object value = descriptor.GetValue(obj);
            Console.WriteLine("{0}={1}", name, value);
        }

    }
}

