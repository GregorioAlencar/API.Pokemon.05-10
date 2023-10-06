using Pokedex.API.Models;
using Pokedex.API.Repositories;
using System;
using System.Collections.Generic;

namespace Pokedex.API.Services
{
    public class PokemonService
    {
        public List<Pokemon> SelectPokemons()
        {
            try
            {
                PokemonRepository pokemonRepository = new PokemonRepository();
                List<Pokemon> pokemons = pokemonRepository.SelectPokemons();
                return pokemons;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Pokemon SelectPokemonById(int Id)
        {
            try
            {
                PokemonRepository pokemonRepository = new PokemonRepository();
                Pokemon pokemon = pokemonRepository.GetPokemonById(Id);
                return pokemon;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
