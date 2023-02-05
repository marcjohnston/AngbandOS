namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Teleport away an opponent.
    /// </summary>
    [Serializable]
    internal class TeleAwayActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 85;

        public override string PreActivationMessage => "";

        protected override string PostAimingMessage => "";

        public override int RechargeTime(Player player) => 200;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.FireBeam(new ProjectAwayAll(saveGame), direction, saveGame.Player.Level);
            return true;
        }

        public override int Value => 2000;

        public override string Description => "teleport away every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
