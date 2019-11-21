using System;
using System.Collections.Generic;

namespace PokemonApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public List<Catch> Catches { get; set; }
        public string Description { get; set; }
        public string FavoriteMove { get; set; }

        public Pokemon()
        {
        }
    }
}
