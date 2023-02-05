namespace AngbandOS.Core.Commands
{
    [Serializable]
    internal abstract class Command // TODO: Convert this to a class
    {
        protected SaveGame SaveGame { get; }
        protected Command(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
        public abstract char Key { get; }

        /// <summary>
        /// Return 0, if the command should not be repeatable via a CommandArgument/Count; otherwise, return null, to indicate that the command allows
        /// the player to specify a CommandArgument/Count; or a value greater than 0, to indicate that the command is repeatable but if the player does not
        /// specify a CommandArgument/Count, default the count to the value being returned.
        /// </summary>
        public virtual int? Repeat => 0;

        public virtual bool IsEnabled => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveGame"></param>
        /// <returns>Returns true, if the command can/should be repeated; false, if the command succeeded or is futile.</returns>
        public abstract bool Execute();
    }
}
