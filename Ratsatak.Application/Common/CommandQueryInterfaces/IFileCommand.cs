namespace Ratsatak.Application.Common.CommandQueryInterfaces;

public interface IFileCommand
{
    byte[]? File { get; }
    string? FileName { get; }
    string? FilePath { get; }
}