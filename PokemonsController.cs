using Microsoft.AspNetCore.Mvc;
using Pokedex.API.Models;
using Pokedex.API.Repositories;
using Pokedex.API.Services;
using System;
using System.Collections.Generic;

namespace Pokedex.API.Controllers
{
    [ApiController]
    [Route("api/pokemons")]
    public class PokemonsController : ControllerBase
    {
        private readonly ILogger<PokemonsController> _logger;
     
        public PokemonsController(ILogger<PokemonsController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                PokemonService pokemonService = new PokemonService();
                List<Pokemon> pokemons = pokemonService.SelectPokemons();
                return Ok(pokemons);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Erro ao buscar Pokémons.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                PokemonService pokemonService = new PokemonService();
                Pokemon pokemon = pokemonService.SelectPokemonById(id);
                if (pokemon == null)
                {
                    return NotFound();
                }
                return Ok(pokemon);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Erro ao buscar Pokémon por ID.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}

