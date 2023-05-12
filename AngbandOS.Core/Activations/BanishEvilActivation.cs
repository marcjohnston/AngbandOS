namespace AngbandOS.Core.Activations
{
    /// <summary>
    /// Banish evil creatures.
    /// </summary>
    [Serializable]
    internal class BanishEvilActivation : Activation
    {
        private BanishEvilActivation(SaveGame saveGame) : base(saveGame) { }
        public override int RandomChance => 33;

        public override string? PreActivationMessage => "";

        public override bool Activate()
        {
            if (SaveGame.BanishEvil(100))
            {
                SaveGame.MsgPrint("The power of the artifact banishes evil!");
            }
            return true;
        }

        public override int RechargeTime(Player player) => 250 + Program.Rng.DieRoll(250);

        public override int Value => 3000;

        public override string Description => "banish evil every 250+d250 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
    }
}
