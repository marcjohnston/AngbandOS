namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Detect everything and do probing and identify an item fully.
    /// </summary>
    [Serializable]
    internal class DetectXtraActivation : Activation
    {
        private DetectXtraActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 10;

        public override string? PreActivationMessage => "It glows brightly...";

        public override bool Activate()
        {
            SaveGame.DetectAll();
            SaveGame.Probing();
            SaveGame.IdentifyFully();
            return true;
        }

        public override int RechargeTime(Player player) => 1000;

        public override int Value => 12500;

        public override string Description => "detection, probing and identify true every 1000 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis = true;
    }
}
