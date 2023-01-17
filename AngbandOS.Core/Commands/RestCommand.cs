namespace AngbandOS.Commands
{
    /// <summary>
    /// Rest for either a fixed amount of time or until back to max health and mana
    /// </summary>
    [Serializable]
    internal class RestCommand : Command
    {
        private RestCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'R';

        public override bool Execute() // TODO: Why can't this command take in a count?
        {
            SaveGame.DoCmdRest();
            return false;
        }
    }
}
