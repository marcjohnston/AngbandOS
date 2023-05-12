namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Dispel good with a strength of x5.
    /// </summary>
    [Serializable]
    internal class DispGoodActivation : Activation
    {
        private DispGoodActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "It floods the area with evil...";

        public override bool Activate()
        {
            SaveGame.DispelGood(SaveGame.Player.Level * 5);
            return true;
        }

        public override int RechargeTime(Player player) => Program.Rng.RandomLessThan(300) + 300;

        public override int Value => 3500;

        public override string Description => "dispel good (level*5) every 300+d300 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
