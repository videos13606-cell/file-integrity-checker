using System.Security.Cryptography;
using System.Text.Json;

string storageFile = "hashes.json";
string command = args.Length > 0 ? args[0].ToLower() : "";

if (command == "init")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Error: Please provide a directory path.");
        return;
    }

    string dirPath = args[1];
    if (!Directory.Exists(dirPath))
    {
        Console.WriteLine($"Error: Directory not found: {dirPath}");
        return;
    }

    string[] files = Directory.GetFiles(dirPath);
    var hashes = new Dictionary<string, string>();

    foreach (string file in files)
    {
        byte[] fileBytes = File.ReadAllBytes(file);
        byte[] hashBytes = SHA256.HashData(fileBytes);
        hashes[file] = Convert.ToHexString(hashBytes).ToLowerInvariant();
    }

    string jsonString = JsonSerializer.Serialize(hashes, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(storageFile, jsonString);
    Console.WriteLine($"Hashes stored successfully for {files.Length} file(s).");
}

else if (command == "check")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Error: Please provide a file path.");
        return;
    }

    string filePath = args[1];
    if (!File.Exists(filePath))
    {
        Console.WriteLine($"Error: File not found: {filePath}");
        return;
    }

    if (!File.Exists(storageFile))
    {
        Console.WriteLine("Error: No baseline hashes found. Run 'init' first.");
        return;
    }

    string jsonString = File.ReadAllText(storageFile);
    var storedHashes = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

    if (storedHashes == null || !storedHashes.ContainsKey(filePath))
    {
        Console.WriteLine($"Error: No baseline hash found for: {filePath}");
        return;
    }

    byte[] fileBytes = File.ReadAllBytes(filePath);
    byte[] hashBytes = SHA256.HashData(fileBytes);
    string currentHash = Convert.ToHexString(hashBytes).ToLowerInvariant();
    string baselineHash = storedHashes[filePath];

    if (currentHash == baselineHash)
    {
        Console.WriteLine("Status: Unmodified");
    }
    else
    {
        Console.WriteLine("Status: Modified (Hash mismatch)");
    }
}

else if (command == "update")
{
    if (args.Length < 2)
    {
        Console.WriteLine("Error: Please provide a file path.");
        return;
    }

    string filePath = args[1];
    if (!File.Exists(filePath))
    {
        Console.WriteLine($"Error: File not found: {filePath}");
        return;
    }

    if (!File.Exists(storageFile))
    {
        Console.WriteLine("Error: No baseline hashes found. Run 'init' first.");
        return;
    }

    string jsonString = File.ReadAllText(storageFile);
    var storedHashes = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString) ?? new Dictionary<string, string>();

    byte[] fileBytes = File.ReadAllBytes(filePath);
    byte[] hashBytes = SHA256.HashData(fileBytes);
    storedHashes[filePath] = Convert.ToHexString(hashBytes).ToLowerInvariant();

    string updatedJson = JsonSerializer.Serialize(storedHashes, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(storageFile, updatedJson);
    Console.WriteLine("Hash updated successfully.");
}

else
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  dotnet run init <directory>     - Store hashes of all files");
    Console.WriteLine("  dotnet run check <file>         - Check if file was modified");
    Console.WriteLine("  dotnet run update <file>        - Update stored hash for file");
}
