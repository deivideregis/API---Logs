using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class ListaSistemaRepository : Repository<ListaSistema>
    {
        public ListaSistemaRepository(MeuDbContext context) : base(context) { }

        public async Task<ListaSistema> ObterListaSistema(Guid id)
        {
            return await Db.ListaSistemas.AsNoTracking()
                .Include(c => c.Id)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
