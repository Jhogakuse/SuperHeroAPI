using Models;
using ServiceContracts;

namespace Service
{
    public class TypeFileService : ITypeFileService
    {
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
            return "1";
        }
    }
}