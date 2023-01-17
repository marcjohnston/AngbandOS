namespace AngbandOS.Commands
{
    /// <summary>
    /// Fire the missile weapon we have in our hand
    /// </summary>
    [Serializable]
    internal class FireCommand : Command
    {
        private FireCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'f';

        public override bool Execute()
        {
            SaveGame.DoCmdFire();
            return false;
        }
    }
}
