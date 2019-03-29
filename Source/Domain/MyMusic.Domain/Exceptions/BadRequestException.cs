using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Domain.Exceptions
{
    public class BadRequestException : Exception
    {

        public int Id { get; set; }
        public BadRequestException()
        {
        }
        public BadRequestException(int id)
        {
            Id = id;
        }
        public BadRequestException(string message, int id) : base(message)
        {
            Id = id;
        }
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
