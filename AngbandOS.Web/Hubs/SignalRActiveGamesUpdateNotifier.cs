using AngbandOS.Interface;

namespace AngbandOS.Web.Hubs
{
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
