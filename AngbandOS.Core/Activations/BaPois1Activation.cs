namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Shoot a 12-damage ball of poison
    /// </summary>
    [Serializable]
    internal class BaPois1Activation : DirectionalActivation
    {
        private BaPois1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It throbs deep green...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(4) + 4;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBall(new PoisProjectile(SaveGame), direction, 12, 3);
            return true;
        }

        public override int Value => 300;

        public override string Description => "stinking cloud (12), rad. 3, every 4+d4 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
