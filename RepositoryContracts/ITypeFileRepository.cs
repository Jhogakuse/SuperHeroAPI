using Entities;
using Models;

namespace RepositoryContracts
{
    public interface ITypeFileRepository
    {
        Task<IEnumerable<TypeFileEntity>> GetTypeFiles();
        Task<TypeFileEntity> GetTypeFile(int id);
        Task<string> SetTypeFile(SetTypeFile typeFile);
    }
}