using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Bit_JukeBox.Models
{
    public class Menu
    {
        private string Name { get; set; }
        private List<MenuOption> Options { get; set; }
        public Menu(string name, List<MenuOption> options)
        {
            Name = name;
            Options = options;
        }

        void PrintMenuOptions()
        {
            int count = 1;
            foreach (var option in Options)
            {
                Console.WriteLine($"{count++} {option.Description}");
            }
        }

        public Action SelectOption()
        {
            PrintMenuOptions();
            string input = Console.ReadLine();
            int index = -1;
            bool valid = Int32.TryParse(input, out index);
            if (!valid || index <= 0 || index > Options.Count)
            {
                Console.WriteLine("Please Make A Valid Selection");
                return null;
            }
            return Options[index - 1].Action;

        }
    }
}
