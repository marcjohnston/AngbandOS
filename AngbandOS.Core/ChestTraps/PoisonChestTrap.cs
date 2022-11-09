namespace AngbandOS.Core.ChestTraps
{
    internal class PoisonChestTrap : BaseChestTrap
    {
        public PoisonChestTrap(BaseChestTrap? nextTrap = null) : base(nextTrap)
        {
        }

        protected override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A puff of green gas surrounds you!");
            if (!(eventArgs.SaveGame.Player.HasPoisonResistance || eventArgs.SaveGame.Player.TimedPoisonResistance != 0))
            {
                if (Program.Rng.DieRoll(10) <= eventArgs.SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    eventArgs.SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else
                {
                    eventArgs.SaveGame.Player.SetTimedPoison(eventArgs.SaveGame.Player.TimedPoison + 10 + Program.Rng.DieRoll(20));
                }
            }
        }
    }
}
