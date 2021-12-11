using AstroShop.Model;
using AstroShopDAL.Context;
using AstroShopDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroShopDAL
{
    public class TransaccionRepository : ITransaccionRepository
    {

        dbContext db;
        public TransaccionRepository(dbContext _db)
        {
            db = _db;
        }

        public Task<List<Transaccion>> GetAllTransacciones(int transaccionIDd)
        {
            throw new NotImplementedException();
        }

  

        public async Task<Transaccion> GetTransaccionById(int transaccionID)
        {
            var transaccion = await db.Transacciones
                .Include("Concepto")
                .Include("Comprador")
                .FirstOrDefaultAsync(x => x.TransaccionID == transaccionID);
            db.Entry(transaccion).Reference(u => u.Comprador).Load();
            db.Entry(transaccion).Reference(u => u.Concepto).Load();
            return transaccion;
        }
    }
} 
