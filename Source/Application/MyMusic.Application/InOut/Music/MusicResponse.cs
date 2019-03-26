using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Application.InOut.Music
{
    public class MusicResponse
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
