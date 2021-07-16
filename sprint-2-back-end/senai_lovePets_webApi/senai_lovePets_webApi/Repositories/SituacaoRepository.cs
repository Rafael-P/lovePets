using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(int idSituacao, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = BuscarPorId(idSituacao);

            if (situacaoAtualizada.NomeSituacao != null)
            {
                situacaoBuscada.NomeSituacao = situacaoAtualizada.NomeSituacao;
            }

            ctx.Situacaos.Update(situacaoBuscada);

            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int idSituacao)
        {
            return ctx.Situacaos.Find(idSituacao);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            ctx.Situacaos.Remove(BuscarPorId(idSituacao));

            ctx.SaveChanges();
        }

        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.ToList();
        }

    }
}
