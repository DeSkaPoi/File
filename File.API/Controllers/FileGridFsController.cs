using File.Domain;
using File.Infrastructure.DataBaseFile;
using File.Infrastructure.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using File.API.ErrorResponses;
using MongoDB.Bson;

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagersController : ControllerBase
    {
        private readonly IFileRepository _repository;
        private readonly IContextFileData _contextFileData;
        public FileManagersController(IFileRepository repository, IContextFileData contextFileData)
        { 
            _repository = repository;
            _contextFileData = contextFileData;
        }

        // GET: api/FileManagers
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FileManager>>> GetFilesAsync()
        {
            try
            {
                var file = await _repository.GetAllFilesAsync();
                var action = new ActionResult<IReadOnlyList<FileManager>>(file);
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
        public async Task<ActionResult<FileManager>> GetFileAsync(Guid id)
        {
            var fileManager = await _repository.GetByIdFileAsync(id);
            if (fileManager == null)
            {
                var errorResponse = new ErrorResponse($"Not found {id}");
                return StatusCode(404, errorResponse);
            }
            return fileManager;
        }

        // PUT: api/FileManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileManagerAsync(Guid id, FileManager fileManager)
        {
            if (id != fileManager.Id)//неправльно//
            {
                var errorResponse = new ErrorResponse("Bad request: no match between id and object");
                return StatusCode(400, errorResponse);
            }
            try
            {
                await _repository.UpdateFileAsync(fileManager);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        // POST: api/FileManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileManager>> PostFileManagerAsync(FileManager fileManager)
        {
            try
            {
                await _repository.AddFileAsync(fileManager);
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
            var NoneDeleteGuid = new List<Guid>();
            int i = 0;
            try
            {
                for (; i < ids.Count; i++)
                {
                    await _repository.DeleteFileAsync(ids[i]);
                }
            }
            catch (Exception)
            {
                NoneDeleteGuid.Add(ids[i]);
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
                await _repository.DeleteFileAsync(id);
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
