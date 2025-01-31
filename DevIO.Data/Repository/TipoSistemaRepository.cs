﻿using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class TipoSistemaRepository : Repository<TipoSistema>
    {
        public TipoSistemaRepository(MeuDbContext context) : base(context) { }

        public async Task<TipoSistema> ObterTipoSistema(Guid id)
        {
            return await Db.TipoSistema.AsNoTracking()
                .Include(c => c.Id)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
