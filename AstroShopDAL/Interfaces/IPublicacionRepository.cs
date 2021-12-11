using AstroShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroShopDAL.Interfaces
{
    public interface IPublicacionRepository
    {
        Task<Publicacion> GetByPublicacionID(int publicacionID);
    }
}
