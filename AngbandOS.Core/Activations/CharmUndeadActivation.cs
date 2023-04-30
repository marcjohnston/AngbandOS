namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Charm an undead.
    /// </summary>
    [Serializable]
    internal class CharmUndeadActivation : DirectionalActivation
    {
        private CharmUndeadActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "";

        public override int RechargeTime(Player player) => 333;

        protected override bool Activate(int direction)
        {
            SaveGame.ControlOneUndead(direction, SaveGame.Player.Level);
            return true;
        }

        public override int Value => 10000;

        public override string Description => "enslave undead every 333 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}
