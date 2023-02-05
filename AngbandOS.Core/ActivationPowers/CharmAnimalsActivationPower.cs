namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Charm multiple animals.
    /// </summary>
    [Serializable]
    internal class CharmAnimalsActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "";

        public override int RechargeTime(Player player) => 500;

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.CharmAnimals(saveGame.Player.Level * 2);
            return true;
        }

        public override int Value => 12500;

        public override string Description => "animal friendship every 500 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
