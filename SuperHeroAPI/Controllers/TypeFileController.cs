using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFileController : ControllerBase
    {
        private readonly ITypeFileService _typeFileService;
        private readonly ILogger<TypeFileController> _logger;

        public TypeFileController(
            ILogger<TypeFileController> logger,
            ITypeFileService typeFileService)
        {
            _logger = logger;
            _typeFileService = typeFileService;
        }

        [HttpGet]
        [Route("GetTypeFile/{id}")]
        public async Task<GetTypeFile> GetTypeFile(int id)
        {
            return await _typeFileService.GetTypeFile(id);
        }

        [HttpGet]
        [Route("GetAllTypeFiles")]
        public async Task<IEnumerable<GetTypeFile>> GetAllTypeFiles()
        {
            return await _typeFileService.GetTypeFiles();
        }

        [HttpPost]
        [Route("SetTypeFile")]
        public async Task<string> SetTypeFiles(SetTypeFile setTypeFile)
        {
            return await _typeFileService.SetTypeFile(setTypeFile);
        }
    }
}
