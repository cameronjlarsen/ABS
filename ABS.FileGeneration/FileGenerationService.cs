using ClosedXML.Excel;

namespace ABS.FileGeneration
{
    public class FileGenerationService
    {
        public Task<FileStream> GenerateFile()
        {
            try
            {
                // Create a directory to save the file to
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Create the file
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A1").Value = "Hello World!";

                // Save the file to the directory
                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;

                // Return the file stream
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
                return Task.FromResult(fileStream);
            }
            catch (Exception ex)
            {
                // Log exception and throw to handle in calling code
                Console.WriteLine("Exception:", ex);
                throw;
            }
        }
    }
}
