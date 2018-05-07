using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace _8_Bit_JukeBox.Models
{
    public class Jukebox
    {
        public bool Accessing { get; private set; }
        public bool InSection { get; set; }
        private List<Song> Songs = new List<Song>();
        private Menu MainMenu { get; set; }
        private Menu SongMenu { get; set; }


        public Jukebox()
        {
            Accessing = true;
            MainMenu = BuildMainMenu();
            InSection = false;
        }

        Menu BuildMainMenu()
        {
            return new Menu(
            "Main Menu",
                new List<MenuOption>
                {
                new MenuOption(SongSelection, "See List Of Songs"),
                new MenuOption(LeaveJukeBox,"Leave JukeBox")
                });
        }

        private void LeaveJukeBox()
        {
            Console.WriteLine("Good Bye!");
            Accessing = false;
        }

        public void Setup()
        {
            BuildSongMenu();
        }

        void BuildSongMenu()
        {

            SongMenu = new Menu("Song Menu", new List<MenuOption>{
                new MenuOption (PrintSongs, "View All Songs"),
                new MenuOption (GoBack, "Go Back")
            });
        }

        private void PrintSongs()
        {

            Console.Clear();
            int count = 1;
            foreach (var song in Songs)
            {
                Console.WriteLine($"{count++} {song.Title} ");
            }
            Console.WriteLine("Which Song Would You Like to Hear?");
            var input = Console.ReadLine();
            int selection = -1;
            bool valid = Int32.TryParse(input, out selection);

            if (!valid || selection <= 0 || selection > Songs.Count)
            {
                Console.WriteLine("Please Input a Valid Selection");
            }

            Songs[selection - 1].Play();

        }
        public void MainMenuSelection()
        {
            Action action = MainMenu.SelectOption();
            if (action != null)
            {
                action.Invoke();
            }
        }

        private void GoBack()
        {
            Console.WriteLine("Thanks for Looking!");
            InSection = false;
        }



        private void SongSelection()
        {
            Console.Clear();
            InSection = true;
            while (InSection)
            {
                Action action = SongMenu.SelectOption();
                if (action != null)
                {
                    action.Invoke();
                }
            }
        }

        internal void AddSong(Song song)
        {
            Songs.Add(song);
        }
    }
}