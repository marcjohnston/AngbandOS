using AngbandOS.Enumerations;

namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Confuse an opponent.
    /// </summary>
    [Serializable]
    internal class ConfuseActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It glows in scintillating colours...";

        public override int RechargeTime(Player player) => 15;

        protected override string PostAimingMessage => "";

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.ConfuseMonster(direction, 20);
            return true;
        }

        public override int Value => 500;

        public override string Description => "confuse monster every 15 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
