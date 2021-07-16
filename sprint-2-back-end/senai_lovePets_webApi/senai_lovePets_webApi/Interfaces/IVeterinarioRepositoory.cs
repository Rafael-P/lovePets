using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IVeterinarioRepositoory
    {

        List<Veterinario> ListarTodos();

        Veterinario BuscarPorId(int idVeterinario);

        void Cadastrar(Veterinario novoVeterinario);

        void Atualizar(int idVeterinario, Veterinario veternarioAtualizado);

        void Deletar(int idVeterinario);

    }
}
