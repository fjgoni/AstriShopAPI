using AstroShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroShopDAL.Interfaces
{
    public interface IConceptoRepository
    {
        Task<Concepto> GetByConceptoID(int publicacionID);
    }
}
