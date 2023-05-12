namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Teleport away an opponent.
    /// </summary>
    [Serializable]
    internal class TeleAwayActivation : DirectionalActivation
    {
        private TeleAwayActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 85;

        public override int RechargeTime(Player player) => 200;

        protected override bool Activate(int direction)
        {
            SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get<TeleportAwayAllProjectile>(), direction, SaveGame.Player.Level);
            return true;
        }

        public override int Value => 2000;

        public override string Description => "teleport away every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
