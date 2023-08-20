using Ratsatak.Application.Common.CommandQueryInterfaces;

namespace Ratsatak.Application.Common.Helpers;

public interface IFileHelper
{
        Task SaveFileToFileSystemAsync(IFileCommand command,
                CancellationToken cancellationToken);
}