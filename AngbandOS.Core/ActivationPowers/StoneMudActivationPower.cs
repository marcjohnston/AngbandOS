namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Rock to mud.
    /// </summary>
    [Serializable]
    internal class StoneMudActivationPower : DirectionalActivationPower
    {
        public override int RandomChance => 101;

        public override string PreActivationMessage => "It pulsates...";

        protected override string PostAimingMessage => throw new System.NotImplementedException();

        public override int RechargeTime(Player player) => 5;

        protected override bool Activate(SaveGame saveGame, int direction)
        {
            saveGame.WallToMud(direction);
            return true;
        }

        public override int Value => 1000;

        public override string Description => "stone to mud every 5 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
