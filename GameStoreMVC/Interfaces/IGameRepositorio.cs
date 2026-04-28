using GameStoreMVC.Models;

namespace GameStoreMVC.Interfaces
{
    public interface IGameRepositorio
    {
        //Promete que haverá uma função para devolver uma lista de todos os clientes cadastrados.
        IEnumerable<Game> ListarTudo();

        //? significa que ela pode devolver o cliente ou "nada" (nulo), caso ele não exista.
        Game? ObterId(int id);

        void CadastrarJogo(Game jogo);

        void EditarJogo(Game jogo);

        void ExcluirJogo(int id);

    }
}