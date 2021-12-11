﻿using AstroShop.Model;
using AstroShopDAL.Context;
using AstroShopDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroShopDAL
{
    public class ConceptoRepository : IConceptoRepository
    {

        dbContext db;
        public ConceptoRepository(dbContext _db)
        {
            db = _db;
        }

        public async Task<Concepto> GetByConceptoID(int conceptoID)
        {
            var concepto = await db.Conceptos.Include("Vendedor").FirstOrDefaultAsync(x => x.ConceptoID == conceptoID);
            db.Entry(concepto).Reference(u => u.Vendedor).Load();
            return concepto;
        }

     
    }
} 
