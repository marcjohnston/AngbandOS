namespace AngbandOS.Commands
{
    /// <summary>
    /// Aim a wand from your inventory
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the wand, or -999 to select one </param>
    [Serializable]
    internal class AimWandCommand : Command
    {
        private AimWandCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'a';

        public override bool Execute()
        {
            SaveGame.DoAimWand();
            return false;
        }
    }
}
