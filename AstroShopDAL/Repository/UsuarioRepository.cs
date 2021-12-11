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
    public class UsuarioRepository : IUsuarioRepository
    {

        dbContext db;
        public UsuarioRepository(dbContext _db)
        {
            db = _db;
        }

        public async Task<List<Usuario>> GetAllUsuarios(int id)
        {
            return await db.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await db.Usuarios.FirstOrDefaultAsync(x => x.UsuarioID == id);
        }


    } 
}
