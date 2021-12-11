using AstroShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroShopDAL.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuarios(int id);
        Task<Usuario> GetUsuarioById(int id);

    }
}
