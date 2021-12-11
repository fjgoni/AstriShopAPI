using AstroShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroShopDAL.Interfaces
{
    public interface ITransaccionRepository
    {
        Task<List<Transaccion>> GetAllTransacciones(int id);
        Task<Transaccion> GetTransaccionById(int id);

    }
}
