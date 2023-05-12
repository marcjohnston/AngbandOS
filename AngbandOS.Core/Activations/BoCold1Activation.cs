namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Shoot a frost bolt that does 6d8 damage.
    /// </summary>
    [Serializable]
    internal class BoCold1Activation : DirectionalActivation
    {
        private BoCold1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It is covered in frost...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(7) + 7;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), direction, Program.Rng.DiceRoll(6, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "frost bolt (6d8) every 7+d7 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
    }
}
