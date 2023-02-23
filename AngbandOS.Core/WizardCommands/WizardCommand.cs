namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal abstract class WizardCommand
    {
        protected SaveGame SaveGame { get; }
        protected WizardCommand(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
        public abstract char Key { get; }

        public virtual bool IsEnabled => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveGame"></param>
        /// <returns>
        /// Returns true, if the command can/should be repeated; false, if the command succeeded or is futile.
        /// </returns>
        public abstract void Execute();
    }
}
