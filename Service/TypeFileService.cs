using Models;
using RepositoryContracts;
using ServiceContracts;

namespace Service
{
    public class TypeFileService : ITypeFileService
    {
        private readonly ITypeFileRepository _typeFileRepository;

        public TypeFileService(ITypeFileRepository typeFileRepository)
        {
            _typeFileRepository = typeFileRepository;
        }

        public async Task<GetTypeFile> GetTypeFile(int id)
        {
            return new GetTypeFile();
        }

        public async Task<IEnumerable<GetTypeFile>> GetTypeFiles()
        {
            return new List<GetTypeFile> { };
        }

        public async Task<string> SetTypeFile(SetTypeFile typeFile)
        {
            return await _typeFileRepository.SetTypeFile(typeFile);
        }
    }
}