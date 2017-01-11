using API.RareCarat.Example.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.RareCarat.Example.Services
{
    public class DiamondService : IDiamondService
    {
        private IRetailerDBContext _context;
        private DbSet<Diamond> _dbset;

        public DiamondService(IRetailerDBContext context)
        {
            _context = context;
            _dbset = _context.Set<Diamond>();
        }

        public IEnumerable<Diamond> GetAll()
        {
            return _context.Diamonds.FromSql("SELECT * FROM vwDiamonds");
        }
    }
    public interface IDiamondService
    {
        IEnumerable<Diamond> GetAll();
    }
}
