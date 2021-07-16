using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepositoory
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idVeterinario, Veterinario veternarioAtualizado)
        {
            Veterinario veterinarioBuscado = BuscarPorId(idVeterinario);

            if (veternarioAtualizado.IdClinica > 0)
            {
                veterinarioBuscado.IdClinica = veternarioAtualizado.IdClinica;
            }

            if (veternarioAtualizado.Crmv != null)
            {
                veterinarioBuscado.Crmv = veternarioAtualizado.Crmv;
            }
        }

        public Veterinario BuscarPorId(int idVeterinario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Veterinario novoVeterinario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idVeterinario)
        {
            throw new NotImplementedException();
        }

        public List<Veterinario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
