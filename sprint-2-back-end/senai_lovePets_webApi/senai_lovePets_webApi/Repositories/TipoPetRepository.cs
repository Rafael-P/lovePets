using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoPetRepository : ITipoPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idTipoPet, TipoPet tipoPetAtualizado)
        {
            TipoPet tipoPetBuscado = BuscarPorId(idTipoPet);

            if (tipoPetAtualizado.NomeTipoPet != null)
            {
                tipoPetBuscado.NomeTipoPet = tipoPetAtualizado.NomeTipoPet;
            }

            ctx.TipoPets.Update(tipoPetBuscado);

            ctx.SaveChanges();
        }

        public TipoPet BuscarPorId(int idTipoPet)
        {
            return ctx.TipoPets.Find(idTipoPet);
        }

        public void Cadastrar(TipoPet novoTipoPet)
        {
            ctx.TipoPets.Add(novoTipoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoPet)
        {
            ctx.TipoPets.Remove(BuscarPorId(idTipoPet));

            ctx.SaveChanges();
        }

        public List<TipoPet> ListarTodos()
        {
            return ctx.TipoPets.ToList();
        }

    }
}
