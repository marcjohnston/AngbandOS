namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Shoot a 'magic missile' cone that does 300 damage.
    /// </summary>
    [Serializable]
    internal class BaMiss3Activation : DirectionalActivation
    {
        private BaMiss3Activation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => ""; // No message is displayed to the player.

        protected override string? PostAimingMessage => "You breathe the elements.";

        public override int RechargeTime(Player player) => 500;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), direction, 300, -4);
            return true;
        }

        public override int Value => 5000;

        public override string Description => "elemental breath (300) every 500 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
