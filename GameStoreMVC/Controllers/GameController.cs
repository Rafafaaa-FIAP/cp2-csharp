using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using GameStoreMVC.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepositorio _gameRepositorio;

        public GameController(IGameRepositorio gameRepositorio)
        {
            _gameRepositorio = gameRepositorio;
        }

        public IActionResult Index()
        {
            var jogos = _gameRepositorio.ListarTudo();
            return View(jogos);
        }

        [HttpGet]
        public IActionResult CadastrarJogo()
        {
            return View("Criar", new Game());
        }


        [HttpPost]
        public IActionResult CadastrarJogo(Game gmmodel)
        {
            if (!ModelState.IsValid) return View(gmmodel);

            var jogo = new Game
            {
                Nome = gmmodel.Nome,
                Descricao = gmmodel.Descricao,
                Dificuldade = gmmodel.Dificuldade,
            };

            _gameRepositorio.CadastrarJogo(jogo);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult EditarJogo(int id)
        {
         
            var jogo = _gameRepositorio.ObterId(id);
           
            if (jogo == null) return NotFound();

           
            var viewModel = new Game
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Descricao = jogo.Descricao,
                Dificuldade = jogo.Dificuldade,
            };
        

            return View("Criar", viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult EditarJogo(int id, Game gmmodel)
        {
            if (id != gmmodel.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var jogo = new Game
                {
                    Id = gmmodel.Id,
                    Nome = gmmodel.Nome,
                    Descricao = gmmodel.Descricao,
                    Dificuldade = gmmodel.Dificuldade,
                };
                _gameRepositorio.EditarJogo(jogo);
            }
           
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirJogo(int id)
        {
            _gameRepositorio.ExcluirJogo(id);
            return RedirectToAction(nameof(Index));
        }

    }
}