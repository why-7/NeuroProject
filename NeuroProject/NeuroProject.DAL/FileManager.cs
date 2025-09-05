using System.Security.Cryptography;

namespace NeuroProject.DAL;

public static class FileManager
{
    public static async Task<string> SaveFile(byte[] fileBytes)
    {
        var hash = GetHash(fileBytes);
        var path = "../NeuroProject.DAL/Files/" + hash;
        if (!File.Exists(path))
        {
            await File.WriteAllBytesAsync(path, fileBytes);
        }
            
        return hash;
    }
        
    public static string GetHash(byte[] uploadedFileBytes)
    {
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(uploadedFileBytes);
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }
}