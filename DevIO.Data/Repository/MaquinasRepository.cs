using System;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class MaquinaRepository : Repository<Maquina>, IMaquinaRepository
    {
        public MaquinaRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Maquina> ObterMaquinaLog(Guid id)
        {
            return await Db.Maquina.AsNoTracking()
                .Include(c => c.Logs)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
