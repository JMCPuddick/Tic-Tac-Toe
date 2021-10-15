using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        String _name;
        int _number;

        public string Name { get => _name; set => _name = value; }
        public int Number { get => _number; set => _number = value; }

        public Player(String name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
