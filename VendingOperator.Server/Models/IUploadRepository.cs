using VendingOperator.Shared.Data;
using VendingOperator.Shared.Models;

namespace VendingOperator.Server.Models
{
    public interface IUploadRepository
    {
        PagedResult<Upload> GetUploads(string? name, int page);
        Task<Upload?> GetUpload(int Id);
        Task<Upload> AddUpload(Upload upload);
        Task<Upload?> UpdateUpload(Upload upload);
        Task<Upload?> DeleteUpload(int id);
    }
}