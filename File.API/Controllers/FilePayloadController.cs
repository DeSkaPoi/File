using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using File.Domain.Model;
using File.API.Converts;
using File.API.ModelResponses;
using File.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilePayloadController : ControllerBase
    {
        private readonly IPayloadFileService _fileService;
        public FilePayloadController(IPayloadFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("file/{id}")]
        public async Task<ActionResult<PayloadFileResponse>> GetFileObjectAsync(Guid id)
        {
            try
            {
                var fileManager = await _fileService.GetPayloadFileAsync(id);
                var response = fileManager.ConvertToResponse();
                return response;
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
        }

        [HttpPost("file/{idFile}")]
        public async Task<IActionResult> PostFileObjectAsync(Guid idFile, PayloadFileResponse payload)
        {
            try
            {
                var modelPayload = payload.ConvertToModel();
                await _fileService.AddFileAsync(idFile, modelPayload );
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(404, errorResponse);
            }
        }

        // PUT: api/FileManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("file/{idFile}")]
        public async Task<IActionResult> PutFileManagerAsync(Guid idFile, PayloadFileResponse payloadFile)
        {
            try
            {
                var payloadRequests = payloadFile.ConvertToModel();
                await _fileService.ChangeFileAsync(idFile, payloadRequests);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        // DELETE: api/FileManagers/5
        [HttpDelete("{idFile}")]
        public async Task<IActionResult> DeleteFileManagerAsync(Guid idFile)
        {
            try
            {
                await _fileService.DeleteFileAsync(idFile);
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
