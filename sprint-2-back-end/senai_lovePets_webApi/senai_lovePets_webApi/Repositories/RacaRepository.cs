using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class RacaRepository : IRacaRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idRaca, Raca racaAtualizada)
        {
            Raca racaBuscada = BuscarPorId(idRaca);

            if (racaAtualizada.IdTipoPet > 0)
            {
                racaBuscada.IdTipoPet = racaAtualizada.IdTipoPet;
            }

            if (racaAtualizada.NomeRaca != null)
            {
                racaBuscada.NomeRaca = racaAtualizada.NomeRaca;
            }

            ctx.Racas.Update(racaBuscada);

            ctx.SaveChanges();
        }

        public Raca BuscarPorId(int idRaca)
        {
            return ctx.Racas.Find(idRaca);
        }

        public void Cadastrar(Raca novaRaca)
        {
            ctx.Racas.Add(novaRaca);

            ctx.SaveChanges();
        }

        public void Deletar(int idRaca)
        {
            ctx.Racas.Remove(BuscarPorId(idRaca));

            ctx.SaveChanges();
        }

        public List<Raca> ListarTodos()
        {
            return ctx.Racas.ToList();
        }

    }
}
