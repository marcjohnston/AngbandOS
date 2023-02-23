namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Fire the missile weapon we have in our hand
    /// </summary>
    [Serializable]
    internal class FireInGameCommand : InGameCommand
    {
        private FireInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'f';

        public override bool Execute()
        {
            SaveGame.DoCmdFire();
            return false;
        }
    }
}
