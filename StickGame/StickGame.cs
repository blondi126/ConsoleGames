using System;
using System.Collections.Generic;
using System.Text;

namespace StickGame
{

    public class StickGame
    {
        public delegate void Action(StickGame game);
        public Action CheckStickIs0;

        public int Sticks;
        public int CounterSteps = 0;
        public GameStatus GameStatus { get; private set; } = GameStatus.NotStarter;
        public FirstPlayer FirstPlayer { get; }

        public StickGame(int sticks = 10, FirstPlayer firstPlayer = FirstPlayer.Man)
        {
            this.Sticks = sticks;
            this.FirstPlayer = firstPlayer;
            if (this.FirstPlayer == FirstPlayer.Machine) CounterSteps++;
        }
        public void RegistOnCheck(Action action)
        {
            this.CheckStickIs0 += action;
            GameStatus = GameStatus.InProgress;
        }
        public int CarIsRunning()
        {
            CounterSteps++;
            var step=0;
            if (Sticks % 4 == 0) step = 3;
            if (Sticks % 4 == 1) step = 1;
            if (Sticks % 4 == 2) step = 1;
            if (Sticks % 4 == 3) step = 2;
            Sticks -= step;
            if (Sticks != 0) return step;
            GameStatus = GameStatus.Won;
            CheckStickIs0(this);
            return step;
        }

        public int ManIsRunning(int step)
        {
            CounterSteps++;
            this.Sticks -= step;
            if (Sticks != 0) return this.Sticks;
            GameStatus = GameStatus.Lost;
            CheckStickIs0(this);
            return this.Sticks;
        }
    }
}
