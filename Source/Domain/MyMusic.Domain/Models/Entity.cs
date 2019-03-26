using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public Entity()
        {

        }
        protected Entity(int id)
        {
            Id = id;
        }
    }
}
