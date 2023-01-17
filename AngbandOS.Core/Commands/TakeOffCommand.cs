namespace AngbandOS.Commands
{
    /// <summary>
    /// Take off an item
    /// </summary>
    [Serializable]
    internal class TakeOffCommand : Command
    {
        private TakeOffCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 't';

        public override bool Execute()
        {
            SaveGame.DoCmdTakeOff();
            return false;
        }
    }
}
