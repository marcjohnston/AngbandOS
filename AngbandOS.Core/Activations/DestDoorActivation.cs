namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Destroy nearby doors.
    /// </summary>
    [Serializable]
    internal class DestDoorActivation : Activation
    {
        private DestDoorActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It glows bright red...";

        public override bool Activate()
        {
            SaveGame.DestroyDoorsTouch();
            return true;
        }

        public override int RechargeTime(Player player) => 10;

        public override int Value => 100;

        public override string Description => "destroy doors every 10 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
