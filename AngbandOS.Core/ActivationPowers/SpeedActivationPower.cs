using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Give us temporary haste.
    /// </summary>
    [Serializable]
    internal class SpeedActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows bright green...";

        public override bool Activate(SaveGame saveGame)
        {
            if (saveGame.Player.TimedHaste == 0)
            {
                saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(20) + 20);
            }
            else
            {
                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
            }
            return true;
        }

        public override int RechargeTime(Player player) => 250;

        public override int Value => 15000;

        public override string Description => "speed (dur 20+d20) every 250 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
