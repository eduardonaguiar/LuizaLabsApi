using LuizaLabs.Domain.Core.Interfaces;
using LuizaLabs.Infra.Data.Context;

namespace Equinox.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LuizaLabsContext _context;

        public UnitOfWork(LuizaLabsContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
