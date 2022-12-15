using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Drain up to 120 life from an opponent.
    /// </summary>
    [Serializable]
    internal class Drain2ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 66;

        public override string PreActivationMessage => "It glows black...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.DrainLife(direction, 120);
            return true;
        }

        public override int Value => 750;

        public override string Description => "drain life (120) every 400 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
