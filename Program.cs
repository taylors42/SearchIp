using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using SearchIp;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            ConsoleWriteColor(
                ConsoleColor.Red,
                "Please provide an IP address."
            );
            return;
        }

        var commandList = Resource1.comandos.Split(",").ToList();

        string userIpAddress = "";

        foreach (string arg in args)
        {
            if (
                commandList.Contains(arg) is false &&
                VerifyIpRegex(arg) is false
            )
            {
                ConsoleWriteColor(
                    ConsoleColor.Red,
                    "Bad Argument -> " + arg
                );
                return;
            }

            if (VerifyIpRegex(arg) is true)
            {
                userIpAddress = arg;
            }
        }

        if (args.Contains("-h"))
        {
            ShowHelp();
            return;
        }

        await GetIpGeographicInformation(userIpAddress);
    }

    static void ConsoleWriteColor(ConsoleColor num, string message)
    {
        Console.ForegroundColor = num;
        Console.Write(message + " ");
        Console.ResetColor();
    }

    static bool VerifyIpRegex(string ip)
    {
        if (
            !System.Text.RegularExpressions.Regex.IsMatch(
                ip,
                @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
        )
        {
            return false;
        }
        return true;
    }

    async static Task GetIpGeographicInformation(string IpAddress)
    {
        string apiUrl = $"http://ip-api.com/json/{IpAddress}";

        using var client = new HttpClient();

        try
        {
            var response = await client.GetAsync(apiUrl);
            string json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            if (
                root.TryGetProperty("status", out JsonElement statusElement) &&
                statusElement.GetString() == "success"
            )
            {
                string country = root.TryGetProperty("country", out JsonElement c)
                    ? c.GetString() ?? "Unknown"
                    : "Unknown";

                string region = root.TryGetProperty("regionName", out JsonElement r)
                    ? r.GetString() ?? "Unknown"
                    : "Unknown";

                string city = root.TryGetProperty("city", out JsonElement ct)
                    ? ct.GetString() ?? "Unknown"
                    : "Unknown";

                string isp = root.TryGetProperty("isp", out JsonElement i)
                    ? i.GetString() ?? "Unknown"
                    : "Unknown";

                Console.Write("Country: ");
                ConsoleWriteColor(ConsoleColor.Green, country);

                Console.Write("Region: ");
                ConsoleWriteColor(ConsoleColor.Cyan, region);

                Console.Write("City: ");
                ConsoleWriteColor(ConsoleColor.Cyan, city);

                Console.Write("ISP: ");
                ConsoleWriteColor(ConsoleColor.Magenta, isp);
            }
            else
            {
                ConsoleWriteColor(
                    ConsoleColor.Red,
                    "Ip Address Not Found"
                );
            }
        }
        catch (Exception ex)
        {
            ConsoleWriteColor(
                ConsoleColor.Red,
                "Catch Error On Main"
            );
            Console.WriteLine(ex.ToString());
        }
    }

    static void ShowHelp()
    {
        ConsoleWriteColor(ConsoleColor.Green, "Help message");
    }
}