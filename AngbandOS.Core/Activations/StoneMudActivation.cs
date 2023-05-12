namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Rock to mud.
    /// </summary>
    [Serializable]
    internal class StoneMudActivation : DirectionalActivation
    {
        private StoneMudActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It pulsates...";

        public override int RechargeTime(Player player) => 5;

        protected override bool Activate(int direction)
        {
            SaveGame.WallToMud(direction);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "stone to mud every 5 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
