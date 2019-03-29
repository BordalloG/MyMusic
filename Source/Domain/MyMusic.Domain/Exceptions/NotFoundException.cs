using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public int Id { get; set; }
        public NotFoundException()
        {
        }
        public NotFoundException(int id)
        {
            Id = id;
        }
        public NotFoundException(string message, int id) : base(message)
        {
            Id = id;
        }
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
