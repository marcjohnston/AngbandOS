namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Place a Yellow Sign.
    /// </summary>
    [Serializable]
    internal class RuneExploActivation : Activation
    {
        private RuneExploActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "It glows a sickly yellow...";

        public override bool Activate()
        {
            SaveGame.YellowSign();
            return true;
        }

        public override int RechargeTime(Player player) => 200;

        public override int Value => 4000;

        public override string Description => "Yellow Sign every 200 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
