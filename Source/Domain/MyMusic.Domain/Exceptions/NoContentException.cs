using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Exceptions
{
    public class NoContentException : Exception
    {

        public int Id { get; set; }
        public NoContentException()
        {
        }
        public NoContentException(int id)
        {
            Id = id;
        }
        public NoContentException(string message, int id) : base(message)
        {
            Id = id;
        }
        public NoContentException(string message) : base(message)
        {

        }
    }
}
