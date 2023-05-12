namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Shoot an acid bolt that does 5d8 damage.
    /// </summary>
    [Serializable]
    internal class BoAcid1Activation : DirectionalActivation
    {
        private BoAcid1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It is covered in acid...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(5) + 5;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBolt(new AcidProjectile(SaveGame), direction, Program.Rng.DiceRoll(5, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "acid bolt (5d8) every 5+d5 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
