namespace AngbandOS.Core.ChestTraps
{
    internal class ParalyzeChestTrap : BaseChestTrap
    {
        public ParalyzeChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }
        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A puff of yellow gas surrounds you!");
            if (!eventArgs.SaveGame.Player.HasFreeAction)
            {
                eventArgs.SaveGame.Player.SetTimedParalysis(eventArgs.SaveGame.Player.TimedParalysis + 10 + Program.Rng.DieRoll(20));
            }
        }
    }
}
