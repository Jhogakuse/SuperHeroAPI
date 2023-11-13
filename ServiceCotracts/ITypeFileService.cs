using Models;

namespace ServiceContracts
{
    public interface ITypeFileService
    {
        Task<IEnumerable<GetTypeFile>> GetTypeFiles();
        Task<GetTypeFile> GetTypeFile(int id);
        Task<string> SetTypeFile(SetTypeFile typeFile);
    }
}