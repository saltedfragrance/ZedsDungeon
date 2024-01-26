using Pre.Pe2.Cons.Entities;
using Pre.Pre.Core.GameFunctionality;
using Pre.Pre.Core.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.Services
{
    internal class StoryService
    {

        internal void Intro(GameService game)
        {
            StorySegment prompt = game.StoryRepository.GetStoryParts().First(i => i.Description == ("Intro"));

            Monster monster = game.Monsters.GetBoss("Prison Keeper", game.CurrentPlayer);

            game.DisplayService.WriteCenter(prompt.Content);
            game.BattleService.Encounter(game.CurrentPlayer, monster, game);
        }

        internal void Dungeon(GameService game)
        {
            foreach (StorySegment segment in game.StoryRepository.GetStoryParts().Where(s => s.Description.Contains("Second Floor")))
            {
                if (segment.Description.Contains("Boss"))
                {
                    Monster monster = game.Monsters.GetBoss("Beelzebub", game.CurrentPlayer);

                    game.DisplayService.WriteCenter(segment.Content);
                    game.BattleService.Encounter(game.CurrentPlayer, monster, game);
                }

                else
                {
                    Monster monster = game.Monsters.GetRandomMonster(game.CurrentPlayer);

                    game.DisplayService.WriteCenter(segment.Content);
                    game.BattleService.Encounter(game.CurrentPlayer, monster, game);
                }
            }

            foreach (StorySegment segment in game.StoryRepository.GetStoryParts().Where(s => s.Description.Contains("First Floor")))
            {
                if (segment.Description.Contains("Boss"))
                {
                    Monster monster = game.Monsters.GetBoss("Zed", game.CurrentPlayer);

                    game.DisplayService.WriteCenter(segment.Content);
                    game.BattleService.Encounter(game.CurrentPlayer, monster, game);
                }

                else
                {
                    Monster monster = game.Monsters.GetRandomMonster(game.CurrentPlayer);

                    game.DisplayService.WriteCenter(segment.Content);
                    game.BattleService.Encounter(game.CurrentPlayer, monster, game);
                }
            }
        }
    }
}
