using Pre.Pre.Core.GameFunctionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.DataRepositories
{
    internal class StoryRepository
    {
        internal IEnumerable<StorySegment> GetStoryParts()
        {
            return new List<StorySegment>
            {
                new StorySegment("Intro", $"You awaken in a cold dark room, hungry and cold. You don't remember how you got here, nor where you are. You appear to\nbe captive in a cage." +
                                                 " Now it hits you like a bag of bricks: you need to escape this dungeon as fast as you can.\n\n" +
                                                 "All of a sudden you hear footsteps down the damp, cold hall. You also hear snorting and heavy breathing." +
                                                 " You wonder\nwhat or who it is. Out of the dark comes a creature that reminds you of a pig crossed with a human.\n\n" +
                                                 "He opens your cage. In a slurred almost drunken speech he utters: give me all you got, you filthy human!"),

                new StorySegment("Second Floor", "You've successfully escaped being obliterated by that awful fiend. Who knows what he had in store for you.\n\n" +
                                                          "Luckily you've taught him a lesson. Shaking from the ordeal and with a pounding heart, you continue down the hall. You\nopen the door to the next room and" +
                                                          "out of the dark appears a new enemy!"),

                new StorySegment("Second Floor", "Phew! You survived that encounter yet again! This dungeon is starting to creep you out more and more.\n\nYou continue on and encounter a tomb." +
                                                          " Thinking there's treasure inside, you open the tomb! BIG MISTAKE!"),

                new StorySegment("Second Floor Boss", "Another one bites the dust. You're starting to think you might survive this ordeal after all!\n\n" +
                                                          "You enter the next room, which is filled with a nasty smell. You're starting to think something died in here...\n\n" +
                                                          "You see a stairway to the next level. You make a break for it, cutting across the nasty smelling room quite fast.\n\n" +
                                                          "WAAAAAAAAAAAAAAAAH. "),

                new StorySegment("First Floor", "You've successfully escaped the clutches of another madman yet again. You climb upstairs, not knowing what's in store\nfor you." +
                                                         "But you're getting the sense the end is near. Unfortunately, not that near, as another enemy appears in\nyour way."),

                new StorySegment("First Floor", "VICTORIOUS! Victory is near, after defeating that mighty monstrosity, you cut across the room, looking for any stairway out of the dungeon." +
                                                         "You see one, but aren't sure how you're going to get there, as there is a fiend in the middle of the room. Bold as you are, you try him on."),

                new StorySegment("First Floor Boss", "Almost a seasoned Monster Hunter by now, you climb up the stairs, out of the dungeon. Unfortunately, a huge monster\nsensed your presence and dashes " +
                                                         "towards you like a lion pouncing his prey. Seasoned as you are, you take this\nfinal fiend on."),


            };
        }
    }
}
