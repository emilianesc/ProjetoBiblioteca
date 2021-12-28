using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        
        // Listagem
        public IActionResult ListaUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            return View(new UsuarioService().Listar());
        }

        //Cadastro
        public IActionResult RegistrarUsuario()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuario newUser)
        {
            newUser.Senha = Criptografo.TextoCriptografado(newUser.Senha);
            new UsuarioService().IncluirUsuario(newUser);
            return RedirectToAction("CadastroRealizado");

        }

        // Edição

        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Usuario user = new UsuarioService().Listar(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEdit)
        {
            new UsuarioService().EditarUsuario(userEdit);
            return RedirectToAction("ListaUsuarios");
        }
        // Exclusão

        public IActionResult ExcluirUsuario(int id)
        {
            return View(new UsuarioService().Listar(id));
        }

        [HttpPost]
        public IActionResult ExcluirUsuario(string decisao, int id)
        {
            if (decisao == "EXCLUIR")
            {
                ViewData["Mensagem"] = "Exclusão do usuário" + new UsuarioService().Listar(id).Nome + "realizado com sucesso!";
                new UsuarioService().ExcluirUsuario(id);
                return View("ListaUsuarios", new UsuarioService().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Exclusão cancelada";
                return View("ListaUsuarios", new UsuarioService().Listar());
            }
        }
        public IActionResult CadastroRealizado()
        {
            return View();
        }
        
        // Funções extras
        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult NeedAdmin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }
    }
}