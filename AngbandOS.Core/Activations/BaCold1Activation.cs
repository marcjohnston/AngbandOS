namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Shoot a frost ball that does 48 damage.
    /// </summary>
    [Serializable]
    internal class BaCold1Activation : DirectionalActivation
    {
        private BaCold1Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 85;

        public override string? PreActivationMessage => "It is covered in frost...";

        public override int RechargeTime(Player player) => 400;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), direction, 48, 2);
            return true;
        }

        public override int Value => 750;

        public override string Description => "ball of cold (48) every 400 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
