using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idPet, Pet petAtualizado)
        {
            Pet petBuscado = BuscarPorId(idPet);

            if (petAtualizado.IdRaca > 0)
            {
                petBuscado.IdRaca = petAtualizado.IdRaca;
            }

            if (petAtualizado.IdDono > 0)
            {
                petBuscado.IdDono = petAtualizado.IdDono;
            }

            if (petAtualizado.NomePet != null)
            {
                petBuscado.NomePet = petAtualizado.NomePet;
            }

            if (petAtualizado.DataNascimento > DateTime.Now)
            {
                petBuscado.DataNascimento = petAtualizado.DataNascimento;
            }

            if (petAtualizado.Ra != null)
            {
                petBuscado.Ra = petAtualizado.Ra;
            }

            if (petAtualizado.IdUsuario > 0)
            {
                petBuscado.IdUsuario = petAtualizado.IdUsuario;
            }

            ctx.Pets.Update(petBuscado);

            ctx.SaveChanges();
        }

        public Pet BuscarPorId(int idPet)
        {
            return ctx.Pets.Find(idPet);
        }

        public void Cadastrar(Pet novoPet)
        {
            ctx.Pets.Add(novoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int idPet)
        {
            ctx.Pets.Remove(BuscarPorId(idPet));

            ctx.SaveChanges();
        }

        public List<Pet> ListarTodos()
        {
            return ctx.Pets.ToList();
        }

    }
}
