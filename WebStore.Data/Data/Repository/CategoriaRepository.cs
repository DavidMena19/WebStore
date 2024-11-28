using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreMODEL.AccesoDeDatos.Data.Repository.IRepository;
using WebStoreMODEL.Data;
using WebStoreMODEL.Models;

namespace WebStoreMODEL.AccesoDeDatos.Data.Repository
{
    internal class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Categoria categoria)
        {

            var registroEnBd = _context.Categoria.FirstOrDefault(u => u.Id == categoria.Id);

            registroEnBd.Nombre = categoria.Nombre;
            registroEnBd.Orden = categoria.Orden;

            _context.SaveChanges();

        }
    }
}
