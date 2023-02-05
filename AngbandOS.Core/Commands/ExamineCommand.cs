namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Examine an item
    /// </summary>
    [Serializable]
    internal class ExamineCommand : Command
    {
        private ExamineCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'x';

        public override bool Execute()
        {
            SaveGame.DoCmdExamine();
            return false;
        }
    }
}
