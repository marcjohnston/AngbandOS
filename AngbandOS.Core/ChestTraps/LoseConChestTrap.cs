using AngbandOS.Enumerations;

namespace AngbandOS.Core.ChestTraps
{
    internal class LoseConChestTrap : BaseChestTrap
    {
        public override void Activate(ActivateChestTrapEventArgs eventArgs)
        {
            eventArgs.SaveGame.MsgPrint("A small needle has pricked you!");
            eventArgs.SaveGame.Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
            eventArgs.SaveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
        }
        public override string Description => "(Poison Needle)";
    }
}
