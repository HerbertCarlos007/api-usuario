using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using users.Model;

namespace users.Repository {
    public interface IUsuarioRepository {

        Task<IEnumerable<UsuarioModel>> BusucaUsuarios();

        Task<UsuarioModel> BuscaUsuario(int id);

        void AdicionaUsuario(UsuarioModel usuario);
        void AtualizaUsuario(UsuarioModel usuario);
        void DeletaUsuario(UsuarioModel usuario);

        Task<bool> SaveChangesAsync();

    }
}
