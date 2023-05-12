namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Light the area.
    /// </summary>
    [Serializable]
    internal class LightActivation : Activation
    {
        private LightActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It wells with clear light...";

        public override bool Activate()
        {
            SaveGame.LightArea(Program.Rng.DiceRoll(2, 15), 3);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(10) + 10;

        public override int Value => 150;

        public override string Description => "light area (dam 2d15) every 10+d10 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
    }
}
