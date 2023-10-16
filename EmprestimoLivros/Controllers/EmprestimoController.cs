using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private AppDbContext _dbContext;
        
        public EmprestimoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;    
        }

        public IActionResult Index()
        {
            List<EmprestimoModel> emprestimos = _dbContext.Emprestimos.ToList();
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo = _dbContext.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }



        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Emprestimos.Add(emprestimos);
                _dbContext.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Emprestimos.Update(emprestimo);
                _dbContext.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar a edição!";

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimoModel emprestimo  = _dbContext.Emprestimos.FirstOrDefault(X => X.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);

        }

        [HttpPost]
        public IActionResult Excluir(EmprestimoModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _dbContext.Remove(emprestimo);
            _dbContext.SaveChanges();
            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
