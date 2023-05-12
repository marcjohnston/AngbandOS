namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Shoot a lightning bolt that does 4d8 damage
    /// </summary>
    [Serializable]
    internal class BoElec1Activation : DirectionalActivation
    {
        private BoElec1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It is covered in sparks...";

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(6) + 6;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), direction, Program.Rng.DiceRoll(4, 8));
            return true;
        }

        public override int Value => 250;

        public override string Description => "lightning bolt (4d8) every 6+d6 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
