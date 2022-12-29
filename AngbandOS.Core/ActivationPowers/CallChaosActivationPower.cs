namespace AngbandOS.ActivationPowers
{
    /// <summary>
    /// Activate the Call Chaos spell.
    /// </summary>
    [Serializable]
    internal class CallChaosActivationPower : ActivationPower
    {
        public override int RandomChance => 25;

        public override string PreActivationMessage => "It glows in scintillating colours...";

        public override int RechargeTime(Player player) => 350;

        public override bool Activate(SaveGame saveGame)
        {
            saveGame.CallChaos();
            return true;
        }

        public override int Value => 5000;

        public override string Description => "call chaos every 350 turns";

        public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

        public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

        public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
    }
}
