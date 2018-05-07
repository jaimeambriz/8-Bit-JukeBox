using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using _8_Bit_JukeBox.Interfaces;

namespace _8_Bit_JukeBox.Models
{
    public class Song : IPlayable
    {
        public string Title { get; set; }
        public string Composer { get; set; }
        public string Year { get; set; }
        private List<Note> Notes = new List<Note>();
        public bool Playing { get; private set; }
        private int Plays { get; set; }

        public Song(string title, string composer, string year, List<Note> notes)
        {
            Title = title;
            Composer = composer;
            Year = year;
            Notes = notes;

        }
        public void Play()
        {
            Playing = true;
            Plays++;
            while (Playing)
            {
                Console.Clear();
                Console.WriteLine("You are playing Tetris");
                Console.ReadLine();
                foreach (var note in Notes)
                {
                    if (note.Type == "beep")
                    {
                        Console.Beep(note.Frequency, note.Duration);
                    }
                    else
                    {
                        Thread.Sleep(note.Duration);
                    }
                }
            }
            Playing = false;
        }

    }
}