using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pre.Core.GameFunctionality
{
    internal class StorySegment
    {
        internal string Description { get; private set; }
        internal string Content { get; private set; }

        internal StorySegment(string description, string content)
        {
            Description = description;
            Content = content;
        }
    }
}
