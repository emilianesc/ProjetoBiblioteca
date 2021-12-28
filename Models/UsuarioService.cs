using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.ToList();
            }
        }
        public Usuario Listar(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.Find(id);
            }
        }
        public void incluirUsuario(Usuario user)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Add(user);
                bc.SaveChanges();
            }
        }
        public void editarUsuario(Usuario EditUser)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario oldUser = bc.Usuario.Find(EditUser.Id);

                oldUser.Nome = EditUser.Nome;
                oldUser.Login = EditUser.Login;
                oldUser.Senha = EditUser.Senha;
                oldUser.Tipo = EditUser.Tipo;

                bc.SaveChanges();
            }
        }
        public void excluirUsuario(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuario.Remove(bc.Usuario.Find(id));
                bc.SaveChanges();
            }
        }
    }
}