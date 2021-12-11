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
    public class PublicacionController : ControllerBase
    {
        private dbContext _dbContext;
        IPublicacionRepository _publicacionRepository;
        public PublicacionController(IPublicacionRepository publicacionRepository, dbContext context)
        {
            this._dbContext = context;
            this._publicacionRepository = publicacionRepository;
        }

        [HttpGet("{PublicacionID}")]
        public async Task<IActionResult> Get(int PublicacionID)
        {
            WSData dataResp = new WSData { Status = "200" };
            
            if(PublicacionID == 0)
            {
                dataResp.Status = "400";
                dataResp.ErrMessage = "No se informo parámetro obligatorio";
                return Ok(dataResp);
            }

            try
            {
                Publicacion item = await this._publicacionRepository.GetByPublicacionID(PublicacionID);

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
