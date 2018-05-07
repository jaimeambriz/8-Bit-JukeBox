using System;
using System.Collections.Generic;

namespace _8_Bit_JukeBox.Models
{
    public class Note
    {
        public string Type { get; set; }
        public int Frequency { get; set; }
        public int Duration { get; set; }
        public Note(string type, int frequency, int duration)
        {
            Type = type;
            Frequency = frequency;
            Duration = duration;
        }
    }
}
