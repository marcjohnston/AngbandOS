namespace AngbandOS.Core.ChestTraps
{
    internal class ParalyzeChestTrap : BaseChestTrap
    {
        public override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A puff of yellow gas surrounds you!");
            if (!eventArgs.SaveGame.Player.HasFreeAction)
            {
                eventArgs.SaveGame.Player.TimedParalysis.SetTimer(eventArgs.SaveGame.Player.TimedParalysis.TimeRemaining + 10 + Program.Rng.DieRoll(20));
            }
        }

        public override string Description => "(Gas Trap)";
    }
}
