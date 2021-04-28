using System.Collections.Generic;
using System.Linq;

namespace THWebApi
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        Player Get(int id);
        int Add(Player player);
    }

    class PlayerRepository : IPlayerRepository
    {
        private static List<Player> list = new[]
        {
            new Player {Age = 47,Born="Örnsköldsvik",Id = 1,Jersey = 21, Namn = "Peter Forsberg"},
            new Player {Age = 49,Born="Stockholm",Id = 2,Jersey = 13, Namn = "Mats Sundin"}
        }.ToList();

        public IEnumerable<Player> GetAll()
        {
            return list;
        }

        public Player Get(int id)
        {
            return GetAll().FirstOrDefault(r => r.Id == id);
        }

        public int Add(Player player)
        {
            player.Id = list.Max(p => p.Id) + 1;
            list.Add(player);
            return player.Id;
        }
    }
}