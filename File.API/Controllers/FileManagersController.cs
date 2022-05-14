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

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagersController : ControllerBase
    {
        private readonly IFileServices _service;
        public FileManagersController(IFileServices service)
        {
            _service = service;
        }

        // GET: api/FileManagers
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FileInfoResponse>>> GetFilesAsync()
        {
            try
            {
                var file = await _service.GetFilesAsync();
                var action = new ActionResult<IReadOnlyList<FileInfoResponse>>(file.ConvertToModel());
                return action;
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
        }

        // GET: api/FileManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileInfoResponse>> GetFileAsync(Guid id)
        {
            var fileManager = await _service.GetFileAsync(id);
            if (fileManager == null)
            {
                var errorResponse = new ErrorResponse($"Not found {id}");
                return StatusCode(404, errorResponse);
            }

            var response = fileManager.ConvertToResponse();
            return response;
        }

        // PUT: api/FileManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileManagerAsync(Guid id, FileInfoResponse fileManager)
        {
            try
            {
                var payloadRequests = fileManager.ConvertToModel();
                await _service.ChangeFileAsync(id, payloadRequests);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FileInfoResponse>> PostFileManagerAsync(FileInfoResponse fileManager)
        {
            try
            {
                var payloadRequests = fileManager.ConvertToModel();
                await _service.AddFileAsync(payloadRequests);
                return StatusCode(201, fileManager);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFileManagerRange(List<Guid> ids)
        {
            IReadOnlyList<Guid> NoneDeleteGuid = new List<Guid>();
            int i = 0;
            try
            {
               NoneDeleteGuid = await _service.DeleteFiles(ids);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
            
            if (NoneDeleteGuid.Count != 0)
            {
                return NotFound(NoneDeleteGuid);
            }
            return NoContent();
        }

        // DELETE: api/FileManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileManager(Guid id)
        {
            try
            {
                await _service.DeleteFile(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
        }
    }
}
