using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using File.Domain;
using File.Infrastructure;

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagersController : ControllerBase
    {
        private readonly FileRepository repository;

        public FileManagersController(FileContext context)
        {
            repository = new FileRepository(context);
        }

        // GET: api/FileManagers
        [HttpGet]
        public async Task<List<FileManager>> GetFilesAsync()
        {
            return await repository.GetAllFilesAsync();
        }

        // GET: api/FileManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileManager>> GetFileManagerAsync(Guid id)
        {
            var fileManager = await repository.GetByIdFileAsync(id);

            if (fileManager == null)
            {
                return NotFound("File is not exist");
            }
            // инициализация подгрузки с гридФС
            return fileManager;
        }

        // PUT: api/FileManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileManagerAsync(Guid id, FileManager fileManager)
        {
            if (id != fileManager.Id)//неправльно//
            {
                return BadRequest();
            }
            await repository.UpdateFileAsync(fileManager);
            return NoContent();
        }

        // POST: api/FileManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileManager>> PostFileManagerAsync(FileManager fileManager)
        {
            await repository.AddFileAsync(fileManager);
            return CreatedAtAction("GetFileManager", new { id = fileManager.Id }, fileManager);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFileManagerRange(List<Guid> ids)
        {
            List<Guid> NoneDeleteGuid = new();
            int i = 0;
            try
            {
                for (; i < ids.Count; i++)
                {
                    await repository.DeleteFileAsync(ids[i]);
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
                await repository.DeleteFileAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
