namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Activate sleep on touch.
    /// </summary>
    [Serializable]
    internal class SleepActivation : Activation
    {
        private SleepActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It glows deep blue...";

        public override int RechargeTime(Player player) => 55;

        public override bool Activate()
        {
            SaveGame.SleepMonstersTouch();
            return true;
        }

        public override int Value => 750;

        public override string Description => "sleep nearby monsters every 55 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
    }
}
