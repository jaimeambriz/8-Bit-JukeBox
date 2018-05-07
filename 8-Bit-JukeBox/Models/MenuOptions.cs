using System;
using System.Collections.Generic;

namespace _8_Bit_JukeBox.Models
{
    public class MenuOption
    {
        public Action Action { get; private set; }
        public string Description { get; private set; }

        public MenuOption(Action action, string description)
        {
            Action = action;
            Description = description;
        }

    }
}
