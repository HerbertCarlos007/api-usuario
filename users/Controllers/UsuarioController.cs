using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users.Model;
using users.Repository;

namespace users.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase {

        private readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository respository) {

            _repository = respository;
        }

        public IUsuarioRepository Repository { get; }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var usuarios = await _repository.BusucaUsuarios();
            return usuarios.Any()
                ? Ok(usuarios)
                : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var usuario = await _repository.BuscaUsuario(id);
            return usuario != null
                ? Ok(usuario)
                : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioModel usuario) {
            _repository.AdicionaUsuario(usuario);

            return await _repository.SaveChangesAsync()
                ? Ok("Usuário adicionado com sucesso") : BadRequest("Erro ao salvar o usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsuarioModel usuario) {

            var usuarioBanco = await _repository.BuscaUsuario(id);
            if (usuarioBanco == null) return NotFound("Usuário não encontrado");

            usuarioBanco.Nome = usuario.Nome ?? usuarioBanco.Nome;
            usuarioBanco.DataNascimento = usuario.DataNascimento != new DateTime()
                ? usuario.DataNascimento : usuarioBanco.DataNascimento;

            _repository.AtualizaUsuario(usuarioBanco);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário atualizado com sucesso")
                : BadRequest("Erro ao atualizar o usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var usuarioBanco = await _repository.BuscaUsuario(id);
            if (usuarioBanco == null) return NotFound("Usuário não encontrado");

            _repository.DeletaUsuario(usuarioBanco);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário deletado com sucesso")
                : BadRequest("Erro ao deletar o usuário");
        }
    }
}
