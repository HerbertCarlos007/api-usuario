using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users.Data;
using users.Model;

namespace users.Repository {
    public class UsuarioRepository : IUsuarioRepository {

        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context) {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioModel>> BusucaUsuarios() {
            
            return await _context.Usuarios.ToListAsync();   
        }

        public async Task<UsuarioModel> BuscaUsuario(int id) {

            return await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AdicionaUsuario(UsuarioModel usuario) {
            _context.Add(usuario);

        }

        public void AtualizaUsuario(UsuarioModel usuario) {
           _context.Update(usuario);
        }

        public void DeletaUsuario(UsuarioModel usuario) {
            _context.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync() {

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
