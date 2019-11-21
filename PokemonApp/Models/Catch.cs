using System;

namespace PokemonApp.Models
{
    public class Catch
    {
        public int Id { get; set; }

        
        public int TrainerId { get; set; }
        public int PokemonId { get; set; }
        public string Name { get; set; }
        public Trainer Trainer { get; set; }
        public Pokemon Pokemon { get; set; }

        public Catch()
        {
        }
    }
}
