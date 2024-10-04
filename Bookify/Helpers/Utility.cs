namespace Bookify.Helpers;

public static class Utility
{
    public static string UploadFile(IFormFile file, string folderName)
    {
        // Get located folder path
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
        // Get filename and make it unique
        string fileName = $"{DateTime.Now:ddMMyyyy}{Guid.NewGuid()}{file.FileName}";
        // Get file path
        string filePath = Path.Combine(folderPath, fileName);
        // save file as streams
        using var fileStream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fileStream);
        // Return fileName
        return fileName;
    }

    public static void DeleteFile(string fileName, string folderName)
    {
        // check there is a file with fileName and there is exist a folder called folderName
        if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folderName))
            return;
        // Get file path
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName, fileName);
        if (!File.Exists(filePath))
            return;
        // delete the file
        File.Delete(filePath);
    }
}
