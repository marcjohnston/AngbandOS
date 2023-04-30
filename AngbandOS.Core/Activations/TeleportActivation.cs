namespace AngbandOS.Core.ActivationPowers
{
    /// <summary>
    /// Long range teleport.
    /// </summary>
    [Serializable]
    internal class TeleportActivation : Activation
    {
        private TeleportActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 101;

        public override string? PreActivationMessage => "It twists space around you...";

        public override bool Activate()
        {
            SaveGame.TeleportPlayer(100);
            return true;
        }

        public override int RechargeTime(Player player) => 45;

        public override int Value => 2000;

        public override string Description => "teleport (range 100) every 45 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
