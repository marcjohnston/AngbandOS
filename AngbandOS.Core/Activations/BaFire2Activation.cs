namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Shoot a fire ball that does 120 damage with a larger radius.
    /// </summary>
    [Serializable]
    internal class BaFire2Activation : DirectionalActivation
    {
        private BaFire2Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 66;

        public override string? PreActivationMessage => "It glows deep red...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(225) + 225;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBall(new FireProjectile(SaveGame), direction, 120, 3);
            return true;
        }

        public override int Value => 1750;

        public override string Description => "fire ball (120) every 225+d225 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
