namespace AngbandOS.Core.WizardCommands
{
    [Serializable]
    internal abstract class WizardCommand : IHelpCommand
    {
        protected SaveGame SaveGame { get; }
        protected WizardCommand(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
        public abstract char Key { get; }

        public virtual bool IsEnabled => true;

        /// <summary>
        /// Returns the name of a group when rendering the wizard help screen; or null, if the command should not be rendered on the help screen.  Returns null, by default.
        /// </summary>
        public virtual HelpGroup? HelpGroup => null;

        /// <summary>
        /// Returns a description of the command to be rendered on the Wizard Help screen.  Returns empty by default.
        /// </summary>
        public virtual string HelpDescription => "";

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
