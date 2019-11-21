using System;
using System.Collections.Generic;

namespace PokemonApp.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Catch> Catches { get; set; }

        public Trainer()
        {
            
        }
    }
}
