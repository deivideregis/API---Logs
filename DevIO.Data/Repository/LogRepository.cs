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
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(MeuDbContext context) : base(context) { }

        public async Task<Log> ObterLogPorMaquina(Guid maquinaId)
        {
            return await Db.Logs.AsNoTracking()
                .FirstOrDefaultAsync(f => f.MaquinaId == maquinaId);
        }
    }
}
