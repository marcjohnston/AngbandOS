using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Place a Yellow Sign.
    /// </summary>
    [Serializable]
    internal class RuneExploActivationPower : ActivationPower
    {
        public override int RandomChance => 33;

        public override string PreActivationMessage => "It glows a sickly yellow...";

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.YellowSign();
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 4000;

        public override string Description => "Yellow Sign every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
