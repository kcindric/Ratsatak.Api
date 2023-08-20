using Microsoft.Extensions.Configuration;
using Ratsatak.Application.Common.CommandQueryInterfaces;

namespace Ratsatak.Application.Common.Helpers;

public class FileHelper : IFileHelper
{
    private readonly string? _pdfPath;

    public FileHelper(IConfiguration configuration)
    {
        var settings = configuration.GetSection("GeneralConfig");

        _pdfPath = settings["PdfPath"];
    }

    public async Task SaveFileToFileSystemAsync(IFileCommand command, CancellationToken cancellationToken)
    {
        if (command.File is null) return;

        var directoryPath = Path.GetDirectoryName($"{_pdfPath}{command.FilePath!}");
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath!);

        using var fileStream = new FileStream($"{_pdfPath}{command.FilePath!}", FileMode.Create);
        using var memoryStream = new MemoryStream(command.File);
        await memoryStream.CopyToAsync(fileStream, cancellationToken);
    }
}