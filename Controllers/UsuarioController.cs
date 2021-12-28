using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        
        // Listagem
        public IActionResult listaUsuario()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService user = new UsuarioService();

            return View(user.Listar());
        }

        //Cadastro
        public IActionResult registrarUsuario()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService user = new UsuarioService();
            return View();
        }

        [HttpPost]
        public IActionResult registrarUsuario(Usuario newUser)
        {
            newUser.Senha = Criptografo.TextoCriptografado(newUser.Senha);
            new UsuarioService().incluirUsuario(newUser);
            return RedirectToAction("CadastroRealizado");

        }

        // Edição

        public IActionResult editarUsuario(int id)
        {
            Usuario user = new UsuarioService().Listar(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult editarUsuario(Usuario userEdit)
        {
            new UsuarioService().editarUsuario(userEdit);
            return RedirectToAction("listaUsuarios");
        }
        // Exclusão

        public IActionResult excluirUsuario(int id)
        {
            return View(new UsuarioService().Listar(id));
        }

        [HttpPost]
        public IActionResult excluirUsuario(string decisao, int id)
        {
            if (decisao == "EXCLUIR")
            {
                ViewData["Mensagem"] = "Exclusão do usuário" + new UsuarioService().Listar(id).Nome + "realizado com sucesso!";
                new UsuarioService().excluirUsuario(id);
                return View("listaUsuarios", new UsuarioService().Listar());
            }
            else
            {
                ViewData["Mensagem"] = "Exclusão cancelada";
                return View("listaUsuarios", new UsuarioService().Listar());
            }
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