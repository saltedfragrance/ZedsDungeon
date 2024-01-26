using Pre.Pe2.Cons.Entities;
using Pre.Pe2.Cons.Services;
using Pre.Pre.Core.Services;
using System;

namespace Pre.Pe2.Cons
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameService gameService = new GameService();
            gameService.StartGame();
        }
    }
}