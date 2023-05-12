namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Remove fear and poison.
    /// </summary>
    [Serializable]
    internal class CurePoisonActivation : Activation
    {
        private CurePoisonActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It glows deep blue...";

        public override bool Activate()
        {
            SaveGame.Player.TimedFear.ResetTimer();
            SaveGame.Player.TimedPoison.ResetTimer();
            return true;
        }

        public override int RechargeTime(Player player) => 5;

        public override int Value => 1000;

        public override string Description => "remove fear and cure poison every 5 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy = true;
    }
}
