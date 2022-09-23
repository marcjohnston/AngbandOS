namespace AngbandOS.Core.Interface
{
    /// <summary>
    /// Represents an interface for a game to invoke notifications when intersting event happen during game play.
    /// </summary>
    public interface IUpdateNotifier
    {
        public void PlayerDied(string name, string diedFrom, int level);

        public void GoldUpdated(int gold);

        public void CharacterRenamed(string name);

        public void LevelChanged(int level);

        public void GameStarted();

        public void GameStopped();
        public void SaveGameIncompatible();
    }
}
