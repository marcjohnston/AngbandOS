using AngbandOS.Core.Interface;
using System.Xml.Linq;

namespace AngbandOS.Web.Hubs
{
    public class UpdateNotifier : IUpdateNotifier
    {
        private readonly SignalRConsole SignalRConsole;
        private readonly Action<SignalRConsole, GameUpdateNotificationEnum, string> Action;

        public UpdateNotifier(SignalRConsole signalRConsole, Action<SignalRConsole, GameUpdateNotificationEnum, string> action)
        {
            Action = action;
            SignalRConsole = signalRConsole;
        }

        public void CharacterRenamed(string name)
        {
            string message = $"{name} was just born.";
            Action(SignalRConsole, GameUpdateNotificationEnum.CharacterRenamed, message);
        }

        public void GameStarted()
        {
            Action(SignalRConsole, GameUpdateNotificationEnum.GameStarted, "Game started.");
        }

        public void GoldUpdated(int gold)
        {
            Action(SignalRConsole, GameUpdateNotificationEnum.GoldUpdated, "Gold updated.");
        }

        public void LevelChanged(int level)
        {
            Action(SignalRConsole, GameUpdateNotificationEnum.LevelChanged, "Level changed.");
        }
        public void GameStopped()
        {
            Action(SignalRConsole, GameUpdateNotificationEnum.GameStopped, "Game stopped.");
        }

        public void PlayerDied(string name, string diedFrom, int level)
        {
            string message = $"{name.Trim()} was just killed by {diedFrom} on level {level}.";
            Action(SignalRConsole, GameUpdateNotificationEnum.PlayerDied, message);
        }

        public void GameExceptionThrown(string message)
        {
            Action(SignalRConsole, GameUpdateNotificationEnum.GameExceptionThrown, message);
        }
    }
}
