namespace AngbandOS.Core.ChestTraps
{
    internal class SummonChestTrap : BaseChestTrap
    {
        public override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            int num = 2 + Program.Rng.DieRoll(3);
            eventArgs.SaveGame.MsgPrint("You are enveloped in a cloud of smoke!");
            for (int i = 0; i < num; i++)
            {
                if (Program.Rng.DieRoll(100) < eventArgs.SaveGame.Difficulty)
                {
                    eventArgs.SaveGame.ActivateHiSummon();
                }
                else
                {
                    eventArgs.SaveGame.Level.Monsters.SummonSpecific(eventArgs.Y, eventArgs.X, eventArgs.SaveGame.Difficulty, null);
                }
            }
        }

        public override string Description => "(Summoning Runes)";
    }
}
