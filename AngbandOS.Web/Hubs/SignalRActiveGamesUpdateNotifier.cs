using AngbandOS.Core.Interface;

namespace AngbandOS.Web.Hubs
{
    /// <summary>
    /// Represents an object that implements the AngbandOS Core IUpdateNotifier and accepts an action during construction
    /// to be executed when updates occur in a game.  A single instance of this object is used for all games.
    /// </summary>
    public class SignalRActiveGamesUpdateNotifier : IUpdateNotifier
    {
        private readonly Action _action;

        public SignalRActiveGamesUpdateNotifier(Action action)
        {
            _action = action;
        }

        public void NotifyAllNow()
        {
            _action();
        }
    }
}
