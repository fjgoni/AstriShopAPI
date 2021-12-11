using AstroShop.Model;
using AstroShop.Model.Modelos;
using AstroShopDAL;
using AstroShopDAL.Context;
using AstroShopDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransaccionController : ControllerBase
    {
        private dbContext _dbContext;
        ITransaccionRepository _transaccionRepository;
        public TransaccionController(ITransaccionRepository transaccionRepository, dbContext context)
        {
            this._dbContext = context;
            this._transaccionRepository = transaccionRepository;
        }

        [HttpGet("{TransaccionID}")]
        public async Task<IActionResult> Get(int TransaccionID)
        {
            WSData dataResp = new WSData { Status = "200" };
            
            if(TransaccionID == 0)
            {
                dataResp.Status = "400";
                dataResp.ErrMessage = "No se informo parámetro obligatorio";
                return Ok(dataResp);
            }

            try
            {
                Transaccion item = await this._transaccionRepository.GetTransaccionById(TransaccionID);

                if (item == null)
                {
                    dataResp.Status = "404";
                    dataResp.ErrMessage = "No se encontraron registros";
                    return Ok(dataResp);
                }

                dataResp.Data = JsonConvert.SerializeObject(item);
                return Ok(dataResp);
            }
            catch (Exception ex)
            {
                dataResp.Status = "400";
                dataResp.ErrMessage = ex.Message;
                return Ok(dataResp);
            }

        }

        
    }
}
