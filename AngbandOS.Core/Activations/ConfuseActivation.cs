namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Confuse an opponent.
    /// </summary>
    [Serializable]
    internal class ConfuseActivation : DirectionalActivation
    {
        private ConfuseActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It glows in scintillating colours...";

        public override int RechargeTime(Player player) => 15;

        protected override bool Activate(int direction)
        {
            SaveGame.ConfuseMonster(direction, 20);
            return true;
        }

        public override int Value => 500;

        public override string Description => "confuse monster every 15 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
