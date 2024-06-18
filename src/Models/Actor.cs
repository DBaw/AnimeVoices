using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeVoices.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Actor(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
