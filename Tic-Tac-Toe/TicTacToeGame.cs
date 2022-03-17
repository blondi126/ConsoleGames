using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    internal class TicTacToeGame
    {
        private int _maxSteps = 9;
        private readonly string[] _shield = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        private bool _win=false;
        private int _winner = 0;
        
        public void Start()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");
            while (_maxSteps>0 && _win==false)
            {
                GetX();
                _maxSteps--;
                _win = CheckWinner();
                if (_win) _winner = 1;
                if (_maxSteps <= 0 || _win != false) continue;
                GetO();
                _maxSteps--;
                _win = CheckWinner();
                if (_win) _winner = 2;
            }
            switch (_winner)
            {
                case 1:
                    Console.WriteLine("\nPlayer 1 is winner!\n");
                    Output();
                    break;
                case 2:
                    Console.WriteLine("\nPlayer 2 is winner!\n");
                    Output();
                    break;
                default:
                    Console.WriteLine("\nThere is no winner!\n");
                    Output();
                    break;
            }
        }

        private bool CheckWinner()
        {
            if (_shield[0] + _shield[1] + _shield[2] == "XXX" || _shield[0] + _shield[1] + _shield[2] == "OOO") return true;
            if (_shield[3] + _shield[4] + _shield[5] == "XXX" || _shield[3] + _shield[4] + _shield[5] == "OOO") return true;
            if (_shield[6] + _shield[7] + _shield[8] == "XXX" || _shield[6] + _shield[7] + _shield[8] == "OOO") return true;
            if (_shield[0] + _shield[3] + _shield[6] == "XXX" || _shield[0] + _shield[3] + _shield[6] == "OOO") return true;
            if (_shield[1] + _shield[4] + _shield[7] == "XXX" || _shield[1] + _shield[4] + _shield[7] == "OOO") return true;
            if (_shield[2] + _shield[5] + _shield[8] == "XXX" || _shield[2] + _shield[5] + _shield[8] == "OOO") return true;
            if (_shield[0] + _shield[1] + _shield[2] == "XXX" || _shield[0] + _shield[1] + _shield[2] == "OOO") return true;
            if (_shield[0] + _shield[4] + _shield[8] == "XXX" || _shield[0] + _shield[4] + _shield[8] == "OOO") return true;
            if (_shield[2] + _shield[4] + _shield[6] == "XXX" || _shield[2] + _shield[4] + _shield[6] == "OOO") return true;
            return false;
        }

        private void GetX()
        {
            Console.WriteLine("\nPlayer 1, please, select a coordinate (0-8):\n");
            Output();
            var x = int.Parse(Console.ReadLine());
            _shield[x] = "X";
        }
        private void GetO()
        {
            Console.WriteLine("\nPlayer 2, please, select a coordinate (0-8):\n");
            Output();
            var X = int.Parse(Console.ReadLine());
            _shield[X] = "O";
        }
        private void Output()
        {
            Console.WriteLine($"| {_shield[0]} | {_shield[1]} | {_shield[2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {_shield[3]} | {_shield[4]} | {_shield[5]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {_shield[6]} | {_shield[7]} | {_shield[8]} |\n");
        }
    }
}
