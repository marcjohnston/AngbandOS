using AngbandOS.Core;
using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an object that plays either a new game, an existing game or replay a game.  The constructors are different for each derived class to support the
    /// play mode/context.
    /// </summary>
    internal abstract class RunContext
    {
        public abstract GameResults Play(IConsoleAndViewPort consoleAndViewPort, GameServer gameServer);
    }
}
