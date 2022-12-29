namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Shoot an acid bolt that does 5d8 damage.
    /// </summary>
    [Serializable]
    internal class BoAcid1ActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It is covered in acid...";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(5) + 5;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBolt(new ProjectAcid(saveGame), direction, Program.Rng.DiceRoll(5, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "acid bolt (5d8) every 5+d5 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
