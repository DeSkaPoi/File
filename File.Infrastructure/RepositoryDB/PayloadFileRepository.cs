﻿using File.Infrastructure.DBModel;
using File.Infrastructure.ContextDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File.Infrastructure.RepositoryDB
{
    public class PayloadFileRepository : IPayloaadFileRepository
    {
        private readonly FileContext _context;
        public PayloadFileRepository(FileContext context)
        {
            _context = context;
        }

        public async Task<PayloadFileDataBase> GetByIdPayloadFileAsync(Guid idFile)
        {
            return await _context.PayloadFile.FirstOrDefaultAsync(fp => fp.Id == idFile);
        }

        public async Task<Guid> AddPayloadFileAsync(PayloadFileDataBase file)
        {
            var newFile = await _context.PayloadFile.AddAsync(file);
            await _context.SaveChangesAsync();
            return newFile.Entity.Id;
        }

        public async Task DeleteFileAsync(Guid idFile)
        {

            var delFile = await _context.PayloadFile.FindAsync(idFile);
            _context.PayloadFile.Remove(delFile);
            await _context.SaveChangesAsync();
        }
    }
}
