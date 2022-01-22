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
    public class PublicacionRepository : IPublicacionRepository
    {

        dbContext db;
        public PublicacionRepository(dbContext _db)
        {
            db = _db;
        }

        public async Task<List<Publicacion>> GetAllPublicaciones()
        {
            return await db.Publicaciones.Include("Concepto").ToListAsync();
        }

        public async Task<Publicacion> GetByPublicacionID(int publicacionID)
        {
            var publicacion =  await db.Publicaciones
                .Include("Concepto")
                .FirstOrDefaultAsync(x => x.PublicacionID == publicacionID);
            db.Entry(publicacion).Reference(u => u.Concepto).Load();
            return publicacion;
        }
    }
} 
