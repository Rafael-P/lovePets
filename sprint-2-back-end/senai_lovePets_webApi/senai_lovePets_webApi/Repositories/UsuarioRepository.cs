using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            if (usuarioAtualizado.IdTipoUsuario > 0)
            {
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.Find(idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Busca um usuário existente através do seu e-mail e sua senha
        /// </summary>
        /// <param name="email">O valor do e-mail digitado pelo usuário</param>
        /// <param name="senha">O valor da senha digitada pelo usuário</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

    }
}
