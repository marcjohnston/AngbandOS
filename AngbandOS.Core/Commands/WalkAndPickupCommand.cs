namespace AngbandOS.Commands
{
    [Serializable]
    internal class WalkAndPickupCommand : ICommand
    {
        private WalkAndPickupCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => ';';

        public int? Repeat => null;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DoCmdWalk(saveGame, false);
        }

        public static void DoCmdWalk(SaveGame saveGame, bool dontPickup)
        {
            bool disturb = false;
            // If we don't already have a direction, get one
            if (saveGame.GetDirectionNoAim(out int dir))
            {
                // Walking takes a full turn
                saveGame.EnergyUse = 100;
                saveGame.MovePlayer(dir, dontPickup);
                disturb = true;
            }
            // We will have been disturbed, unless we cancelled the direction prompt
            if (!disturb)
            {
                saveGame.Disturb(false);
            }
        }
    }
}
