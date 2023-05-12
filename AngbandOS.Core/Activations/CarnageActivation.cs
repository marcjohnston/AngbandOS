namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Carnage a chosen creature type.
    /// </summary>
    [Serializable]
    internal class CarnageActivation : Activation
    {
        private CarnageActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "It glows deep blue...";

        public override bool Activate()
        {
            SaveGame.Carnage(true);
            return true;
        }

        public override int RechargeTime(Player player) => 500;

        public override int Value => 10000;

        public override string Description => "carnage every 500 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
    }
}
