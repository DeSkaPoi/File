using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using File.Domain.Model;
using FileManagement.Services;
using File.API.Converts;
using File.API.ModelResponses;
using File.Domain.ModelResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileObjectController : ControllerBase
    {
        private readonly IFileServices _service;
        public FileObjectController(IFileServices service)
        {
            _service = service;
        }

        /*[HttpGet]
        public async Task<ActionResult<IReadOnlyList<FileObjectResponse>>> GetFilesObjectsAsync()
        {
            try
            {
                var file = await _service.GetFilesObjectsAsync();
                var action = new ActionResult<IReadOnlyList<FileObjectResponse>>(file.ConvertToModel());
                return action;
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
        }*/

        // GET: api/FileManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileObjectResponse>> GetFileObjectAsync(Guid id)
        {
            var fileManager = await _service.GetFileAsync(id);
            if (fileManager == null)
            {
                var errorResponse = new ErrorResponse($"Not found {id}");
                return StatusCode(404, errorResponse);
            }

            var response = fileManager.FileObj.ConvertToResponse();
            return response;
        }

        // PUT: api/FileManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idFileInfo}")]
        public async Task<IActionResult> PutFileManagerAsync(Guid idFileInfo, IFormFile file)
        {
            try
            {
                var fileManager = await _service.GetFileAsync(idFileInfo);
                if (fileManager == null)
                {
                    var errorResponse = new ErrorResponse($"Not found {idFileInfo}");
                    return StatusCode(404, errorResponse);
                }

                var fileStream = file.OpenReadStream();
                using var ms = new MemoryStream();
                await fileStream.CopyToAsync(ms);
                await _service.ChangeFileObjectAsync(fileManager.Id, ms);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("{idFileInfo}")]
        public async Task<ActionResult<FileResponse>> PostFileManagerAsync(Guid idFileInfo, IFormFile file)
        {
            try
            {
                var fileStream = file.OpenReadStream();
                using var ms = new MemoryStream();
                await fileStream.CopyToAsync(ms);
                await _service.AddFileObjectAsync(idFileInfo, ms);
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
