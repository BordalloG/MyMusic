using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Application.InOut.Music
{
    public class MusicRequest
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
