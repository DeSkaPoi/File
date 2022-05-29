using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using File.Domain.Model;
using FileManagement.Services;
using File.API.Converts;
using File.API.ModelResponses;
using File.Domain.ModelResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Drawing;

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileObjectController : ControllerBase
    {
        private readonly IFileObjectService _service;
        public FileObjectController(IFileObjectService service)
        {
            _service = service;
        }

        // GET: api/FileObject/id
        [HttpGet("{id}")]
        public async Task<ActionResult<FileObjectResponse>> GetFileObjectAsync(Guid id)
        {
            try
            {
                var fileManager = await _service.GetFileObjectAsync(id);
                var response = fileManager.ConvertToResponse();
                return response;
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
        }

        // PUT: api/FileManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idFile}")]
        public async Task<IActionResult> PutFileObjectAsync([FromForm]IFormFile file, Guid idFile)
        {
            try
            {
                var fileStream = file.OpenReadStream();
                using var ms = new MemoryStream();
                await fileStream.CopyToAsync(ms);
                var fileObject = new FileObject(idFile, file.FileName, ms.ToArray(), file.ContentType);
                await _service.ChangeFileObjectAsync(fileObject);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("{idFile}")]
        public async Task<IActionResult> PostFileManagerAsync(IFormFile file, Guid idFile)
        {
            try
            {
                var fileStream = file.OpenReadStream();
                using var ms = new MemoryStream();
                await fileStream.CopyToAsync(ms);
                var fileObject = new FileObject(idFile, file.FileName, ms.ToArray(), file.ContentType);
                await _service.AddFileObjectAsync(fileObject);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }
    }
}
